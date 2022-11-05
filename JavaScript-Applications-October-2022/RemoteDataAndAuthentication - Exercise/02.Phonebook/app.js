function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', visualizeUsers);
    document.getElementById('btnCreate').addEventListener('click', createUser);

    const url = 'http://localhost:3030/jsonstore/phonebook';
    const nameInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');
    const list = document.getElementById('phonebook');

    async function visualizeUsers() {
        const data = await getUsers();
        const users = data.map(createCard);

        list.replaceChildren(...users);
    }

    async function createUser() {
        if (nameInput.value === '' || phoneInput.value === '') {
            return;
        }

        fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ person: nameInput.value, phone: phoneInput.value })
        });

        nameInput.value = '';
        phoneInput.value = '';

        visualizeUsers();
    }

    async function getUsers() {
        const response = await fetch(url);
        const data = await response.json();

        return Object.values(data); //result[0]._id
    }

    function createCard(user) {
        const card = document.createElement('li');
        card.id = user._id;
        card.textContent = `${user.person}: ${user.phone}`;
        const btn = document.createElement('button');
        btn.textContent = 'Delete';
        btn.addEventListener('click', removeUser)
        card.appendChild(btn);;

        return card;
    }

    async function removeUser(e) {
        const userId = e.target.parentElement.id;

        const response = await fetch(url + '/' + userId, {
            method: 'delete',
        });

        e.target.parentElement.remove();

        return response;
    }
}

attachEvents();


