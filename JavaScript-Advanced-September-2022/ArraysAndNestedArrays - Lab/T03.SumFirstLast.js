function solve(arr) {
    let firstNum = parseInt(arr[0]);
    let lastNum = parseInt(arr.slice(-1));

    return firstNum + lastNum;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));