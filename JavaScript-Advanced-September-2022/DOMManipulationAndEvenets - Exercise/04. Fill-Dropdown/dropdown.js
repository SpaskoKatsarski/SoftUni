function addItem() {
    let inputs = document.querySelectorAll('input[type=text]');

    let itemText = inputs[0].value;
    let itemValue = inputs[1].value;

    let option = document.createElement('option');
    option.textContent = itemText;
    option.value = itemValue;

    document.getElementById('menu').appendChild(option);
    document.querySelectorAll('input[type=text]')[0].value = '';
    document.querySelectorAll('input[type=text]')[1].value = '';
}