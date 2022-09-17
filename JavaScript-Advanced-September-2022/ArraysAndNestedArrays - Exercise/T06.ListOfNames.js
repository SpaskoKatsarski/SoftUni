function solve(names) {
    let counter = 0;

    names.sort((a, b) => a.localeCompare(b)).forEach(name => {
        console.log(`${++counter}.${name}`);
    });
}

solve(["John", "Bob", "Christina", "Ema"]);