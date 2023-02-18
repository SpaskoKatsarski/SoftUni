import * as api from './api.js';

const endPoints = {
    'login': 'users/login',
    'register': 'users/register',
    'logout': 'users/logout',
    'catalog': 'data/catalog'
}

export async function login(email, password) {
    const res = await api.post(endPoints.login, { email, password });
    sessionStorage.setItem('userData', JSON.stringify(res));

    return res;
}

export async function register(email, password) {
    const res = await api.post(endPoints.register, { email, password });
    sessionStorage.setItem('userData', JSON.stringify(res));

    return res;
}

export async function logout() {
    const res = await api.get(endPoints.logout);
    sessionStorage.removeItem('userData');

    return res;
}

// Create Furniture (POST): http://localhost:3030/data/catalog
export async function createItem(data) {
    const res = await api.post(endPoints.catalog, data);

    return res;
}

// All Furniture (GET): http://localhost:3030/data/catalog
export async function getAllItems() {
    const res = await api.get(endPoints.catalog);

    return res;
}

// Furniture Details (GET): http://localhost:3030/data/catalog/:id
export async function getDetails(id) {
    const res = await api.get(endPoints.catalog + '/' + id);

    return res;
}

// Update Furniture (PUT): http://localhost:3030/data/catalog/:id
export async function updateItem(id, data) {
    const res = await api.put(endPoints.catalog + '/' + id, data);

    return res;
}

// Delete Furniture (DELETE):  http://localhost:3030/data/catalog/:id
export async function deleteItem(id) {
    const res = await api.del(endPoints.catalog + '/' + id);

    return res;
}

// My Furniture (GET): http://localhost:3030/data/catalog?where=_ownerId%3D%22{userId}%22
export async function getMyItems() {
    const id = JSON.parse(sessionStorage.getItem('userData'))._id;
    const res = await api.get(endPoints.catalog + `?where=_ownerId%3D%22${id}%22`);

    return res;
}