using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;
using AutoMapper;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        public ActionResult Index(int? id)//long idCliente
        {
            
            var modelo = new List<Models.BeneficiarioModel>();
            if (id != null)
            {
                BoBeneficiario bo = new BoBeneficiario();
                var beneficiarios = bo.ConsultarPorCliente((int)id);//idCliente

                var configuration = new MapperConfiguration(c =>
                {
                    c.CreateMap<Beneficiario, BeneficiarioModel>();
                });

                IMapper mapperClass = configuration.CreateMapper();

                modelo = mapperClass.Map<List<FI.AtividadeEntrevista.DML.Beneficiario>, List<Models.BeneficiarioModel>>(beneficiarios);
            }

            return View(modelo);
           
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();
            if (bo.VerificarExistencia(model.CPF, model.IdCliente))
            {
                Response.StatusCode = 400;
                return Json($"CPF já consta como beneficiario do cliente {model.IdCliente}");
            }

            if (!Util.ValidaCPF(model.CPF))
            {
                Response.StatusCode = 400;
                return Json($"CPF inválido: {model.CPF}");

            }
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {

                model.Id = bo.Incluir(new Beneficiario()
                {
                    Nome = model.Nome,
                    CPF =Util.RemoveNaoNumericos(model.CPF),
                    IdCliente = model.IdCliente
                });
                

                return Json(model);
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();
            if (bo.VerificarExistencia(model.CPF, model.IdCliente))
            {
                Response.StatusCode = 400;
                return Json($"CPF já consta como beneficiario do cliente {model.IdCliente}");
            }

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Beneficiario()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    CPF = model.CPF,
                    IdCliente = model.IdCliente
                });

                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoBeneficiario bo = new BoBeneficiario();
            Beneficiario benef = bo.Consultar(id);
            Models.BeneficiarioModel model = null;

            if (benef != null)
            {
                model = new BeneficiarioModel()
                {
                    Id = benef.Id,
                    Nome = benef.Nome,
                    CPF = benef.CPF,
                    IdCliente = benef.IdCliente,

                };


            }

            return View(model);
        }

        [HttpPost]
        public JsonResult BeneficiarioList(int idcliente)
        {
            try
            {

                List<Beneficiario> benefs = new BoBeneficiario().ConsultarPorCliente(idcliente);
                return Json(new { Result = "OK", Records = benefs, TotalRecordCount = benefs.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Excluir(long id)
        {
            try
            {
                BoBeneficiario bo = new BoBeneficiario();
                bo.Excluir(id);

                //Return result to jTable
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = ex.Message
                });
            }
        }
    }
}