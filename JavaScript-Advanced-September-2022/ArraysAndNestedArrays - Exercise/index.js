let arr = [1, 2, 3];

arr[-1] = '6';
arr[-2] = '5';

console.log(arr.indexOf('6'));
console.log(arr.indexOf('4'));
console.log(arr.indexOf('5'));

function solve(arr) {
    let res = [];
    let biggestEl = arr[0];

    for (const el of arr) {
        if (el >= biggestEl) {
            res.push(el);
            biggestEl = el;
        }
    }

    return res;
}

solve([1, 2, 3, 4, 5, 4, 3, 6]);

console.log('---------');

// Finding only increasing numbers using reduce():
let arr2 = [1, 2, 3, 4, 5, 1, 231, 10, 213];
let biggestNum = 0;

arr2 = arr2.reduce((acc, currEl) => {
    if (currEl >= biggestNum ) {
        acc.push(currEl);
        biggestNum = currEl;
    }

    return acc;
}, []);

console.log(arr2);

console.log('-----------');

function accumulateNums(arr2) {
    let biggestNum = 0;

    arr2 = arr2.reduce((acc, currEl) => {
        if (currEl >= biggestNum ) {
            acc.push(currEl);
        }

        biggestNum = currEl;
    
        return acc;
    }, []);
    
    return arr2;
}

console.log(accumulateNums([1, 5, 10, 4, 28, 90, 2, 52]));