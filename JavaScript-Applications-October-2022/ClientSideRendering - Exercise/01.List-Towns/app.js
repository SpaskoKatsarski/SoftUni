import { html, render } from './node_modules/lit-html/lit-html.js';

const root = document.getElementById('root');
const form = document.querySelector('form');
const btn = document.getElementById('btnLoadTowns');

btn.addEventListener('click', onSubmit);

function onSubmit() {
    debugger;
    const towns = document.getElementById('towns').value.split(', ')

    if (towns.length === 1 && towns[0] === '') {
        root.replaceChildren();
        return;
    }

    const listOfTowns = html`
    <ul>
        ${towns.map(createTownCard)}
    </ul>
    `;

    update(listOfTowns);

    form.reset();
}

function update(items) {
    render(items, root);
}

function createTownCard(town) {
    return html`<li>${town}</li>`;
}