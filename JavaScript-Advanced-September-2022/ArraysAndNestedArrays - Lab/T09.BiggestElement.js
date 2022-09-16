function solve(matrix) {
    let result = [];

    for (const arr of matrix) {
        for (let i = 0; i < arr.length; i++) {
            result.push(arr[i]);
        }
    }

    result.sort((x, y) => y - x);

    return result[0];
}

console.log(solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]));