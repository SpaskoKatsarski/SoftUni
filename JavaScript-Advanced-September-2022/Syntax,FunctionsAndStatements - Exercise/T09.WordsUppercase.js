function solve(input) {
    return input.match(/\w+/g).join(', ').toUpperCase();
}

console.log(solve('Im fine!!! Thx :D'));