function solve(arr) {
    let odds = [];

    for (let i = 1; i < arr.length; i += 2) {
        odds.push(arr[i]);
    }

    return odds.map(n => n * 2).reverse();
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));