import { html, render } from './node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

const dropdownMenu = document.getElementById('menu');
const form = document.querySelector('form');
form.addEventListener('submit', addItem);

const input = document.getElementById('itemText');

updateOptions();

async function updateOptions() {
    const options = await getData();

    const selectEl = options.map(createOptionCard);

    render(selectEl, dropdownMenu);
}

function createOptionCard(option) {
    return html`
        <option .value=${option._id}>${option.text}</option>
    `;
}

async function getData() {
    const response = await fetch(url);
    const data = await response.json();

    return Object.values(data);
}

async function addItem(e) {
    e.preventDefault();

    const text = input.value;

    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text })
    });

    input.value = '';
    updateOptions();

    return await response.json();
}