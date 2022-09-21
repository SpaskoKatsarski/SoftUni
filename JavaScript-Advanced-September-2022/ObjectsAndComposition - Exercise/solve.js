function fixCase(text) {
    return text[0].toUpperCase() + text.substring(1);
}

let str = 'red';
console.log(fixCase(str));

let test = 'yeyeye';
console.log(test.replace(test[0], test[0].toUpperCase()));

let test2 = 'yeyeyeyeye';
console.log(test.replaceAll('y', 'Y'));