function addItem() {
    let list = document.getElementById('items');
    let input = document.getElementById('newItemText').value;

    if (input === '') {
        return;
    }

    let liEl = document.createElement('li');
    liEl.textContent = input;

    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#')
    deleteButton.textContent = '[Delete]';

    deleteButton.addEventListener('click', () => {
        event.target.parentElement.remove();
    })

    liEl.appendChild(deleteButton);
    list.appendChild(liEl);
    document.getElementById('newItemText').value = '';
}