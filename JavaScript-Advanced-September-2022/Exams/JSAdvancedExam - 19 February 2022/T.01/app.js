function solve() {
    let firstNameInput = document.getElementById('fname');
    let lastNameInput = document.getElementById('lname');
    let emailInput = document.getElementById('email');
    let dateInput = document.getElementById('birth')
    let positionInput = document.getElementById('position');
    let salaryInput = document.getElementById('salary')

    let hireBtn = document.getElementById('add-worker');
    hireBtn.addEventListener('click', hire);

    let table = document.getElementById('tbody');
    let sumOfSalaries = document.getElementById('sum');

    function hire(event) {
        event.preventDefault();

        let fName = firstNameInput.value;
        let lName = lastNameInput.value;
        let email = emailInput.value;
        let date = dateInput.value;
        let position = positionInput.value;
        let salary = Number(salaryInput.value);

        if (!fName || !lName || !email || !date || !position || !salary) {
            return;
        }

        let tr = document.createElement('tr');

        let firstNameTd = document.createElement('td');
        firstNameTd.textContent = fName;

        let lastNameTd = document.createElement('td');
        lastNameTd.textContent = lName;

        let emailTd = document.createElement('td');
        emailTd.textContent = email;

        let dateTd = document.createElement('td');
        dateTd.textContent = date;

        let positionTd = document.createElement('td');
        positionTd.textContent = position;

        let salaryTd = document.createElement('td');
        salaryTd.textContent = salary;

        let btnsTd = document.createElement('td');

        let firedBtn = document.createElement('button');
        firedBtn.textContent = 'Fired';
        firedBtn.classList.add('fired');
        firedBtn.addEventListener('click', fired); 

        let editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        editBtn.classList.add('edit');
        editBtn.addEventListener('click', edit);

        btnsTd.appendChild(firedBtn);
        btnsTd.appendChild(editBtn);

        tr.appendChild(firstNameTd);
        tr.appendChild(lastNameTd);
        tr.appendChild(emailTd);
        tr.appendChild(dateTd);
        tr.appendChild(positionTd);
        tr.appendChild(salaryTd);
        tr.appendChild(btnsTd);

        table.appendChild(tr);
        
        firstNameInput.value = '';
        lastNameInput.value = '';
        emailInput.value = '';
        dateInput.value = '';
        positionInput.value = '';
        salaryInput.value = '';

        sumOfSalaries.textContent = Number(sumOfSalaries.textContent) + salary;

        function edit(event) {
            let currentTr = event.target.parentElement.parentElement;
            
            let firstName = currentTr.children[0].textContent;
            let lastName = currentTr.children[1].textContent;
            let eml = currentTr.children[2].textContent;
            let dt = currentTr.children[3].textContent;
            let pstn = currentTr.children[4].textContent;
            let slry = currentTr.children[5].textContent;

            firstNameInput.value = firstName;
            lastNameInput.value = lastName;
            emailInput.value = eml;
            dateInput.value = dt;
            positionInput.value = pstn;
            salaryInput.value = slry;

            event.target.parentElement.parentElement.remove();
            sumOfSalaries.textContent = Math.abs((Number(sumOfSalaries.textContent) - Number(slry))).toFixed(2);
        }

        function fired(event) {
            let slry = Number(event.target.parentElement.parentElement.children[5].textContent);

            event.target.parentElement.parentElement.remove();
            sumOfSalaries.textContent = Math.abs((Number(sumOfSalaries.textContent) - slry)).toFixed(2);
        }
    }
}
solve()