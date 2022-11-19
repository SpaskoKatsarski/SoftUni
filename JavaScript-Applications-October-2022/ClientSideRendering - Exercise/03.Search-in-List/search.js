import { html, render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const townRoot = document.getElementById('towns');
const resRoot = document.getElementById('result');
document.querySelector('button').addEventListener('click', search);

update();

function update(text) {
   const ul = searchTemplate(towns, text);
   render(ul, townRoot);
}

function searchTemplate(townsNames, match) {
   const ul = html`
      <ul>
         ${townsNames.map(townName => createListTemplate(townName, match))}
      </ul>
   `;

   return ul;
}

function createListTemplate(town, match) {
   return html`
      <li class="${town.toLowerCase().includes(match) ? 'active' : ''}">${town}</li>   
   `;
}

function search() {
   const inputEl = document.getElementById('searchText');
   const text = inputEl.value.toLowerCase();
   debugger;
   update(text);
   updateCount();

   inputEl.value = '';
}

function updateCount() {
   const count = document.querySelectorAll('.active').length;
   const countEl = count ? html`<p>${count} matches found</p>` : "";

   render(countEl, resRoot);
}