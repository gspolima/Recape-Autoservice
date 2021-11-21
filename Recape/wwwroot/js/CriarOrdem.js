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
            $valorServico.text(`R$ ${data}`);
        })
        .fail(function (error) {
            console.error(error);
        });
}