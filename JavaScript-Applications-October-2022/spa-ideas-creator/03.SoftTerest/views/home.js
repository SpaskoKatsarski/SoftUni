const section = document.getElementById('home-section');
section.addEventListener('click', showHome);
section.remove();

export function showHome() {
    document.querySelector('main').replaceChildren(section);
}