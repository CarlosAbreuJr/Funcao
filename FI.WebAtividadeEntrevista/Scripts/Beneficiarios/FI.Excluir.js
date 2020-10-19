function deletarBeneficiario(id) {
    if (!isInsert) {
        isInsert = true;
        codBeneficiario = 0;
        botaoGravar.text("Incluir");

        $("#formCadBeneficiario")[0].reset();
    }

    $.ajax({
        type: "POST",
        url: urlExcluirBenef,
        data: { id: id },
        dataType: "json",
        success: function () {
            excluirLinha(id);
            //alert("Beneficiário excluido");
        },
        error: function () {
            alert("Erro ao deletar beneficiário");
        }
    });
}

function excluirLinha(id)
{
    document.getElementById(id).remove();
}
//$(".deletar-beneficiario").click(function () {
//    var id = $(this).attr("data-id");
//    if (!isInsert) {
//        isInsert = true;
//        $("#formCadBeneficiario")[0].reset();
//    }

//    $.ajax({
//        type: "POST",
//        url: urlExcluirBenef,
//        data: { id: id },
//        dataType: "json",
//        success: function () {
//            $('#' + id).remove();
//        },
//        error: function () {
//            alert("Erro ao deletar beneficiário");
//        }
//    });
//});