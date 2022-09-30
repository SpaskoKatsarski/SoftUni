for (let i = 0; i < 10; i++) {
    let myVar = 5;
}

// console.log(myVar); //Doesn't work, because let can be accessed only in the scope of the function it has been created and after initialization!

for (i = 0; i < 10; i++) {
    function myFunc() {
        console.log(i);
    }
}

myFunc();

// for (let i = 0; i < 10; i++) {
//     console.log(myVar); //Cannot be accessed before initialization!
//     let myVar = i;
// }

function myFunc() {
    console.log('Duplicate!');
}

myFunc(); //Executes the first function

console.log('Nested functions...')

function declaration() {
    let someVar = 0; //if we name this: 'myVar' instead of 'someVar'
    inner();

    function inner() {
        console.log(someVar); //and here we use it as 'myVar' it will throw an error saying that we cannot access myVar before initialization!

        let myVar = 'Hello';
        megaInner();

        function megaInner() {
            console.log(myVar);
        }
    }
}

declaration();