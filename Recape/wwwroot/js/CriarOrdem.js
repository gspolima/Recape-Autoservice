const $listaServicos = $('#listaServicos');
let servicoSelecionado = $listaServicos.find('option:selected').val();
let $valorServico = $('#valor');

if (servicoSelecionado !== '')
    enviarRequest(servicoSelecionado);


$listaServicos.change(function () {
    const valor = $listaServicos.find('option:selected').val();
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

/*---------------------------------------*/

const $listaTiposVeiculo = $('#listaTipos');

$listaTiposVeiculo.blur(function () {
    let tipoSelecionado = $listaTiposVeiculo.find('option').filter(':selected').val();

    if (tipoSelecionado !== '')
        enviarRequestListaServicos(tipoSelecionado);
    else
        console.warn('Nenhum tipo selecionado');

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

/*---------------------------------------*/

let $listaVeiculos = $('#listaVeiculos');
let veiculoSelecionado = $listaVeiculos.filter('option:selected').val();
const $formularioCadastrarNovoVeiculo = $('#cadastrarNovoVeiculo');
let $camposNovoVeiculo = $formularioCadastrarNovoVeiculo.find('input');

$listaVeiculos.blur(function () {

    console.log($listaVeiculos);
    console.log(veiculoSelecionado);

    if (veiculoSelecionado !== '') {
        $camposNovoVeiculo.prop('disabled', 'disabled');
        $listaTiposVeiculo.prop('disabled', 'disabled');
    }
    else {
        $camposNovoVeiculo.removeProp('disabled');
        $listaTiposVeiculo.removeProp('disabled');
    }
        
});
