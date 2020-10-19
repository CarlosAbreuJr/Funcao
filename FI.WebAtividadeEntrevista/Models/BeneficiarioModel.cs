using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Beneficiario
    /// </summary>
    public class BeneficiarioModel
    {
        private string cpf;

        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required(ErrorMessage = "CPF obrigatório")]
        [RegularExpression(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$", ErrorMessage = "Digite um CPF válido")]
        [WebAtividadeEntrevista.ValidationAttributeCPF(ErrorMessage = "CPF inválido")]
        public string CPF
        {
            get { return Util.RemoveNaoNumericos(cpf); }
            set { cpf = value; }
        }

        [Required(ErrorMessage = "Informe o cliente que o beneficiário compoe")]
        public long IdCliente { get; set; }

    }
}