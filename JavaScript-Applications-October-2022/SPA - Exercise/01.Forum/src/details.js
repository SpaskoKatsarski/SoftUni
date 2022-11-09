const section = document.getElementById('detailsView');
const main = document.getElementsByTagName('main')[0];
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

section.remove();

let id;

export async function showDetails(e) {
    if (!e) {
        return;
    }

    if (e.target.tagName === 'H2') {
        id = e.target.parentElement.id;
    } else if (e.target.tagNAme === 'A') {
        id = e.target.id;
    }

    const topic = await loadTopic(id);
    const comments = await loadComment(id);
    const result = topicTemplate(topic, Object.values(comments));

    section.replaceChildren(result);
    main.replaceChildren(section);
}

function topicTemplate(topic, comments) {
    debugger;
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const { postText, username } = Object.fromEntries(formData);

    await createPost({ postText, username, id })
}

async function createPost(body) {
    const url = 'http://localhost:3030/jsonstore/collections/myboard/comments/';

    const response = await fetch(url + body.id, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    const data = await response.json();

    clearForm();

    return data; //Object.values
}

function clearForm() {
    form.reset();
}

async function loadComment(id) {
    const url = 'http://localhost:3030/jsonstore/collections/myboard/comments/' //TODO: id?;

    const response = await fetch(url);
    const data = await response.json();

    return data;
}

async function loadTopic(id) {
    const url = 'http://localhost:3030/jsonstore/collections/myboard/posts/';

    const response = await fetch(url + id);
    const data = await response.json();

    return data;
}