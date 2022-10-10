const constName = 'Im const';

let obj = {
    constName
}

obj.constName = 'Georgi';
console.log(obj.constName)

let cat = {
    name: 'Pesho'
}

// for (const [name, value] of Object.entries(cat)) {
//     console.log(`${name}: ${value}`);
// }

Object.defineProperty(cat, 'description', { 
    enumerable: false,
    writable: false,
    configurable: true,
    value: `${cat.name}: Hello! I like to play with other cats!` // Shouldn't be done like this.
});

printObj(cat);

cat.description = 'I dont like to play with other cats';
console.log(cat.description);

cat.name = 'Sasho';
console.log(cat.description); // Doesn't change. Problem.

delete cat.description;

printObj(cat);

function printObj(obj) {
    for (const key in obj) {
        console.log(obj[key]);
    }
}

let person = {
    name: 'Ivan',
    age: 56
}

Object.seal(person);

person.name = 'Sharo';
printObj(person);

console.log(Object.isSealed(person));
console.log(Object.isFrozen(person));

delete person.name; // Cant delete
printObj(person);
person.description = 'HIII';
printObj(person);

