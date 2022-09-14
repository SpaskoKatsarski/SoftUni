function sameNumbers(num) {
    let numAsStr = num.toString();
    let areSame = true;
    let sum = Number(numAsStr[0]);

    for (let index = 1; index < numAsStr.length; index++) {
        if(numAsStr[index] !== numAsStr[index - 1]) {
            areSame = false;
        }

        sum += Number(numAsStr[index]);
    }

    console.log(areSame)
    console.log(sum);
}   

sameNumbers(321321);
sameNumbers(222);
sameNumbers(2);