$(document).ready(function () {
    pegarValor();
});

//$('#inputDatabaseName').on('input', function (e) {
//    if ($('#inputDatabaseName').val() == "OK")
//        reinicio();
//    if ($('#inputDatabaseName').val() == "I")
//        inicio();
//    if ($('#inputDatabaseName').val() == "F")
//        parar();
//});
function pegarValor() {
    var c = setInterval(arduino, 1000);
}
//function arduino() {
//    var v="r";
//    $('#inputDatabaseName').val(v);
//}
function arduino() {
    var va = $("#inputDatabaseName2").val();
    var url = "/Tempo/LeituraSerial";
    $.get(url, null, function (data) {
        $("#inputDatabaseName").val(data);
    });

    var vd = $("#inputDatabaseName").val();

    if (vd == "OK")
    { //reinicio();
    }
    if (vd == "I" && vd!=va)
    {
        inicio();
        $("#inputDatabaseName2").val("I");
    }
    if (vd == "F")
        parar();

}

var centesimas = 0;
var segundos = 0;
var minutos = 0;
var horas = 0;
function inicio() {
    control = setInterval(cronometro, 10);
    document.getElementById("inicio").disabled = true;
    document.getElementById("parar").disabled = false;
    document.getElementById("continuar").disabled = true;
    document.getElementById("reinicio").disabled = false;
}
function parar() {
    clearInterval(control);
    document.getElementById("parar").disabled = true;
    document.getElementById("continuar").disabled = false;
}
function reinicio() {
    clearInterval(control);
    centesimas = 0;
    segundos = 0;
    minutos = 0;
    horas = 0;
    Centesimas.innerHTML = ":00";
    Segundos.innerHTML = ":00";
    Minutos.innerHTML = ":00";
    Horas.innerHTML = "00";
    document.getElementById("inicio").disabled = false;
    document.getElementById("parar").disabled = true;
    document.getElementById("continuar").disabled = true;
    document.getElementById("reinicio").disabled = true;
    $('#tempo1').val(Horas.innerText + Minutos.innerText + Segundos.innerText + Centesimas.innerText);
}
function cronometro() {
    var time = "";
    if (centesimas < 99) {
        centesimas++;
        if (centesimas < 10) { centesimas = "0" + centesimas }
        Centesimas.innerHTML = ":" + centesimas;
    }
    if (centesimas == 99) {
        centesimas = -1;
    }
    if (centesimas == 0) {
        segundos++;
        if (segundos < 10) { segundos = "0" + segundos }
        Segundos.innerHTML = ":" + segundos;
    }
    if (segundos == 59) {
        segundos = -1;
    }
    if ((centesimas == 0) && (segundos == 0)) {
        minutos++;
        if (minutos < 10) { minutos = "0" + minutos }
        Minutos.innerHTML = ":" + minutos;
    }
    if (minutos == 59) {
        minutos = -1;
    }
    if ((centesimas == 0) && (segundos == 0) && (minutos == 0)) {
        horas++;
        if (horas < 10) { horas = "0" + horas }
        Horas.innerHTML = horas;

    }
    $('#tempo1').val(Horas.innerText + Minutos.innerText + Segundos.innerText + Centesimas.innerText);
    //$('#tempo2').val(Horas.innerText + Minutos.innerText + Segundos.innerText + Centesimas.innerText);
}