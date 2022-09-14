printInfo('Spasko'); // possible

function printInfo(name, age) {
    console.log(`Name: ${name}, Age: ${age}`)
}

printInfo('Spasko', 5); // also possible

console.log(5 ** 5);
//funct(2, 5) -> impossible, unreachable
let funct = (x, y) => console.log(x + y);

funct(2, 5);