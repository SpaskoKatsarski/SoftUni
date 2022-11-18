const section = document.getElementById('create-section');
section.addEventListener('click', showCreate);
section.remove();

export function showCreate() {
    document.querySelector('main').replaceChildren(section);
}