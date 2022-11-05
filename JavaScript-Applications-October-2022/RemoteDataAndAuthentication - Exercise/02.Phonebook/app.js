const url = 'http://localhost:3030/jsonstore/phonebook/';
const list = document.getElementById('phonebook');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', onLoad);
    document.getElementById('btnCreate').addEventListener('click', createRecord);
}

function createRecord() {
    onCreate(personInput.value, phoneInput.value);
    personInput.value = '';
    phoneInput.value = '';
}

function renderRecord(data) {
    const people = data.map(rec => {
        const li = document.createElement('li');
        li.textContent = `${rec.person}: ${rec.phone}`;
        li.setAttribute('data-id', rec._id);

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteRecord);
        
        li.appendChild(deleteBtn);

        return li;
    });

    list.replaceChildren(...people);
}

function deleteRecord(e) {
    onDelete(e.target.parentElement.getAttribute('data-id'));
    e.target.parentElement.remove();
}

async function onLoad() {
    const response = await fetch(url);
    const data = await response.json();

    renderRecord(Object.values(data));
}

async function onCreate(person, phone) {
    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ person, phone })
    });
    
    onLoad();
}

async function onDelete(id) {
    const response = await fetch(url + id, {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ person, phone })
    });

    const data = await response.json();

    return data;
}

attachEvents();


