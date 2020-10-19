using AutoMapper;
using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

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
            if (bo.VerificarExistencia(model.CPF, model.IdCliente, model.Id))
            {
                Response.StatusCode = 400;
                return Json($"CPF já consta como beneficiario do cliente {model.IdCliente}");
            }
            
            if (!ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {

                //var configuration = new MapperConfiguration(c =>
                //{
                //    c.CreateMap<BeneficiarioModel, Beneficiario>();
                //});
                //IMapper mapperClass = configuration.CreateMapper();
                //var beneficiario = mapperClass.Map<BeneficiarioModel, Beneficiario>(model);
                //model.Id = bo.Incluir(beneficiario);


                model.Id = bo.Incluir(new Beneficiario()
                {
                    Nome = model.Nome,
                    CPF = model.CPF,
                    IdCliente = model.IdCliente
                });


                return Json(model);
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();
            if (bo.VerificarExistencia(model.CPF, model.IdCliente, model.Id))
            {
                Response.StatusCode = 400;
                return Json($"CPF já consta como beneficiario do cliente {model.IdCliente}");
            }

            if (!ModelState.IsValid)
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

                return Json(model);
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
        
        //[HttpPost]
        //public JsonResult BeneficiarioList(long idcliente, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        //{
        //    try
        //    {
        //        int qtd = 0;
        //        string campo = string.Empty;
        //        string crescente = string.Empty;
        //        string[] array = jtSorting.Split(' ');

        //        if (array.Length > 0)
        //            campo = array[0];

        //        if (array.Length > 1)
        //            crescente = array[1];

        //        List<Beneficiario> beneficiarios = new BoBeneficiario().Pesquisa(idcliente, jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

        //        //Return result to jTable
        //        return Json(new { Result = "OK", Records = beneficiarios, TotalRecordCount = qtd });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

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