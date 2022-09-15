printInfo('Spasko'); // possible

function printInfo(name, age) {
    console.log(`Name: ${name}, Age: ${age}`)
}

printInfo('Spasko', 5); // also possible

console.log(5 ** 5);
//funct(2, 5) -> impossible, unreachable
let funct = (x, y) => console.log(x + y);

funct(2, 5);

function myFunc(firstNum) {
    console.log(2);
}

myFunc(2, 3, 4, 5);

function print(...parameters) {
    for (let index = 0; index < parameters.length; index++) {
        console.log(parameters[index]);
    }
}

print(12, 'Some string here!', 123, true);