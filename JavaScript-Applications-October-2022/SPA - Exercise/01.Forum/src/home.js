import { showDetails } from './details.js';

const section = document.getElementById('homeView');
const main = document.getElementsByTagName('main')[0];
const form = document.querySelector('#homeView form');
form.addEventListener('click', onSubmit);
section.remove();

const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export async function showHome() {
    const topicContainer = section.querySelector('.topic-title')
    const posts = await getPosts();

    const templates = Object.values(posts).map(p => craeteCommentCard(p));
    topicContainer.replaceChildren(...templates);

    main.replaceChildren(section);
}

function craeteCommentCard(data) {
    const container = document.createElement('div');
    container.classList.add('topic-container');
    container.innerHTML = `
    <div class="topic-name-wrapper">
            <div class="topic-name">
            <a href="#" class="normal" id="${data._id}">
            <h2>${data.topicName}</h2>
            </a>
            <div class="columns">
                <div>
                <p>Date: <time>${data.date}</time></p>
                <div class="nick-name">
                    <p>Username: <span>${data.username}</span></p>
                </div>
                </div>
            </div>
        </div>
    </div>`;

    container.querySelector('a').addEventListener('click', showDetails);

    return container;
}

function onSubmit(e) {
    e.preventDefault();

    if (e.target.tagName === 'BUTTON') {
        if (e.target.textContent === 'Cancel') {
            clearForm();
        } else if (e.target.textContent === 'Post') {
            debugger;
            const formData = new FormData(form);
            const { topicName, username, postText } = Object.fromEntries(formData);
            createPost({ topicName, username, postText, date: new Date() });
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

async function getPosts() {
    const response = await fetch(url);
    const data = await response.json();

    return data;
}