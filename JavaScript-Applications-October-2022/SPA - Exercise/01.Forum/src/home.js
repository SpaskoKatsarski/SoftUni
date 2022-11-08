import { showDetails } from './details.js';

const section = document.getElementById('homeView');
const main = document.getElementsByTagName('main')[0];
const form = document.querySelector('#homeView form');
form.addEventListener('click', onSubmit);
section.remove();

const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export function showHome() {
    main.replaceChildren(section);
}

function onSubmit(e) {
    e.preventDefault();

    if (e.target.tagName === 'BUTTON') {
        if (e.target.textContent === 'Cancel') {
            clearForm();
        } else if (e.target.textContent === 'Post') {
            const formData = new FormData(form);
            const { topicName, username, postText } = Object.fromEntries(formData);
            createPost({ topicName, username, postText });
            clearForm();
        }
    }
}

function clearForm() {
    form.reset();
}

async function createPost(body) {
    const response = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    const data = await response.json();

    return data;
}

showDetails();