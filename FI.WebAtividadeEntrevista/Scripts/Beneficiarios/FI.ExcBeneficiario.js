//$(document).ready(function () {
//    $(".delete").click(function () {
//        var url = "/Beneficiario/Excluir";
//        var id = $(this).attr("data-id");
//        alert(id);
//        $('#formCadBeneficiario #Nome').val(id);

//    $.ajax({
//        url: url,
//        data: { id: idItem },
//        datatype: "json",
//        type: "POST",
//        success: function (data) {
//            if (data.resultado) {
//                var linha = "#tr"+ idItem;
//                $(linha).fadeOut(500);
//                location.reload();
//                //abreModal();
//            }
//        }
//    })
//}