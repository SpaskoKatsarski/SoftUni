import { views } from './router.js';

views.home();

views.checkUserNav();

//TODO make a userVisualization method

document.querySelector('.navbar-brand').addEventListener('click', views.home); //show home when icon clicked
document.querySelector('nav').addEventListener('click', view) //show the selected view

function view(e) {
    if (e.target.tagName == 'A') {
        const show = views[e.target.textContent.toLowerCase()];
        if (typeof (show) === 'function') {
            show();
        }
    }
}