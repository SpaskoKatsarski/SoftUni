const url = 'http://localhost:3030/jsonstore/collections/students';

function init() {
    const fNameInput = document.querySelector('input[name="firstName"]');
    const lNameInput = document.querySelector('input[name="lastName"]');
    const numberInput = document.querySelector('input[name="facultyNumber"]');
    const gradeInput = document.querySelector('input[name="grade"]');
    const tableBody = document.getElementsByTagName('tbody')[0];

    document.getElementById('submit').addEventListener('click', onSubmit);

    async function onSubmit(e) {
        e.preventDefault();

        if ((typeof (fNameInput.value) != "string" || fNameInput.value.length === 0) || fNameInput.value === "") {
            return;
        }

        if ((typeof (lNameInput.value) != "string" && lNameInput.value.length === 0) || lNameInput.value === "") {
            return;
        }

        if ( (isNaN(numberInput.value) || numberInput.value.length === 0)) {
            return;
        }

        if ( (isNaN(gradeInput.value) || gradeInput.value.length === 0)) {
            return;
        }

        await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ firstName: fNameInput.value, lastName: lNameInput.value, facultyNumber: numberInput.value, grade: gradeInput.value })
        });

        debugger;
        visualizeStudents();
    }

    async function visualizeStudents() {
        const response = await fetch(url);
        const data = await response.json();

        const result = Object.values(data).map(s => {
            const tr = document.createElement('tr');
        
            const firstNameTh = document.createElement('th');
            firstNameTh.textContent = s.firstName;

            const lastNameTh = document.createElement('th');
            lastNameTh.textContent = s.lastName;

            const numberTh = document.createElement('th');
            numberTh.textContent = s.facultyNumber;

            const gradeTh = document.createElement('th');
            gradeTh.textContent = s.grade;

            tr.appendChild(firstNameTh);
            tr.appendChild(lastNameTh);
            tr.appendChild(numberTh);
            tr.appendChild(gradeTh);

            return tr;
        });

        tableBody.replaceChildren(...result);
    }
}

init();

