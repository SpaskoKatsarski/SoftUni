function outer() {
    let a = 5;

    return function () {
        return function () {
            return a;
        }
    }
}

let inner = outer();
let moreInner = inner();
let res = moreInner();
console.log(res);

console.log(outer()()());

function sayHi() {
    console.log(`${this.name} says hi!`);
}

let prsn = {
    name: 'Gosho'
}

let secondPerson = {
    name: 'Pesho'
}

let result = sayHi.bind(secondPerson);
result();
sayHi.call(prsn);

let func = (obj) => {
    console.log(obj.name + ' is calling the arrow func!');
}

(function call() {
    console.log('calling');
})();