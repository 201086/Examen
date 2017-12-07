var agregar = function (event) {
    event.preventDefault();

    var cliente = {};
    cliente.Nombre = $("#nombre").val();
    cliente.ApellidoPaterno = $("#apellido_paterno").val();
    cliente.ApellidoMaterno = $("#apellido_materno").val();
    cliente.Correo = $("#correo").val();

    $.ajax({
        url: "Agregar.aspx/AgregarInfo",
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