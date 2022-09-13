function printStarts(count = 5) {
    console.log('*'.repeat(count));
}

printStarts();
printStarts(2);

let array = [1, 2, 3];

if (array) {
    console.log('Truthy!');
} else {
    console.log('Falsy!');
}

age = null || NaN || 12 || 5;
console.log(age);

text = 123 && [] && 'Ivan' && 'Spasko';
console.log(text);

for (let index = 0; index < 100; index++) {
    document.write(`<p>Index: ${index}</p>`);
}