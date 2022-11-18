const section = document.getElementById('dashboard-holder');
section.addEventListener('click', showDashboard);
section.remove();

export function showDashboard() {
    document.querySelector('main').replaceChildren(section);
}