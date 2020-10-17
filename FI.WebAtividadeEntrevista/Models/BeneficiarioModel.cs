using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Beneficiario
    /// </summary>
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required(ErrorMessage ="CPF obrigatório")]
        //✓ Deverá consistir se o dado informado é um CPF válido(conforme o cálculo padrão de verificação do dígito verificador de CPF)
        //✓ Não permitir o cadastramento de um CPF já existente no banco de dados, ou seja, não é permitida a existência de um CPF duplicad 
        [RegularExpression(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$", ErrorMessage = "Digite um CPF válido")]
        public string CPF { get; set; }

        [Required(ErrorMessage ="Informe o cliente que o beneficiário compoe")]
        public long IdCliente { get; set; }

    }
}