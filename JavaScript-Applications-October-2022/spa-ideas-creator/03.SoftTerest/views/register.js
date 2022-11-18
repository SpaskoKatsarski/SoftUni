import { onRegister } from '../api/users.js';

const section = document.getElementById('register-section');
section.addEventListener('click', showRegister);

section.querySelector('form').addEventListener('submit', onRegister);

section.remove();

export function showRegister() {
    document.querySelector('main').replaceChildren(section);
}