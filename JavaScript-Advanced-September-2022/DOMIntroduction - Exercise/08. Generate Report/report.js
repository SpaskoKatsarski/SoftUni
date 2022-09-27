function generateReport() {
    let outputTextArea = document.getElementById('output');

    let elements = Array.from(document.querySelectorAll('tbody tr'));
    let headers = Array.from(document.querySelectorAll('thead tr th'));

    let result = [];

    for (let i = 0; i < elements.length; i++) {
        let tableData = elements[i].cells;
        let obj = {};

        for (let j = 0; j < tableData.length; j++) {
            let infoTHeader = headers[j].childNodes;
            if (infoTHeader[1].checked) {
                obj[infoTHeader[0].textContent.trim().toLowerCase()] = tableData[j].textContent;
            }
        }

        result.push(obj);
    }

    outputTextArea.textContent = JSON.stringify(result);
}