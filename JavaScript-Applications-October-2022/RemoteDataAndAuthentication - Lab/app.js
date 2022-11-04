const list = document.getElementById('comments');
const nameInput = document.querySelector('[name="name"]');
const contentInput = document.querySelector('[name="content"]');

init();

function init() {
    document.getElementById('load').addEventListener('click', getComments)
    document.getElementById('comment-form').addEventListener('submit', onPost);

    list.addEventListener('click', onCommentClick);
    list.addEventListener('click', updateComment);
}

async function onPost(e) {
    e.preventDefault();
    const formData = new FormData(e.target);

    const data = Object.fromEntries(formData.entries());

    const name = data.name;
    const content = data.content;

    const result = await postComment({ name, content });
    list.prepend(createCommentCard(result));

    nameInput.value = '';
    contentInput.value = '';
}

function displayComments(comments) {
    list.replaceChildren(...comments.map(createCommentCard).reverse());
}

function createCommentCard(comment) {
    const el = document.createElement('article');
    el.innerHTML = `<header><h3>${comment.name}</h3></header><main><p>${comment.content}</p><button>Delete</button><button>Edit</button></main>`;
    el.id = comment._id;

    return el;
}

async function getComments() {
    const response = await fetch('http://localhost:3030/jsonstore/demo');
    const data = await response.json();

    const comments = Object.values(data);

    displayComments(comments);
}

async function postComment(comment) {
    const response = await fetch('http://localhost:3030/jsonstore/demo', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comment)
    });

    const data = await response.json();

    return data;
}

function onCommentClick(e) {
    if (e.target.tagName === 'BUTTON') {
        if (e.target.textContent === 'Delete') {
            const choice = confirm('Are you sure you want to delete this comment?')

            if (choice) {
                deleteComment(e.target.parentElement.parentElement.id);
            }
        } else if (e.target.textContent === 'Edit') {
            const id = e.target.parentElement.parentElement.id;
            const header = e.target.parentElement;
            const nameValue = header.getElementsByTagName('h3')[0].textContent;
            const contentValue = header.getElementsByTagName('p')[0].textContent;

            nameInput.value = nameValue;
            contentValue.value = contentValue;

            //TODO..
        }
    }
}

async function deleteComment(id) {
    await fetch('http://localhost:3030/jsonstore/demo/' + id, {
        method: 'delete'
    });

    document.getElementById(id).remove();
}

async function updateComment(id, comment) {
    const response = await fetch('http://localhost:3030/jsonstore/demo/' + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comment)
    });

    return await response.json();
}