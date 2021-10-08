export default function Home() {
    let $enviarMensagemForm = $('#contato-form');
    let $enviarMensagemAlerta = $('#mensagem-sucesso');
    $enviarMensagemAlerta.hide();

    $enviarMensagemForm.submit(function (event) {
        event.preventDefault();

        let nome = $('#nome').val();
        let email = $('#email').val();
        let assunto = $('#assunto').val();
        let mensagem = $('#mensagem').val();

        if (nome && email && assunto && mensagem) {
            $enviarMensagemAlerta.fadeIn(function () {
                setTimeout(function () {
                    $enviarMensagemAlerta.fadeOut(200);
                }, 2500);
            });
        }
    });
}