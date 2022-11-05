function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    const nameInput = document.querySelector('input[name="author"]');
    const messageInput = document.querySelector('input[name="content"]');
    const textArea = document.getElementById('messages');

    document.getElementById('submit').addEventListener('click', onSend);
    document.getElementById('refresh').addEventListener('click', visualizeMessages);

    async function onSend() {
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ author: nameInput.value, content: messageInput.value })
        });

        const data = await response.json();

        nameInput.value = '';
        messageInput.value = '';

        return data;
    }

    async function getMessages() {
        const response = await fetch(url);
        const data = await response.json();

        return Object.values(data);
    }

    async function visualizeMessages() {
        const data = await getMessages();
        const content = data.map(m => `${m.author}: ${m.content}`).join('\n');

        textArea.textContent = content;
    }
}

attachEvents();