function colorize() {
    let rows = document.querySelectorAll('table tr');

    let index = 1;
    for (let row of rows) {
        if (index % 2 == 0) {
            row.style.background = 'Teal';
        }
        index++;
    }
}