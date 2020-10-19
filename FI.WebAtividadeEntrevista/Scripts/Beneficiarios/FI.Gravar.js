var isInsert = true;
var codBeneficiario;
var botaoGravar = $(".gravar-beneficiario");

function gravarBeneficiario() {
    var codCliente = obj.Id;

    $.ajax({
        url: pegarUrl(),
        method: "POST",
        data: {
            "NOME": $("#formCadBeneficiario .nome-beneficiario").val(),
            "CPF": $("#formCadBeneficiario .cpf-beneficiario").val(),
            "IdCliente": codCliente,
            "Id": codBeneficiario
        },
        dataType: "json",
        success: function (data) {

            if (isInsert) {
                atualizaTr(data);
                //alert("Beneficiário cadastrado");
             }
            else {
                excluirLinha(codBeneficiario);
                atualizaTr(data);
                botaoGravar.text("Incluir");
                //alert("Beneficiário atualizado");
                isInsert = true;

            }

            $("#formCadBeneficiario")[0].reset();
            return false;
        },

        error: function (r) {
            if (r.status == 400)
                alert(r.responseJSON);
            else if (r.status == 500)
                alert("Ocorreu um erro: Ocorreu um erro interno no servidor.");
        }

    });
}

function atualizaTr(data) {
    var botaoAlterar = "<button type=\"button\" class=\"btn btn-primary alterar-beneficiario\" onclick=\"alterarBeneficiario('" + data.Id + "', '" + data.Nome + "', '" + data.CPF + "', '" + data.IdCliente + "')\" data-id=\"" + data.Id + "\" data-name=" + data.Nome + " data-cpf=\"" + data.CPF + " data-idcliente=\"" + data.IdCliente + "\">Alterar</button>"
    var botalExcluir = " <button type=\"button\" class=\"btn btn-primary deletar-beneficiario\" onclick=\"deletarBeneficiario('" + data.Id + "')\" data-id=\"" + data.Id  + "\">Excluir</button>";
    $('#gridBeneficiarios').append("<tr id=" + data.Id + "><td>" + data.CPF + "</td><td>" + data.Nome + "</td><td>" + botaoAlterar + botalExcluir + "</td></tr>");
}

function pegarUrl()
{
    if (isInsert)
        return urlIncluirBenef;
    else
        return urlAlterarBenef;

}


//$(".gravar-beneficiario").click(function () {//#btnGravar
//    var codCliente = obj.Id;// $("#item_IdCliente").val();
//    var codBeneficiario = obj.IdBeneficiario;
//    alert("Cliente: " + codCliente + " | Beneficiario" + codBeneficiario)
//    var urlTmp = urlIncluirBenef;
//    if (!isInsert)
//        urlTmp = urlAlterarBenef;
//    $.ajax({
//        url: urlTmp,
//        method: "POST",
//        data: {
//            "NOME": $(".nome-beneficiario").val(),
//            "CPF": $(".cpf-beneficiario").val(),
//            "IdCliente": codCliente,
//            "Id": codBeneficiario
//        },
//        dataType: "json",
//        success: function (data) {
//            var idBen = data.Id;
//            var NomeBen = data.Nome;
//            var CPFBen = data.CPF;
//            var idCliente = data.IdCliente;

//            $('#gridBeneficiarios').append("<tr><td>" + CPFBen + "</td><td>" + NomeBen + "</td><td><button type=\"button\" class=\"btn btn-primary alterar-beneficiario\" data-id=\"" + idBen + "\" data-name=" + NomeBen +
//                " data-cpf=\"" + CPFBen + " data-idcliente=\"" + idBen + "\">Alterar</button> <button type=\"button\" class=\"btn btn-primary deletar-beneficiario\" data-id=\"" + idBen + "\">Excluir</button></td></tr>");

//            $("#formCadBeneficiario")[0].reset();

//            return false;
//        },

//        error: function (r) {
//            if (r.status == 400)
//                alert(r.responseJSON);
//            else if (r.status == 500)
//                alert("Ocorreu um erro: Ocorreu um erro interno no servidor.");
//        }

//    });
//});
