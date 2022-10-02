function outer() {
    let a = 5;

    return function inner() {
        return function moreInner() {
            return a;
        }
    }
}

let inner = outer();
let moreInner = inner();
let res = moreInner();
console.log(res);

console.log(outer()()());