$(document).ready(function () {
    cargarInfo();
});

var cargarInfo = function () {
    $.ajax({
        url: "Lista.aspx/MostrarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        success: function (respuesta) {
            $("#gridClientes").dataTable({
                "aaData": respuesta.d,
                "pageLength": 10,
                "bDestroy": true,
                "language": {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                "aoColumns": [
                    { "mData": "IduCliente", "sTitle": "iduCliente", "sClass": "id" },
                    { "mData": "Nombre", "sTitle": "Nombre" },
                    { "mData": "ApellidoPaterno", "sTitle": "Apellido Paternos" },
                    { "mData": "ApellidoMaterno", "sTitle": "Apellido Materno" },
                    { "mData": "Correo", "sTitle": "Correo" },
                    {
                        "mData": null, "sTitle": "Acción", "bSortable": false,
                        "mRender": function (respuesta) {
                            return accion(respuesta.IduCliente);
                        }
                    }
                ]
            });
        },
        error: function (respuesta) {
        }
    });
};

var accion = function (id) {
    var htmlAccion = "";
    htmlAccion += "<a class='btn-floating waves-effect waves-light light-blue' onclick='return editar(" + id + ");'>";
    htmlAccion += "<i class='material-icons'>edit</i>";
    htmlAccion += "</a>&nbsp;&nbsp;";
    htmlAccion += "<a class='btn-floating waves-effect waves-light red accent-2' onclick='return eliminar(" + id + ");'>";
    htmlAccion += "<i class='material-icons'>delete</i>";
    htmlAccion += "<a/>";

    return htmlAccion;
};

var editar = function (id) {
    event.preventDefault();

    $.ajax({
        url: "Lista.aspx/ActualizarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ iduCliente: id }),
        success: function (respuesta) {
            window.location.href = respuesta.d;
        },
        error: function (respuesta) {
        }
    });

    return true;
};

var eliminar = function (id) {
    event.preventDefault();

    $.ajax({
        url: "Lista.aspx/EliminarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ iduCliente: id }),
        success: function (respuesta) {
            window.location.href = respuesta.d;
        },
        error: function (respuesta) {
        }
    });

    return true;
};