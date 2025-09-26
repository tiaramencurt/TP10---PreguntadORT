// Selecciono todos los botones de respuesta
var botones = document.querySelectorAll('.respuesta-btn');

for (var i = 0; i < botones.length; i++) {
    botones[i].onclick = function() {

        var idRespuesta = this.getAttribute('data-id');
        var idPregunta = document.getElementById('enunciado').getAttribute('data-idPregunta');

        // Desactivar todos los botones mientras procesa
        for (var j = 0; j < botones.length; j++) {
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
            var tempDiv = document.createElement('div');
            tempDiv.innerHTML = html;

            // Leer datos de la view Respuesta
            var correcta = tempDiv.querySelector('#correcta').value === 'True';
            var respuestaCorrecta = tempDiv.querySelector('#respuestaCorrecta').value;
            var puntaje = tempDiv.querySelector('#puntajeHidden').value;

            var mensajeDiv = document.getElementById('mensaje');
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
