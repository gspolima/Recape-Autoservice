$('.btn-outline-success').click(function (event) {
    var $clicado = $(event.target);
    $clicado.removeClass('btn-outline-success').addClass('btn-success');
});

function reservarPoltronas() {
    let $botoes = $('button');
    let $selecionados = $botoes.filter('.btn-success');
    console.log($selecionados);

    let arraySelecionados = [];

    $selecionados.each(function (index, btn) {
        let $botao = $(btn);
        arraySelecionados.push({ id: `${$botao.attr("data-poltrona-id")}` });
    });
    console.log(arraySelecionados);

    let arrayJSON = JSON.stringify(arraySelecionados);
    //console.log(arrayJSON);

    $.ajax({
        type: 'POST',
        contentType: "application/json",
        data: arrayJSON,
        url: "/api/poltronas/reservar",
    })
        .done(function (e) {
            window.location.pathname = "/Reservas/ListarReservas";
        })
        .fail(function (error) {
            console.warn(error);
            alert("Falha ao confirmar reservas.");
        });
}