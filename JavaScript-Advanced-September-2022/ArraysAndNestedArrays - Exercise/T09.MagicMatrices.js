//TODO: solve with reduce() ^^
function isMagic(matrix) {
    let sumOfFirstRow = 0;

    for (let i = 0; i < matrix[0].length; i++) {
        sumOfFirstRow += matrix[0][i];
    }

    for (let row = 1; row < matrix.length; row++) {
        let currRow = matrix[row];
        let sumOfCurrRow = currRow.reduce((acc, el) => acc + el);

        if (sumOfCurrRow !== sumOfFirstRow) {
            return false;
        }
    }


    //4, 5, 6
    //6, 5, 4
    //5, 5, 5
    for (let row = 0; row < matrix.length; row++) {
        let currColSum = 0;

        for (let col = 0; col < matrix.length; col++) {
            currColSum += matrix[col][row];
        }

        if (currColSum != sumOfFirstRow) {
            return false;
        }
    }

    return true;
}

console.log(isMagic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));

    console.log('-------------')

console.log(isMagic([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]));