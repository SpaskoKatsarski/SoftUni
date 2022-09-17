function solve(arr) {
    let sortedArr = arr.sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length;
        } else {
            return a.localeCompare(b);
        }
    })
    console.log(sortedArr.join('\n'));
}

solve(['alpha', 
'beta', 
'gamma']);

console.log('--------');

solve(['Isacc', 
'Theodor', 
'Jack',
'Harrison', 
'George']);