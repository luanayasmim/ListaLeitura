
//Configurando os alerts
$('#close-alert').click(function () {
    $('.alert').hide('hide');
});

//Configurando tabela
$(document).ready(function () {

    getDatatable('#table-books');
    getDatatable('#table-users');
    //Modal
    $('.btn-total-livros').click(function () {
        var userId = $(this).attr("user-id");
        console.log(userId);

        //Ajax
        $.ajax({
            type: 'GET',
            url: '/User/ListBooksFromUserId/' + userId,
            success: function (result) {
                $('#BooksList').html(result);
                $('#modalBooksUser').modal();
                getDatatable('#table-books-user');
            }
        });
    });
});

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}