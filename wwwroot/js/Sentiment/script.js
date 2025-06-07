// Validación básica del textarea (opcional)
document.querySelector('.sentiment-form')?.addEventListener('submit', function(e) {
    const textarea = this.querySelector('textarea');
    if (textarea.value.trim() === '') {
        e.preventDefault();
        textarea.focus();
        // Puedes agregar un mensaje de error dinámico aquí si lo deseas
    }
});

// Efecto de carga (simulado para mejorar la experiencia)
document.querySelector('.sentiment-form')?.addEventListener('submit', function() {
    const button = this.querySelector('button');
    if (button) {
        button.innerHTML = `<i class="bi bi-hourglass"></i> Analizando...`;
        button.disabled = true;
    }
});