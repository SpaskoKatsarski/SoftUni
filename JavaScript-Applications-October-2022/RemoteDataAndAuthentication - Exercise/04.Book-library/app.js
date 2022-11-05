const url = 'http://localhost:3030/jsonstore/collections/books/';
const tileInput = document.querySelector('input[name="title"]');
const authorInput = document.querySelector('input[name="author"]');
const tableBody = document.getElementsByTagName('tbody')[0];

document.getElementsByTagName('form')[0].addEventListener('submit', saveBook);
document.getElementById('loadBooks').addEventListener('click', getBooks);

function editBook(e) {
    const id = e.target.parentElement.id;
}

async function deleteBook(e) {
    const id = e.target.parentElement.id;
    console.log(id)
}

async function saveBook(e) {
    e.preventDefault();

    const title = tileInput.value;
    const author = authorInput.value;

    tileInput.value = '';
    authorInput.value = '';

    if (!title || !author) {
        return;
    }

    createBook({ author, title });
}

async function createBook(book) {
    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    });

    const data = await response.json();
    console.log(data._id);
}

async function modifyBook(id) {
    await fetch(url + id, {
        method: 'put',
        body: JSON.stringify() // add the object in the format: author: "New Author", title: "New Title"
    })
}

async function getBooks() {
    const response = await fetch(url);
    const data = await response.json();

    const books = Object.values(data).map(b => {
        const tr = document.createElement('tr');

        const titleTd = document.createElement('td');
        titleTd.textContent = b.title;

        const authorTd = document.createElement('td');
        authorTd.textContent = b.author;

        const btnsTd = document.createElement('td');

        const editBtn = document.createElement('button');
        editBtn.addEventListener('click', editBook);
        editBtn.textContent = 'Edit';

        const deleteBtn = document.createElement('button');
        deleteBtn.addEventListener('click', deleteBook);
        deleteBtn.textContent = 'Delete';

        btnsTd.appendChild(editBtn);
        btnsTd.appendChild(deleteBtn);

        tr.appendChild(titleTd);
        tr.appendChild(authorTd);
        tr.appendChild(btnsTd);

        return tr;
    });

    tableBody.replaceChildren(...books);
}