function alterarBeneficiario(id, nome, cpf, idcliente) {
    botaoGravar.text("Gravar");
    isInsert = false;
    codBeneficiario = id;
    $('#formCadBeneficiario .nome-beneficiario').val(nome);
    $('#formCadBeneficiario .cpf-beneficiario').val(cpf);
}

//$(".alterar-beneficiario").click(function () {
//    alert("Cheguei no alterar");
//    var id = $(this).attr("data-id");
//    var nome = $(this).attr("data-name");
//    var cpf = $(this).attr("data-cpf");
//    isInsert = false;

//    $('#formCadBeneficiario .nome-beneficiario').val(nome);
//    $('#formCadBeneficiario .cpf-beneficiario').val(cpf);

//});