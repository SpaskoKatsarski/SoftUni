window.addEventListener('DOMContentLoaded', onLoadHTML)

const logoutUrl = 'http://localhost:3030/users/logout';
const catchesUrl = 'http://localhost:3030/data/catches ';
const addBtn = document.querySelector('.add');

document.getElementById('addForm').addEventListener('submit', createCatch);
document.getElementById('logout').addEventListener('click', onLogout);
document.querySelector('.load').addEventListener('click', onLoadCatch);

async function onLogout() {
    const header = getHeader('get', '');
    await fetch(logoutUrl, header);

    sessionStorage.clear();

    onLoadHTML();
    //window.location = './login.html';
}

function onLoadHTML() {
    const token = sessionStorage.getItem('accessToken');
    const username = document.querySelector('p.email span');

    if (token) {
        username.textContent = sessionStorage.getItem('email');

        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';

        addBtn.disabled = false;
    } else {
        username.textContent = 'guest';

        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('user').style.display = 'none';

        addBtn.disabled = true;
    }
}

async function onLoadCatch() {
    const response = await fetch(catchesUrl);
    const data = await response.json();
    debugger;

    //render method (should display all catches)
    return data;
}

function createCatch(e) {
    e.preventDefault();
    debugger;
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);

    onCreateCatch(data); //User can add fields we may not want to be there.
}

async function onCreateCatch(body) {
    const headers = getHeader('put', body);

    const response = await fetch(catchesUrl, headers);
    const data = await response.json();
    
    return data;
}

function getHeader(method, body) {
    const token = sessionStorage.getItem('accessToken');

    const header = {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        }
    };

    if (body) {
        header.body = JSON.stringify(body);
    }

    return header;
}