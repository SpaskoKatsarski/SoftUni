import { onLogin } from '../api/users.js';

const section = document.getElementById('login-section');
section.addEventListener('click', showLogin);

section.querySelector('form').addEventListener('submit', onLogin);

section.remove();

export function showLogin() {
    document.querySelector('main').replaceChildren(section);
}