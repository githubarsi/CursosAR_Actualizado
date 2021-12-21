function CompletaDomicilio() {
    var cp = $("#cp").val();
    //window.location.href = "LlenaCamposDomicilio?cp=" + cp;

    var objetos = {
        "Direccion": [
            { "Colonia": "Primera Cerrada", "Delegacion": "Miguel Hidalgo" }
        ]
    };

    $("#colonia").val("algo");
    //document.getElementById('colonia').innerHTML = objetos.Direccion[0].Colonia

}