let $listaServicos = $('#listaServicos');
let $selecionado = $listaServicos.find('option:selected').val();
let $valorServico = $('#valor');

if ($selecionado !== '')
    enviarRequest($selecionado);


$listaServicos.change(function () {
    let valor = $listaServicos.find('option:selected').val();
    console.log(valor);

    enviarRequest(valor);
});

function enviarRequest(valor) {
    $.ajax({
        type: "GET",
        url: `api/valorServico/${valor}`
    })
        .done(function (data) {
            $valorServico.val(data);
        })
        .fail(function (error) {
            console.error(error);
        });
}

/*---------*/

let $listaTiposVeiculo = $('#listaTipos');

$listaTiposVeiculo.blur(function () {
    let tipoSelecionado = $listaTiposVeiculo.find('option:selected').val();
    console.log(tipoSelecionado);
    enviarRequestListaServicos(tipoSelecionado);
});

function enviarRequestListaServicos(valor) {
    $.ajax({
        type: "GET",
        url: `api/listaServico/${valor}`
    })
        .done(function (data) {
            console.log(data);
            $listaServicos.children().remove();
            data.forEach(function(servico, i) {
                $listaServicos.append(`<option value='${servico.id}'>${servico.nome}</option>`);
            });
        })
        .fail(function (error) {
            console.log(error)
        });
}