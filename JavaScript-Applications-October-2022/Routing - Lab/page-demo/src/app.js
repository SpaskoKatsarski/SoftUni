import page from '../node_modules/page/page.mjs';

import { showHome } from './views/home.js';
import { showCatalog } from './views/catalog.js';
import { showContact } from './views/contact.js';
import { notFound } from './views/notFound.js';

page((ctx, next) => {
    ctx.render = (content) => document.querySelector('main').innerHTML = `<h2>${content}</h2>`;
    next();
});

page('/index.html', '/');
page('/', showHome);
page('/catalog', showCatalog);
page('/contact', showContact);
page('*', notFound);

page.start();