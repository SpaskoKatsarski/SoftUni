function getFibonator() {
    let [num1, num2] = [0, 1];
    let isFirst = true;

    return () => {
        if (isFirst) {
            isFirst = false;
            return 1;
        }

        let sum = num1 + num2;
        num1 = num2;
        num2 = sum;
        return sum;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13