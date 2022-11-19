import { html, render } from './node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/collections/books/';

const root = document.querySelector('tbody');
const addForm = document.getElementById('add-form');
const editForm = document.getElementById('edit-form');
const body = document.querySelector('body');

document.getElementById('loadBooks').addEventListener('click', update);

editForm.addEventListener('submit', onEdit);
editForm.remove();

addForm.addEventListener('submit', onSubmit);

async function onEdit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const { title, author } = Object.fromEntries(formData);

    const dataId = editForm.getAttribute('data-id');
    editForm.removeAttribute('data-id');

    const result = await updateBook({ title, author }, dataId);
    
    editForm.reset();

    editForm.remove();
    body.appendChild(addForm);

    update();

    return result;
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const { title, author } = Object.fromEntries(formData);

    await addBook({ title, author })

    addForm.reset();
    update();
}

async function addBook(data) {
    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    update();
    return await response.json();
}

async function getTemplates() {
    const data = await getBooks();

    const books = [];

    for (const id in data) {
        const bookInfo = data[id];
        books.push(createBookCard(bookInfo, id));
    }

    return books;
}

function createBookCard(bookInfo, id) {
    return html`
        <tr id=${id}>
            <td>${bookInfo.title}</td>
            <td>${bookInfo.author}</td>
            <td>
                <button @click=${editBook}>Edit</button>
                <button @click=${deleteBook}>Delete</button>
            </td>
        </tr>
    `
}

async function update() {
    const books = await getTemplates();
    render(books, root);
}

async function editBook(e) {
    addForm.remove();
    body.appendChild(editForm);

    const id = e.target.parentElement.parentElement.id;
    editForm.setAttribute('data-id', id);

    const titleInput = document.querySelector('input[name="title"]');
    const authorInput = document.querySelector('input[name="author"]');

    titleInput.value = e.target.parentElement.parentElement.getElementsByTagName('td')[0].textContent;
    authorInput.value = e.target.parentElement.parentElement.getElementsByTagName('td')[1].textContent;
}

async function updateBook(data, id) {
    const response = await fetch(url + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    return await response.json();
}

async function deleteBook(e) {
    const id = e.target.parentElement.parentElement.id;

    await fetch(url + id, {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    update();
}

async function getBooks() {
    const response = await fetch(url);
    const data = await response.json();

    return data;
}