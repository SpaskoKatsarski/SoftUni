function solve(matrix) {
    let matches = 0;

    for (let i = 0; i < matrix.length; i++) {
        let currArr = matrix[i];

        for (let j = 0; j < currArr.length; j++) {
            let currStr = currArr[j];

            if (i === matrix.length - 1) {
                if (matrix[i][j + 1] === currStr) {
                    matches++;
                }
            } else if (matrix[i + 1][j] === currStr || matrix[i][j + 1] === currStr) {
                if (matrix[i + 1][j] === currStr && matrix[i][j + 1] === currStr) {
                    matches += 2;
                } else {
                    matches++;
                }
            }
        }
    }

    return matches;
}

console.log(solve([
['1', '1', '5', '8'],
['1', '0', '5', '8']
]));