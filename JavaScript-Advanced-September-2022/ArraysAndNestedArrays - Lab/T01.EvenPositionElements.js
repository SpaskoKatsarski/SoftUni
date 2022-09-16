function solve(arr) {
    let evens = [];

    for (let i = 0; i < arr.length; i += 2) {
        evens.push(arr[i]);
    }

    console.log(evens.join(' '));
}

solve([1, 2, 3, 4, 5, 6]);