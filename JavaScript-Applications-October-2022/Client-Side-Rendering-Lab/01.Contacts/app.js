import { html, nothing, render } from './node_modules/lit-html/lit-html.js';
import { contacts as data } from './contacts';

const contacts = data.map(c => Object.assign({}, c, { active: false }));

const root = document.getElementById('contacts');

const contactCard = (contact, onToggle) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button id=${contact.id} class="detailsBtn" @click=${onToggle.bind(null, contact)}>Details</button>

        ${contact.active
        ? html`<div class="details">
            <p>Phone number: ${contact.phoneNumber}</p>
            <p>Email: ${contact.email}</p>
        </div>`
        : nothing}

    </div>
</div>`;

function onToggle(contact) {
    contact.active = !contact.active;
    update();
}

update();

function update() {
    render(contacts.map(c => contactCard(c, onToggle)), root);
}