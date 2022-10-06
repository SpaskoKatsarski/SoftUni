function notify(message) {
  let div = document.getElementById('notification');

  div.textContent = message;
  div.style.display = 'block';

  div.addEventListener('click', hideText);

  function hideText() {
    div.style.display = 'none';
  }
}