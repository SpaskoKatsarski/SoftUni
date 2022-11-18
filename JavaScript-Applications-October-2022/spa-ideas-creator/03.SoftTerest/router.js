import { showDashboard } from './views/dashboard.js';
import { showCreate } from './views/create.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';

export const views = {
    dashboard: showDashboard,
    create: showCreate,
    login: showLogin,
    register: showRegister,
    home: showHome,
    checkUserNav
};

function checkUserNav() {
    const user = sessionStorage.getItem('user');

    if (user) {
        document.querySelectorAll('nav .user').forEach(i => i.style.display = 'block');
        document.querySelectorAll('nav .guest').forEach(i => i.style.display = 'none');
    } else {
        document.querySelectorAll('nav .user').forEach(i => i.style.display = 'none');
        document.querySelectorAll('nav .guest').forEach(i => i.style.display = 'block');
    }
}