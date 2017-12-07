var id = 0;
$(document).ready(function () {
    cargarInfo();
});

var cargarInfo = function () {
    $.ajax({
        url: "Eliminar.aspx/MostrarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        success: function (respuesta) {
            id = respuesta.d[0].IduCliente;

            $("#nombre").val(respuesta.d[0].Nombre);
            $("#apellido_paterno").val(respuesta.d[0].ApellidoPaterno);
            $("#apellido_materno").val(respuesta.d[0].ApellidoMaterno);
            $("#correo").val(respuesta.d[0].Correos);

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

var eliminar = function (event) {
    event.preventDefault();

    $.ajax({
        url: "Eliminar.aspx/EliminarInfo",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ iduCliente: id }),
        success: function (respuesta) {
            Materialize.toast('Información guardada correctamente.', 5000);
            setTimeout(function () { location.href = "Lista.aspx", 5000 });
        },
        error: function (respuesta) {
        }
    });

    return true;
};
