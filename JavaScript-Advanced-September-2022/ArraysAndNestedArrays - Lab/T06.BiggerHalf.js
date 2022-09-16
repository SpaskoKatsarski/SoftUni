function solve(arr) {
    return arr.sort((x, y) => x - y).slice(arr.length / 2);
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));