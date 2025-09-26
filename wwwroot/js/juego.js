// Selecciono todos los botones de respuesta
let botones = document.querySelectorAll('.respuesta-btn');

for (let i = 0; i < botones.length; i++) {
    botones[i].onclick = function() {

        let idRespuesta = this.getAttribute('data-id');
        let idPregunta = document.getElementById('enunciado').getAttribute('data-idPregunta');

        // Desactivar todos los botones mientras procesa
        for (let j = 0; j < botones.length; j++) {
            botones[j].disabled = true;
        }

        // Enviar POST con fetch
        fetch('/Home/VerificarRespuesta', {
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            body: 'idPregunta=' + idPregunta + '&idRespuesta=' + idRespuesta
        })
        .then(function(response) { return response.text(); })
        .then(function(html) {
            let tempDiv = document.createElement('div');
            tempDiv.innerHTML = html;

            // Leer datos de la view Respuesta
            let correcta = tempDiv.querySelector('#correcta').value === 'True';
            let respuestaCorrecta = tempDiv.querySelector('#respuestaCorrecta').value;
            let puntaje = tempDiv.querySelector('#puntajeHidden').value;

            let mensajeDiv = document.getElementById('mensaje');
            if (correcta) {
                mensajeDiv.style.color = 'green';
                mensajeDiv.innerHTML = '¡Correcto!';
            } else {
                mensajeDiv.style.color = 'red';
                mensajeDiv.innerHTML = 'Incorrecto. La correcta era: ' + respuestaCorrecta;
            }

            // Actualizar puntaje
            document.getElementById('puntaje').innerHTML = puntaje;

            // Esperar 2 segundos y pasar a la siguiente pregunta
            setTimeout(function() {
                window.location.href = '/Home/Jugar';
            }, 2000);
        });
    };
}
