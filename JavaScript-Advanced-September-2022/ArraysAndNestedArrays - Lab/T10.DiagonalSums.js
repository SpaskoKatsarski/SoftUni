function solve(matrix) {
    let mainSum = 0;
    let secondarySum = 0;

    let mainIndex = 0;
    let secondaryIndex = matrix[0].length - 1;

    for (let i = 0; i < matrix.length; i++) {
        mainSum += matrix[i][mainIndex];
        secondarySum += matrix[i][secondaryIndex];

        mainIndex++;
        secondaryIndex--;
    }

    console.log(`${mainSum} ${secondarySum}`)
}

solve([[20, 40],
    [10, 60]]);

// [[20, 40],      --->      80 50
//  [10, 60]]