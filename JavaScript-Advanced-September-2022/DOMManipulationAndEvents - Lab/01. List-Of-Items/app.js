function addItem() {
    let list = document.getElementById('items');
    let input = document.getElementById('newItemText').value;
    let newElement = document.createElement('li');

    newElement.textContent = input;
    list.appendChild(newElement);

    document.getElementById('newItemText').value = '';
}

document.getElementById('removeButton').addEventListener('click', removeItem);
function removeItem() {
    let list = document.querySelectorAll('#items li');

    if (list.length === 0) {
        return;
    }

    list[list.length - 1].remove();
}