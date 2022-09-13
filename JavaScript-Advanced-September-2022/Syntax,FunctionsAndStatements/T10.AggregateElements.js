function aggregateElements(elements) {
    let sum = 0;
    for (let index = 0; index < elements.length; index++) {
        sum += elements[index];
    }

    console.log(sum);

    let secondSum = 0;
    for (let index = 0; index < elements.length; index++) {
        secondSum += 1 / elements[index];
    }

    console.log(secondSum);

    let text = `${elements[0]}`;
    for (let index = 1; index < elements.length; index++) {
        text += `${elements[index]}`;
    }

    console.log(text);
}

aggregateElements([1, 2, 3]);