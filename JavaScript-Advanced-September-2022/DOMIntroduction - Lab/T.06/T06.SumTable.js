function sum() {
    let tableRows = document.querySelectorAll('table tr');
    let sum = 0;
    for (let i = 1; i < tableRows.length - 1; i++) {
        let row = tableRows[i];
        sum += Number(row.find("td:eq(1)").val());
    }

    tableRows[tableRows.length - 1].find("td:eq(1)").val() = sum;
}