function nuevo() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(100, 400); //base
    ctx.lineTo(100, 100); //base
    ctx.lineTo(300, 100);//base
    ctx.lineTo(300, 150);//base
    ctx.stroke();

}

function manoderecha() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(300, 200);//brazo der
    ctx.lineTo(325, 250);
    ctx.stroke();
}

function manoizquierda() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(300, 200);//brazo izq
    ctx.lineTo(275, 250);
    ctx.stroke();
}

function piederecho() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(300, 300);//pie der
    ctx.lineTo(275, 350);
    ctx.stroke();
}

function pieizquierdo() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(300, 300);//pie izq
    ctx.lineTo(325, 350);
    ctx.stroke();
}

function cuerpo() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(300, 200);//cuerpo
    ctx.lineTo(300, 300);
    ctx.stroke();
}

function cabeza() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.moveTo(325, 175); //cabeza
    ctx.arc(300, 175, 25, 0, 2 * Math.PI); //cabeza
    ctx.stroke();
}

function ahorcar() {
    var c = document.getElementById("myCanvas");
    var ctx = c.getContext("2d");
    ctx.strokeStyle = 'red';
    ctx.moveTo(275, 200);//ahorca   
    ctx.lineTo(325, 200);
    ctx.stroke();
}

function iniciarjuego() {
    var ai = document.getElementById("areainicio");
    var aj = document.getElementById("areajuego");
    ai.hidden = true;
    aj.hidden = false;
}

function juegoterminado() {
    var aj = document.getElementById("areajuego");
    var ar = document.getElementById("areareset");
    aj.hidden = true;
    ar.hidden = false;
}
