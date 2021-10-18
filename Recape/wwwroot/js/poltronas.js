export default function Poltronas() {
    $('.btn-outline-success').click(function (event) {
        var $clicado = $(event.target);
        $clicado.removeClass('btn-outline-success').addClass('btn-success');
    });
}