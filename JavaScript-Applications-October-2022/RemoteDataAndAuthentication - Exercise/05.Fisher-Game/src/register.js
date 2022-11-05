const registerUrl = 'http://localhost:3030/users/register';

const notificationParagraph = document.querySelector('p.notification');

document.getElementById('register-form').addEventListener('submit', registerHandler);
document.querySelectorAll('a').forEach(x => x.classList.remove('active'));
document.getElementById('register').classList.add('active');

function registerHandler(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const { email, password, rePassword } = Object.fromEntries(formData);

    if (password !== rePassword) {
        notificationParagraph.textContent = 'Error'

        setTimeout(() => {
            notificationParagraph.textContent = '';
        }, 1000)
    } else {
        onRegister(email, password);
    }
}

async function onRegister(email, password) {
    const header = getHeader('post', { email, password });

    try {
        const response = await fetch(registerUrl, header);
        const data = await response.json();

        if (data.code && data.code !== 200) {
            throw new Error(data.message);
        }

        sessionStorage.setItem('email', data.email);
        sessionStorage.setItem('accessToken', data.accessToken);
        window.location = './index.html';

        return data;
    } catch (e) {
        notificationParagraph.textContent = e.message;

        setTimeout(() => {
            notificationParagraph.textContent = '';
        }, 1000);
    }
}

function getHeader(method, body) {
    return {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    };
}