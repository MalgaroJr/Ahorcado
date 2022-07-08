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

function grafica(div, lista, total) {
    const doc = document.getElementById(titulo);
    if (lista.length == 2) {
        let circ1 = document.createElement("circle");
        circ1.setAttribute('r', 10);
        circ1.setAttribute('cx', 10);
        circ1.setAttribute('cy', 10);
        circ1.setAttribute('fill', 'green');
        doc.appendChild(circ1);
        let circ2 = document.createElement("circle");
        circ2.setAttribute('r', 10);
        circ2.setAttribute('cx', 10);
        circ2.setAttribute('cy', 10);
        circ2.setAttribute('fill', 'transparent');
        circ2.setAttribute('stroke', 'red');
        circ2.setAttribute('stroke-width', 10);
        circ2.setAttribute('srotke-dasharray', (lista[1]*31.42/100)*31.42);
        doc.appendChild(circ2);
    } else {
        const colors = ['darkred', 'red', 'orange', 'yellow', 'lightblue', 'forestgreen', 'green', 'blue']
        var giro = ((lista[7]*100 / total) * 31.42 / 100) * 31.42;
        let circ = document.createElement("circle");
        circ.setAttribute('r', 10);
        circ.setAttribute('cx', 10);
        circ.setAttribute('cy', 10);
        circ.setAttribute('fill', 'blue');
        doc.appendChild(circ);
        for (var i = 0; i < 7; i++) {
            let circ = document.createElement("circle");
            circ.setAttribute('r', 10);
            circ.setAttribute('cx', 10);
            circ.setAttribute('cy', 10);
            circ.setAttribute('fill', 'transparent');
            circ.setAttribute('stroke-width', 10);
            circ.setAttribute('srotke-dasharray', giro);
            circ.setAttribute('stroke', colors[i]);
            doc.appendChild(circ);
            giro += ((lista[i] * 100 / total) * 31.42 / 100) * 31.42;
        }
    }
}