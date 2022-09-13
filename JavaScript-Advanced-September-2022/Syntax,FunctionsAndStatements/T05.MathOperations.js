function solve (x, y, symbol) {
    if (symbol === '+') {
        console.log(x + y);
    } else if (symbol === '-') {
        console.log(x - y);
    } else if (symbol === '*') {
        console.log(x * y);
    } else if (symbol === '/') {
        console.log(x / y);
    } else if (symbol === '%') {
        console.log(x % y);
    } else if (symbol === '**') {
        console.log(x ** y);
    }
}

solve(2, 3, '**');
solve(2, 3, '+');
solve(2, 3, '-');
solve(2, 3, '/');
solve(2, 3, '*');
solve(2, 3, '%');