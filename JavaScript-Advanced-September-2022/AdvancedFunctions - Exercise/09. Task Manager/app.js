function solve() {
    let addBtn = document.getElementById('add');
    
    let startBtn = document.querySelector('#orng-start');
    let deleteBtn = document.querySelector('#orng-delete');

    addBtn.addEventListener('click', (e) => {
        let form = e.target.parentElement;

        let taskName = form.children[2].value
        let description = form.children[6].value
        let date = form.children[9].value

        if (!taskName || !description || !date) {
            return;
        }
        let orangeSection = document.getElementsByClassName('orange')[0].parentElement.parentElement;

        orangeSection.getElementsByTagName('div')[1].innerHTML += '<article>' +
        `<h3>${taskName}</h3>` +
        `<p>Description: ${description}</p>` +
        `<p>Due Date: ${date}</p>` +
        '<div class="flex">' +
        '<button class="green" id="orng-start">Start</button>' +
        '<button class="red" id="orng-delete">Delete</button>' +
        '</div>' +
        '</article>'
        e.preventDefault();
    });
    
    startBtn.addEventListener('click', () => {
        greenSection.getElementsByTagName('div')[1].innerHTML += '<article>' +
        `<h3>${taskName}</h3>` +
        `<p>Description: ${description}</p>` +
        `<p>Due Date: ${date}</p>` +
        '<div class="flex">' +
        '<button class="green">Start</button>' +
        '<button class="red">Delete</button>' +
        '</div>' +
        '</article>'
    })
    
}