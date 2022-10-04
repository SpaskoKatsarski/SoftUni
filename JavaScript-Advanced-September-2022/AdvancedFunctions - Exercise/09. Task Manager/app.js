function solve() {
    const inputTask = document.getElementById('task');
    const inputDescription = document.getElementById('description');
    const inputDate = document.getElementById('date');
    const addButton = document.getElementById('add');
 
    let allSections = document.querySelectorAll('section');
 
    let openSection = allSections[1];
    let progressSection = allSections[2];
    let completeSection = allSections[3];
 
    addButton.addEventListener('click', addClick);
 
    function clickFirstBtn(e) {
        let target = e.target;
        let movedArticle = target.parentElement.parentElement;
 
        if (target.className === "green") {
            let finishBtn = document.createElement('button');
            finishBtn.textContent = 'Finish';
            finishBtn.className = 'orange';
 
            target.remove();
 
            let newArticle = movedArticle.cloneNode(true);
 
            finishBtn.addEventListener('click', clickFirstBtn);
            newArticle.children[3].appendChild(finishBtn);
            newArticle.children[3].children[0].addEventListener('click', clickSecondBtn)
 
            movedArticle.remove();
 
            progressSection.children[1].appendChild(newArticle);
        } else if (target.className === "orange") {
            movedArticle.children[3].remove();
            let newArticle = movedArticle.cloneNode(true);
            movedArticle.remove();
            completeSection.children[1].appendChild(newArticle);
        }
    }
 
    function clickSecondBtn(e) {
        let movedArticle = e.target.parentElement.parentElement;
        movedArticle.remove();
    }
    
    function addClick(e) {
        e.preventDefault();
        let task = inputTask.value;
        let descr = inputDescription.value;
        let date = inputDate.value;
 
        if (task === '' || descr === '' || date === '') {
            return;
        }
 
        let articleElement = document.createElement('article');
        let divElement = document.createElement('div');
        divElement.className = "flex";
 
        let startBtn = document.createElement('button');
        let deleteBtn = document.createElement('button');
        startBtn.className = "green";
        deleteBtn.className = "red";
 
        startBtn.textContent = 'Start';
        deleteBtn.textContent = 'Delete';
 
        startBtn.addEventListener('click', clickFirstBtn);
        deleteBtn.addEventListener('click', clickSecondBtn);
 
        divElement.appendChild(startBtn);
        divElement.appendChild(deleteBtn);
 
        articleElement.innerHTML = `<h3>${task}</h3><p>Description: ${descr}</p><p>Due Date: ${date}</p>`;
 
        articleElement.appendChild(divElement);
 
        openSection.children[1].appendChild(articleElement);
    }
}