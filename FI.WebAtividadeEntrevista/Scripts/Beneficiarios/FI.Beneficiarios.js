$(document).ready(function () {
    $('#formCadBeneficiario').submit(function (e) {
        e.preventDefault();
        $.ajax({
            //url: urlPost,
            url: "Incluir",
            method: "POST",
            data: {
                "CPF": $(this).find("#CPF").val(),
                "NOME": $(this).find("#Nome").val(),
                "IdCliente": $(this).find("#IdCliente").val()
            },
            error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success:
            function (r) {
                ModalDialog("Sucesso!", r)
                $("#formCadBeneficiario")[0].reset();
            }
        });
    })

    $(".alterar").click(function () {
            var id = $(this).attr("data-id");
            var nome = $(this).attr("data-name");
            var cpf = $(this).attr("data-cpf");
            //alert(id);
            $('#formCadBeneficiario #Nome').val(nome);
            $('#formCadBeneficiario #CPF').val(cpf);
        });

     $(".delete").click(function () {
            var id = $(this).attr("data-id");
            alert('Excluindo o item ' + id);
            //$('#formCadBeneficiario #Nome').val(id);
            $.ajax({
                type: "POST",
                //url: '@Url.Action("Excluir")',
                url: "Excluir",
                data: { id: id },
                dataType: "json",
                success: function () {

                    var linha = id;
                    $(linha).fadeOut(40);

                    setTimeout(function () {
                        location.reload();
                    },
                        1000);
                },
                error: function () {
                    alert("Error while deleting data");
                }
            });
        });

})

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}
