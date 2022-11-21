import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";

import { showCatalog } from "./views/catalog.js";
import { showCreate } from "./views/create.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showLogin } from "./views/login.js";
import { showMyFurniture } from "./views/my-furniture.js";
import { showRegister } from "./views/register.js";

import { logout } from './api/data.js';

const root = document.querySelector('.container');

page((ctx, next) => {
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;
    next();
});

page('/index.html', '/catalog');
page('/', '/catalog');
page('/catalog', showCatalog);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/login', showLogin);
page('/register', showRegister);
page('/my-furniture', showMyFurniture);

page.start();

updateNav();

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    updateNav();
    page.redirect('/');
});

function updateNav() {
    const userSection = document.getElementById('user');
    const guestSection = document.getElementById('guest');

    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData) {
        userSection.style.display = 'inline-block';
        guestSection.style.display = 'none';
    } else {
        userSection.style.display = 'none';
        guestSection.style.display = 'inline-block';
    }
}