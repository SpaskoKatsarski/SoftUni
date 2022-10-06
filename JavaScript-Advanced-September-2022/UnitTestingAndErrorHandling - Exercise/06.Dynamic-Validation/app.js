function validate() {
    let emailPattern = /[a-z]+@[a-z]+.[a-z]+/g;

    let emailBox = document.getElementById('email');
    emailBox.addEventListener('change', validateText);

    function validateText(e) {
        if (!e.target.value.match(emailPattern)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    }
}