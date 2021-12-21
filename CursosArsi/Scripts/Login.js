$(document).ready(function ()
{

    if (($("#usr").val() != "") && ($("#usr").val() != "0") && ($("#usr").val() != "-2") && ($("#usr").val() != "-3")) {
        $("#dvMessage").css("visibility", "visible");
        $("#lblMessage").html("Escriba usuario y contraseña válido");
    }    

    if ($("#usr").val() == "0") {
        $("#dvMessage").css("visibility", "visible");
        $("#lblMessage").html("El tiempo para responder la encuesta ha expirado");
        $("#usr").val("");
    }  

    if ($("#usr").val() == "-2") {
        $("#dvMessage").css("visibility", "visible");
        $("#lblMessage").html("La encuesta fue respondida con anterioridad");
        $("#usr").val("");
    }  

    if ($("#usr").val() == "-3") {
        $("#dvMessage").css("visibility", "visible");
        $("#lblMessage").html("El usuario ya cuenta con registro en el sistema");
        $("#usr").val("");
    } 

    $("#usr").focus(function () {
        $("#dvMessage").css("visibility", "hidden");
    });

    $("#pwd").focus(function () {
        $("#dvMessage").css("visibility", "hidden");
    });

});