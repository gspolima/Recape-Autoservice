$(document).ready(function () {
    const $listaServicos = $('#listaServicos');
    let servicoSelecionado = $listaServicos.find('option:selected').val();
    let $valorServico = $('#valor');

    if (servicoSelecionado !== '')
        getValorDoServico(servicoSelecionado);


    $listaServicos.change(function () {
        const valor = $listaServicos.find('option:selected').val();
        console.log(valor);
        getValorDoServico(valor);
        
        getDataPrevistaDeConclusao(valor);
    });

    function getValorDoServico(valor) {
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

    function getDataPrevistaDeConclusao(valor) {
        $.ajax({
            type: "GET",
            url: `api/dataPrevistaServico/${valor}`
        })
            .done(function (data) {
                let dataPrevista = new Date(data);
                let opcoes = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
                let formatada = dataPrevista.toLocaleDateString("pt-BR", opcoes);
                console.log(formatada);

                $fieldSetDetalhesServico.find('#alertaPrevisao').remove();
                $fieldSetDetalhesServico.append($alerta);
                $alerta.text(`Previsão de conclusão para ${formatada}`);
            })
            .fail(function (error) {
                console.error(error);
            })
    }

    /*---------------------------------------*/

    let $listaTiposVeiculo = $("#listaTipos");
    let tipoSelecionado = "";

    $listaTiposVeiculo.blur(function () {
        tipoSelecionado = $listaTiposVeiculo.find('option').filter(':selected').val();

        if (tipoSelecionado !== '') {
            enviarRequestListaServicos(tipoSelecionado);
            console.log(tipoSelecionado);

            $listaVeiculos.prop("disabled", "disabled").val("");
        }
        else {
            $listaVeiculos.removeAttr("disabled");
            console.warn('Nenhum tipo selecionado');
        }

    });

    function enviarRequestListaServicos(tipoDeVeiculo) {
        $.ajax({
            type: "GET",
            url: `api/listaServico/${tipoDeVeiculo}`
        })
            .done(function (data) {
                console.log(data);
                $listaServicos.children().remove();
                $listaServicos.append("<option value=''>--- Selecione ---</option>");
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
    
    const $formularioCadastrarNovoVeiculo = $('#cadastrarNovoVeiculo');
    let $camposNovoVeiculo = $formularioCadastrarNovoVeiculo.find('input');

    $listaVeiculos.blur(function () {

        let veiculoSelecionado = $listaVeiculos.find("option:selected");
        console.log(veiculoSelecionado.text());

        if (veiculoSelecionado.val() !== "") {
            $camposNovoVeiculo.prop('disabled', 'disabled').val("");
            $listaTiposVeiculo.prop('disabled', 'disabled').val("");

            if (veiculoSelecionado.text().startsWith("Carro"))
                enviarRequestListaServicos("Carro");
            else
                enviarRequestListaServicos("Moto");

            $listaServicos.val("");
        }
        else {
            $camposNovoVeiculo.removeAttr('disabled');
            $listaTiposVeiculo.removeAttr('disabled');

            $listaServicos.children().remove();
            $listaServicos.append("<option value=''>--- Selecione ---</option>");
        }
        
    });
});

/*---------------------------------------*/

let $alerta = $("<div id='alertaPrevisao' class='alert alert-primary' role='alert'></div>");
let $fieldSetDetalhesServico = $('#detalhesServico');

