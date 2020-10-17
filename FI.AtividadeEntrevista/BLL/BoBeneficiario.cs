using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            return benef.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiario</param>
        public void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            benef.Alterar(beneficiario);
        }

        /// <summary>
        /// Consulta o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            return benef.Consultar(id);
        }

        /// <summary>
        /// Excluir o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            benef.Excluir(id);
        }


        /// <summary>
        /// Consulta o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public List<DML.Beneficiario> ConsultarPorCliente(int idcliente)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            return benef.ConsultarByIdCliente(idcliente);
        }


        ///// <summary>
        ///// Lista os beneficiarios
        ///// </summary>
        //public List<DML.Beneficiario> Listar()
        //{
        //    DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
        //    return benef.Listar();
        //}

        ///// <summary>
        ///// Lista os beneficiarios
        ///// </summary>
        //public List<DML.Beneficiario> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        //{
        //    DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
        //    return benef.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        //}

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string cpf, long idCliente)
        {
            DAL.DaoBeneficiario benef = new DAL.DaoBeneficiario();
            return benef.VerificarExistencia(cpf, idCliente);
        }
    }
}
