function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    
    for (const button of buttons) {
        button.addEventListener('click', show);
    }

    function show(e) {
        let marks = e.target.parentElement.querySelectorAll('input[type=radio]');

        let unlock = marks[1];
        if (unlock.checked) {
            let id = e.target.parentElement.getElementsByTagName('div')[0].id;

            let condition = document.getElementById(id).style.display === 'none' ||  document.getElementById(id).style.display === '' ? 'block' : 'none'; 
            document.getElementById(id).style.display = condition;

            let btnText = condition === 'none' ? 'Show more' : 'Hide it';
            e.target.textContent = btnText;
        }
    }
}