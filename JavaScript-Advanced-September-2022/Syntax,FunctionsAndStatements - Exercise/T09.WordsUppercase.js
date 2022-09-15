function solve(input) {
    return input.match(/\w+/g).join(', ').toUpperCase();
}

solve('Hello, how are you?')