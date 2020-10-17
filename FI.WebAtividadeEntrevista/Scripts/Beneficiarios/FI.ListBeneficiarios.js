﻿$(document).ready(function () {

    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable({
            title: 'Beneficiarios',
            paging: true, //Enable paging
            pageSize: 5, //Set page size (default: 10)
            sorting: true, //Enable sorting
            defaultSorting: 'Nome ASC', //Set default sorting
            actions: {
                listAction: urlBeneficiarioList,
            },
            fields: {
                Nome: {
                    title: 'CPF',
                    width: '35%'
                },
                Email: {
                    title: 'Nome',
                    width: '50%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlAlteracaoBene + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                },
                 Excluir: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlExclusaoBene + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Exclir</button>';
                    }
                }
            }
        });

    //Load student list from server
    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable('load');
})