function square(number) {
    return number * number;
}

console.log(square(2));

let greetingText = 'Hello JavaScript!';

console.log(greetingText.length);
console.log(greetingText);

function greetByName(name) {
    console.log('Hello ' + name + '!')
}

greetByName('Spasko');
greetByName('Maverick');

let person = {
    firstName: 'Ivan',
    lastName: 'Georgiev',
    age: 12,
    description: 'Studying software engineering.'
}

greetByName(person.firstName + ' ' + person.lastName);

person.firstName = 'Don';
greetByName(person.firstName + ' ' + person.lastName);