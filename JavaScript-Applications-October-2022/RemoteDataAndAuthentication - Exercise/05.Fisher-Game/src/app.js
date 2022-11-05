window.addEventListener('DOMContentLoaded', onLoadHTML)

function onLoadHTML() {
    const token = sessionStorage.getItem('accessToken');

    if (token) {
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('guest').style.display = 'inline-block';
    }
}