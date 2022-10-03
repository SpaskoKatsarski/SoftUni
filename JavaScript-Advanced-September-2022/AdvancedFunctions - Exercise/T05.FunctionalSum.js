function add(num) {
    let sum = num;

    function calc(num2) {
        sum += num2;
        return calc;
    }

    calc.toString = () => sum;
    return calc;
}

function add2(num) {
    let sum = num;

    function calculate(num2) {
        sum += num2;
        return calculate;
    }
    
    calculate.toString = () => sum;
    return calculate;
}

console.log(add(1)(6)(-3));