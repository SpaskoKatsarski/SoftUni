function validate() {
    document.getElementById('email').addEventListener('change', validate);

    function validate(event) {
        let validateEmail = (email) => {
            return String(email)
                .toLowerCase()
                .match(
                    /^([\w\-.]+)@([a-z]+)(\.[a-z]+)+$/
                );
        };

        let email = document.getElementsByTagName('input')[0].value;

        if (!validateEmail(email)) {
            event.target.classList.add('error');
        } else {
            event.target.classList.remove('error');
        }
    }
}