function sum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr) || arr.some(e => typeof(e) !== 'number' && typeof(e) !== 'boolean')) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex > arr.length - 1) {
        endIndex = arr.length - 1;
    }

    let sum = 0;

    for (let i = startIndex; i <= endIndex; i++) {
        sum += Number(arr[i]);
    }

    return sum;
}

console.log(sum([10, 20, 30, 40, true, 60], 3, 300));