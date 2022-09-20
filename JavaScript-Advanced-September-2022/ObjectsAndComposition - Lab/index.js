let person = {
    name: 'Ivan'
}

person.age = 5;

console.log(person);

let arr = [1, 2, 3, 4, 5];
let [a, b, c, ...rest] = arr;
console.log(rest);


let student = {
    name: 'Ivan',
    age: 15
}

let { age, name } = student;
console.log(age);

student['age']++;
console.log(student.age);

student['city'] = 'Sofia';
console.log(student);

delete student.city;
console.log(student)

class Cat {
    name;
    age;
}

let cat = new Cat();

cat.name = 'Sharo';
cat.coutnry = 'Bulgaria';

console.log(cat);

let someCat = {
    name: 'Ivan',
    age: 5,
    owner: {
        name: 'Pesho',
        adress: 'Ilinden'
    }
}

let copyCat = {...someCat};
console.log(copyCat);

someCat.owner.name = 'Dido';
console.log(copyCat.owner.name); // Shallow copy

someCat.name = 'Fiora';
console.log(someCat.name);
console.log(copyCat.name);

function canPrint(obj) {
    let print = function ()  {
        return `${obj.name} is printing...`
    }

    obj.print = print;
}

let printer = {
    name: 'Cool printer'
}

canPrint(printer);

console.log(printer.print()) // ????

let dog = {
    name : 'Fiora',
    age: 7,
    owner : {
        name: 'Ivan',
        address: {
            building: 'Yellow',
            name: 'Ilinden'
        }
    }
}

console.log(dog.owner.address.building);