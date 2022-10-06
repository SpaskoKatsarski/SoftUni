function validate() {
    let passwordPattern = /\w+/g;

    let usernameInput = document.getElementById('username');
    let emailInput = document.getElementById('email');
    let passwordInput = document.getElementById('password');
    let confirmPasswordInput = document.getElementById('confirm-password');

    let isCompanyCheckBox = document.getElementById('company');

    let companyFieldSet = document.getElementById('companyInfo');
    companyFieldSet.style.display = 'none';

    let companyInput = document.getElementById('companyNumber');
    companyInput.style.border = 'none';

    let validDiv = document.getElementById('valid');

    isCompanyCheckBox.addEventListener('change', () => {
        let state = companyFieldSet.style.display === 'block' ? 'none': 'block';
        companyInput.value = '';
        companyFieldSet.style.display = state;
    });
    
    let submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', validate);

    function validate(e) {
        e.preventDefault();

        let username = usernameInput.value
        let password = passwordInput.value;
        let confirmPass = confirmPasswordInput.value;
        let email = emailInput.value;
        let companyNumber = companyInput.value;

        if (username.length < 3 || username.length > 20) {
            usernameInput.style.border = '';
            usernameInput.style.borderColor = 'red';
        } else {
            usernameInput.style.border = 'none';
        }

        if (password.length < 3 || password.length > 15 || !password.match(passwordPattern)) {
            passwordInput.style.border = '';
            confirmPasswordInput.style.border = '';

            passwordInput.style.borderColor = 'red';
            confirmPasswordInput.style.borderColor = 'red';
        } else {
            passwordInput.style.border = 'none';
        }

        if (confirmPass !== password) {
            confirmPasswordInput.style.border = '';
            confirmPasswordInput.style.borderColor = 'red';
        } else {
            confirmPasswordInput.style.border = 'none';
        }

        if (!email.includes('\@') || !email.substring(email.indexOf('\@')).includes('\.')) {
            emailInput.style.border = '';
            emailInput.style.borderColor = 'red';
        } else {
            emailInput.style.border = 'none';
        }

        if (isCompanyCheckBox.checked) {
            if (companyNumber < 1000 || companyNumber > 9999) {
                companyInput.style.border = '';
                companyInput.style.borderColor = 'red';
            } else {
                companyInput.style.border = 'none';
            }
        } else {
            companyInput.style.border = 'none';
        }

        let isCorrect = false;

        if (usernameInput.style.border === 'none' && 
        emailInput.style.border === 'none' &&
        passwordInput.style.border === 'none' &&
        companyInput.style.border === 'none') {
            if (isCompanyCheckBox.checked) {
                if (companyInput.style.border === 'none') {
                    isCorrect = true;
                } else {
                    isCorrect = false;
                }
            } else {
                isCorrect = true;
            }
        } 

        if (isCorrect) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }
    }
}