$('[data-toggle="tooltip"]').tooltip();

let $botao = $('.btn-cancelar');

$botao.click(function (event) {
    let $target = $(event.target);

    let osId = $target.attr('data-os-id');

    $.ajax({
        type: "POST",
        url: `api/cancelar/${osId}`,
    })
        .done(function (e) {
            let $icone = "<i class='text-danger fas fa-times-circle fa-lg'></i>";
            console.log("Request para cancelar concluída com sucesso");
            $target.parents('tr').css("background-color", "#ffccc4").children('td:last').append('Cancelado').parent().find('a').remove();
        })
        .fail(function (error) {
            console.error(error);
        });
});