function solve(area, volume, input) {
    let result = [];
    let figures = JSON.parse(input);


    for (const figure of figures) {
        result.push({
            area: area.call(figure),
            volume: volume.call(figure)
        })
    }

    return result;
}

console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`));

function area() {
    return Math.abs(this.x * this.y);
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

