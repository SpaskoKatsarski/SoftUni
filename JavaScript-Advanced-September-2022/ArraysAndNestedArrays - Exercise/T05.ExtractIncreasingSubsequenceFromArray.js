function solve(arr) {
    let biggestNum = arr[0];
    
    arr = arr.reduce((acc, currEl) => {
        if (currEl >= biggestNum) {
            acc.push(currEl);
            biggestNum = currEl;
        }

        return acc;
    }, []);

    return arr;
}