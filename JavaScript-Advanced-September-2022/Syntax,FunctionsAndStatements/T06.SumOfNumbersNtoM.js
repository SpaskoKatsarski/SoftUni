function calculateSum(startNum, endNum) {
    let sum = 0;

    for (let i = parseFloat(startNum); i <= parseFloat(endNum); i++) {
        sum += i;
    }

    console.log(sum);
}

calculateSum('1', '5');