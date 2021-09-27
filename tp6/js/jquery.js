$(document).ready(() => {
    $('button[type="submit"]').on('click', (e) => {
        e.preventDefault();
        
        const name = $('input#name').val();
        const surname = $('input#surname').val();
        if (!name || !surname) alert('Nombre/Apellido no válido/s');
    });

    $('div.footer').append('<button type="reset">Reset</button>');

    $('button[type="reset"]').on('click', (e) => {
        e.preventDefault();

        $('form').trigger('reset');
    });
});