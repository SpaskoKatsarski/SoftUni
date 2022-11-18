import { html, render } from './node_modules/lit-html/lit-html.js'

function solve() {
   const url = 'http://localhost:3030/jsonstore/advanced/table';

   const tableBody = document.querySelector('tbody');
   const input = document.getElementById('searchField');

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const text = input.value.toLowerCase();

      update(text);

      input.value = '';
   }

   update();

   async function update(text) {
      const data = await getData();

      const result = data.map(p => createRowCard(p, text));

      render(result, tableBody);
   }

   function createRowCard(person, match = undefined) {
      const firstName = person.firstName;
      const lastName = person.lastName;
      const email = person.email;
      const course = person.course;

      if (match === undefined) {
         return html`
         <tr>
            <td>${firstName} ${lastName}</td>
            <td>${email}</td>
            <td>${course}</td>
         </tr>`;
      }

      if (firstName.toLowerCase().includes(match)
      || lastName.toLowerCase().includes(match)
      || email.toLowerCase().includes(match)
      || course.toLowerCase().includes(match)) {
         return html`
         <tr class="select">
            <td>${firstName} ${lastName}</td>
            <td>${email}</td>
            <td>${course}</td>
         </tr>`;
      }

      return html`
         <tr>
            <td>${firstName} ${lastName}</td>
            <td>${email}</td>
            <td>${course}</td>
         </tr>`;
   }

   async function getData() {
      const response = await fetch(url);
      const data = await response.json();

      return Object.values(data);
   }
}

solve();