function extractText() {
    let collection = [];
    let list = document.querySelectorAll('ul li');

    for (let li of list) {
        collection.push(li.textContent);
    }

    let result = collection.join('\n');
    document.getElementsByTagName('textarea')[0].textContent = result;
}