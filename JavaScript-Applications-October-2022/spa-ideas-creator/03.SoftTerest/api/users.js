import { views } from '../router.js';
//TODO uncomment the resets
const registerUrl = 'http://localhost:3030/users/register';
const loginUrl = 'http://localhost:3030/users/login';
const logoutUrl = 'http://localhost:3030/users/logout';

document.getElementById('logoutNav').addEventListener('click', onLogout);

async function onLogout() {
    const data = await logout();
    
    if (data.ok) {
        sessionStorage.removeItem('user');
    }

    views.home();
    views.checkUserNav();
}

async function logout() {
    const token = JSON.parse(sessionStorage.getItem('user')).accessToken;

    const response = await fetch(logoutUrl, {
        'X-Authorization': token
    });
    const data = await response.json();

    return data;
}

export async function onLogin(e) {
    debugger;
    e.preventDefault();
    const formData = new FormData(e.target);
    const { email, password } = Object.fromEntries(formData);

    // document.getElementById('register-form').reset();

    if (email.length < 3) {
        throw new Error('The email should be at least 3 characters long');
    }

    if (password.length < 3) {
        throw new Error('The password should be at least 3 characters long');
    }

    const user = await register({ email, password }, loginUrl);
    sessionStorage.setItem('user', JSON.stringify(user));

    views.home();
    views.checkUserNav();
}

export async function onRegister(e) {
    debugger;
    e.preventDefault();
    const formData = new FormData(e.target);
    const { email, password, repeatPassword } = Object.fromEntries(formData);

    // document.getElementById('register-form').reset();

    if (email.length < 3) {
        throw new Error('The email should be at least 3 characters long');
    }

    if (password.length < 3) {
        throw new Error('The password should be at least 3 characters long');
    }

    if (password !== repeatPassword) {
        throw new Error('The repeat password should be equal to the password');
    }

    const user = await register({ email, password }, registerUrl);
    sessionStorage.setItem('user', JSON.stringify(user));

    views.home();
    views.checkUserNav();
}

async function register(body, url) {
    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}
