var id = 0;
$(document).ready(function () {
    cargarInfo();
});

var cargarInfo = function () {
    $.ajax({
        url: "Actualizar.aspx/MostrarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        success: function (respuesta) {
            id = respuesta.d[0].IduCliente;

            $("#nombre").val(respuesta.d[0].Nombre);
            $("#apellido_paterno").val(respuesta.d[0].ApellidoPaterno);
            $("#apellido_materno").val(respuesta.d[0].ApellidoMaterno);
            $("#correo").val(respuesta.d[0].Correo);

            if (respuesta.d[0].Correo != null || respuesta.d[0].Nombre != "") {
                $("#lblNombre").addClass("active");
            }

            if (respuesta.d[0].Correo != null || respuesta.d[0].ApellidoPaterno != "") {
                $("#lblApellidoPaterno").addClass("active");
            }

            if (respuesta.d[0].Correo != null || respuesta.d[0].ApellidoMaterno != "") {
                $("#lblApellidoMaterno").addClass("active");
            }

            if (respuesta.d[0].Correo != null || respuesta.d[0].Correo != "") {
                $("#lblCorreo").addClass("active");
            }
        },
        error: function (respuesta) {
        }
    });
};

var actualizar = function (event) {
    event.preventDefault();

    var cliente = {};
    cliente.IduCliente = id;
    cliente.Nombre = $("#nombre").val();
    cliente.ApellidoPaterno = $("#apellido_paterno").val();
    cliente.ApellidoMaterno = $("#apellido_materno").val();
    cliente.Correo = $("#correo").val();

    $.ajax({
        url: "Actualizar.aspx/ActualizarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ cliente: cliente }),
        success: function (respuesta) {
            Materialize.toast('Información guardada correctamente.', 5000);
            setTimeout(function () { location.href = "Lista.aspx", 5000 });
        },
        error: function (respuesta) {
        }
    });

    return true;
};
