$(document).ready(function () {

    if (($("#resultado").val() != ""))
    {
        muestraDiv($("#resultado").val());
    }  

    $("#eMail").blur(function (evento) {

        var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

        if (!(regex.test($('#eMail').val().trim())))
        {
            $("#eMail").css("background-color", "red");
            $("#eMail").css("color", "white");
            muestraDiv("El correo no es un formato válido");
        }

    });

    $("#nombre").focus(function (evento) {

        $("#nombre").css("background-color", "white");
        $("#nombre").css("color", "black");
        $("#nombre").val("");
        ocultaDiv();
    });

    $("#eMail").focus(function (evento) {

        $("#eMail").css("background-color", "white");
        $("#eMail").css("color", "black");
        $("#eMailc").css("background-color", "white");
        $("#eMailc").css("color", "black");
        $("#eMailc").val("");
        ocultaDiv();
    });

    $("#eMailC").blur(function (evento) {

        var valueMail = $("#eMail").val();
        var valueMailc = $("#eMailC").val();

        if (valueMail != valueMailc) {
            $("#eMailC").css("background-color", "red");
            $("#eMailC").css("color", "white");
            muestraDiv("La confirmación del correo no coincide con el correo escrito");
        }
    });

    $("#eMailC").focus(function () {
        $("#eMailC").css("background-color", "white");
        $("#eMailC").css("color", "black");
        $("#eMailC").val("");
        ocultaDiv();
    });

    $("#cp").focus(function () {
        $("#cp").css("background-color", "white");
        $("#cp").css("color", "black");
        $("#cp").val("");
        ocultaDiv();
    });

    $("#contrasenaC").blur(function (evento) {

        var valueMail = $("#contrasena").val();
        var valueMailc = $("#contrasenaC").val();

        if (valueMail != valueMailc) {
            $("#contrasenaC").css("background-color", "red");
            $("#contrasenaC").css("color", "white");
            muestraDiv("La confirmación debe de ser igual a la contraseña");
        }
        else {
            ocultaDiv();
        }
    });

    $("#contrasenaC").focus(function () {
        $("#contrasenaC").css("background-color", "white");
        $("#contrasenaC").css("color", "black");
        ocultaDiv();
    });

    $("#calle").focus(function () {
        $("#calle").css("background-color", "white");
        $("#calle").css("color", "black");
        ocultaDiv();
    });

    $("#numExt").focus(function () {
        $("#numExt").css("background-color", "white");
        $("#numExt").css("color", "black");
        ocultaDiv();
    });

    $("#contrasena").blur(function (evento) {

        var value = $("#contrasena").val();

        if (value.length < 8)
        {
            $("#contrasena").css("background-color", "red");
            $("#contrasena").css("color", "white");
            muestraDiv("La longitud de la contraseña debe de ser igual o mayor a 8 caracteres");
        }

    });

    $("#contrasena").focus(function () {
        $("#contrasena").css("background-color", "white");
        $("#contrasena").css("color", "black");
        $("#contrasena").val("");
        $("#contrasenaC").css("background-color", "white");
        $("#contrasenaC").css("color", "black");
        $("#contrasenaC").val("");
        ocultaDiv();
    });

    $("#cp").blur(function (evento) {

        $.ajax({
            type: "GET",
            url: "/Home/LlenaCamposDomicilio",
            data: { cp: $(this).val() }
        }).done(function (data) {
            $("#Colonia").val(data["Colonia"]);
            $("#Municipio").val(data["Municipio"]);
            $("#Estado").val(data["Estado"]);
        });  

    });

    $("#TelContacto").blur(function (evento) {

        var celw = $("#TelWhats").val();

        if (celw.length == 0) {
            $("#TelWhats").val($("#TelContacto").val());
        }
    });

    $("#TelContacto").focus(function () {
        $("#TelContacto").css("background-color", "white");
        $("#TelContacto").css("color", "black");
        ocultaDiv();
    });

    $("#ckhPrivacidad").click(function (evento) {
        $("#linkAviso").css("background-color", "white");
        ocultaDiv();
    });

    $("#btnRegistrar").click(function (evento) {

        var numero = 0;
        var nombre = $("#nombre").val();
        var eMail = $("#eMail").val();
        var eMailC = $("#eMailC").val();
        var contrasena = $("#contrasena").val();
        var contrasenaC = $("#contrasenaC").val();
        var TelContacto = $("#TelContacto").val();
        var cp = $("#cp").val();
        var calle = $("#calle").val();
        var numExt = $("#numExt").val();
        var colonia = $("#Colonia").val();

        if (nombre.length == 0) {
            $("#nombre").css("background-color", "red");
            numero = numero + 1;
        }

        if (eMail.length == 0) {
            $("#eMail").css("background-color", "red");
            numero = numero + 1;
        }

        if (eMailC.length == 0) {
            $("#eMailC").css("background-color", "red");
            numero = numero + 1;
        }

        if (contrasena.length == 0) {
            $("#contrasena").css("background-color", "red");
            numero = numero + 1;
        }

        if (contrasenaC.length == 0) {
            $("#contrasenaC").css("background-color", "red");
            numero = numero + 1;
        }

        if (TelContacto.length == 0) {
            $("#TelContacto").css("background-color", "red");
            numero = numero + 1;
        }

        if (cp.length == 0) {
            $("#cp").css("background-color", "red");
            numero = numero + 1;
        }

        if (calle.length == 0) {
            $("#calle").css("background-color", "red");
            numero = numero + 1;
        }

        if (numExt.length == 0) {
            $("#numExt").css("background-color", "red");
            numero = numero + 1;
        }

        if (colonia.length == 0) {
            $("#cp").css("background-color", "red");
            numero = numero + 1;
        }

        if ($("#ckhPrivacidad").prop('checked') == false) {
            $("#linkAviso").css("background-color", "red");
            numero = numero + 1;
        }

        if (numero == 0) {
            document.frmRegistro.submit();
        }
        else {
            muestraDiv("Llene los campos marcados en rojo o verifique que sean válidos");
        }

    });

    function muestraDiv(mensaje) {
        $("#dvMessage").css("visibility", "visible");
        $("#lblMessage").html(mensaje);
    }

    function ocultaDiv() {
        $("#dvMessage").css("visibility", "hidden");
        $("#lblMessage").html("");
        $("#resultado").val("");
    }

});