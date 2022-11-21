import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs"; 

import { showCatalog } from "./views/catalog.js";
import { showCreate } from "./views/create.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showLogin } from "./views/login.js";
import { showMyFurniture } from "./views/my-furniture.js";
import { showRegister } from "./views/register.js";

const root = document.querySelector('.container');

page((ctx, next) => {
    ctx.render = (content) => render(content, root);
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