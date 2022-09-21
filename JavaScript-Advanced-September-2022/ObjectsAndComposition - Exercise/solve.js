function fixCase(text) {
    return text[0].toUpperCase() + text.substring(1);
}

let str = 'red';
console.log(fixCase(str));