function deleteByEmail() {
    let tableRows = document.querySelectorAll('#customers td:nth-child(2)')
    let input = document.getElementsByName('email')[0].value;

    for (let row of tableRows) {
        if (row.textContent === input) {
            row.parentElement.remove();
            document.getElementById('result').textContent = 'Deleted.';
            return;
        }
    }

    document.getElementById('result').textContent = 'Not found.';
}