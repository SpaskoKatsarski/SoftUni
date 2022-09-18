function solve(matrix) {
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    let coordinates = [];

    for (let row = 0; row < matrix.length; row++) {
        let currRow = matrix[row].split(' ');

        firstDiagonalSum += parseInt(currRow[row]);
        coordinates.push([row, row]);
    }

    for (let row = 0; row < matrix.length; row++) {
        let currRow = matrix[row].split(' ');

        secondDiagonalSum += parseInt(currRow[currRow.length - row - 1]);
        coordinates.push([row, currRow.length - row - 1]);
    }

    let result = [];

    if (firstDiagonalSum === secondDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            let currRow = matrix[row].split(' ');

            for (let col = 0; col < currRow.length; col++) {
                if (!coordinates.some(arr => arr[0] === row && arr[1] === col)) {
                    result.push(firstDiagonalSum);
                } else {
                    result.push(currRow[col]);
                }
            }
        }
        for (let row = 0; row < matrix[0].split(' ').length; row++) {
            let res = '';

            for (let i = 0; i < matrix[0].split(' ').length; i++) {
                res += result.shift() + ' ';
            }

            console.log(res.trim());
        }
    } else {
        printMatrix(matrix);
    }

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            let currRow = matrix[row].split(' ');

            console.log(currRow.join(' '));
        }
    }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']);

console.log('-----')

solve(['1 1 1',
'1 1 1',
'1 1 0']);