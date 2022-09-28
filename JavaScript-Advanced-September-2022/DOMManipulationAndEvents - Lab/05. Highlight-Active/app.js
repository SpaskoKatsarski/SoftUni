function focused() {
    let divs = document.getElementsByTagName('input');

    for (const el of divs) {
        el.addEventListener('focus', addFocus);
        el.addEventListener('blur', removeFocus);
    }

    function addFocus(event) {
        event.target.parentElement.classList.add('focused');
    }

    function removeFocus(event) {
        event.target.parentElement.classList.remove('focused');
    }
}