function solve(number, first, second, third, fourth, fifth) {
    let num = parseInt(number);

    num = operate(num, first);
    console.log(num);

    num = operate(num, second);
    console.log(num);

    num = operate(num, third);
    console.log(num);

    num = operate(num, fourth);
    console.log(num);

    num = operate(num, fifth);
    console.log(num);
    
    function operate(num, operation) {
        if (operation === 'chop') {
            num /= 2;
        } else if (operation === 'dice') {
            num = Math.sqrt(num);
        } else if (operation === 'spice') {
            num++;
        } else if (operation === 'bake') {
            num *= 3;
        } else if (operation === 'fillet') {
            num *= 0.80;
        } 

        return num;
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');