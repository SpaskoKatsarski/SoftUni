function greatest(firstNum, secondNum) {
    let biggerNum = Math.max(firstNum, secondNum);

    for (let index = biggerNum; index >= 1; index--) {
        if (firstNum % index === 0 && secondNum % index === 0) {
            console.log(index);

            break;
        }
    }
}

greatest(2154, 458);