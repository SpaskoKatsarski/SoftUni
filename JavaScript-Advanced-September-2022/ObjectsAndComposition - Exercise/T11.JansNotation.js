function solve(instructions) {
    let operands = [];
    let symbols = [];

    let symbolsEnum = {
        '+': (a, b) => a + b,
        '-': (a, b) => a - b,
        '*': (a, b) => a * b,
        '/': (a, b) => a / b
    }

    for (const el of instructions) {
        if (typeof(el) === 'number') {
            operands.push(el);
        } else {
            symbols.push(el);
        }
    }

    if (operands.length <= symbols.length) {
        console.log('Error: not enough operands!');
        return;
    } else if (symbols.length < operands.length - 1) {
        console.log('Error: too many operands!');
        return;
    }

    while (operands.length > 1) {
        let firstNum = operands.pop();
        let secondNum = operands.pop();
        let symbol = symbols.shift();

        let result = symbolsEnum[symbol](secondNum, firstNum);
        operands.push(result);
    }

    return Math.ceil(operands[0]);
}

console.log(solve([3,
    4,
    '+']));

console.log('----')

console.log(solve([5,
    3,
    4,
    '*',
    '-']));

console.log('----')

console.log(solve([31,
    2,
    '+',
    11,
    '/']));

console.log('--------')

console.log(solve([-1,
    1,
    '+',
    101,
    '*',
    18,
    '+',
    3,
    '/']));