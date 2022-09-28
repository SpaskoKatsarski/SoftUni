function attachGradientEvents() {
    let div = document.getElementById('result');
    document.getElementById('gradient').addEventListener('mousemove', function(event) {
        let result = Math.floor(event.offsetX / 3) + '%';
        div.textContent = result;
    });
}