export function showCatalog(ctx) {
    ctx.render('Catalog');
    const ul = document.createElement('ul');
    const li = document.createElement('li');
    const a = document.createElement('a');
    debugger;
    a.href = '/catalog/snowboards/12345';
    a.textContent = 'Product123';

    li.appendChild(a);
    ul.appendChild(li);

    document.querySelector('main').appendChild(ul);
}