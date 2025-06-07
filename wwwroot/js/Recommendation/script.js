// Efecto al enviar el formulario
document.querySelector('.recommendation-form')?.addEventListener('submit', function() {
    const button = this.querySelector('button');
    if (button) {
        button.innerHTML = `<i class="bi bi-hourglass"></i> Generando...`;
        button.disabled = true;
        button.classList.add('loading');
    }
});

// Validación básica del input
document.querySelector('input[name="userId"]')?.addEventListener('input', function(e) {
    this.value = this.value.toUpperCase(); // Forzar mayúsculas
});