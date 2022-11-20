import page from '../node_modules/page/page.mjs';

import { showHome } from './views/home.js';
import { showCatalog } from './views/catalog.js';
import { showContact } from './views/contact.js';
import { notFound } from './views/notFound.js';
import { showAbout } from './views/about.js';
import { showDetails } from './views/details.js';
import { showCreate } from './views/create.js';

page((ctx, next) => {
    ctx.render = (content) => document.querySelector('main').innerHTML = `<h2>${content}</h2>`;
    next();
});

page('/index.html', '/');
page('/', showHome);
page('/catalog', showCatalog);
page('/catalog/:category/:productId', showDetails);
page('/create', showCreate);
page('/contact', showContact);
page('/about', showAbout);
page('*', notFound);

page.start();