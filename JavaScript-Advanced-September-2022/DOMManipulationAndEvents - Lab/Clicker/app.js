let button = document.getElementById('clicker');

let p = document.createElement('p');
p.textContent = '0';
document.body.append(p);

button.addEventListener('click', () => {
    p.textContent = (Number(p.textContent) + 1).toString();
})