const hostUrl = 'http://localhost:3030/';

async function request(url, options) {
    try {
        const response = await fetch(hostUrl + url, options);

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status === 204) {
            return response;
        }

        const data = await response.json();

        return data;
    } catch (error) {
        alert(error.message);
        throw new Error(error);
    }
}

function getOption(method, body) {
    const options = {
        method,
        headers: {}
    };

    const user = JSON.parse(sessionStorage.getItem('userData'));

    if (user) {
        const token = user.accessToken;
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url, getOption('get'));
}

export async function post(url, data) {
    return await request(url, getOption('post', data));
}

export async function put(url, data) {
    return await request(url, getOption('put', data));
}

export async function del(url) {
    return await request(url, getOption('delete'));
}