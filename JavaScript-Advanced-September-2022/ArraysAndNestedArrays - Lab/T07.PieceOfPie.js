function solve(flavours, targetOne, targetTwo) {
    let startIndex = flavours.indexOf(targetOne);
    let endIndex = flavours.indexOf(targetTwo);

    let result = [];

    for (let i = startIndex; i <= endIndex; i++) {
        result.push(flavours[i]); 
    }

    return result;
}