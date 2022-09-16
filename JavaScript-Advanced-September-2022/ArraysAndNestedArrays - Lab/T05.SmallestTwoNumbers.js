function solve(arr) {
    arr.sort((x, y) => x - y);

    console.log(arr.shift() + ' ' + arr.shift());
}

solve([30, 15, 50, 5]);