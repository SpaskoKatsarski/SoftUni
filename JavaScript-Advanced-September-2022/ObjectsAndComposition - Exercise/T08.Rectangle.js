function rectangle(width, height, color) {
    let calcArea = function() {
        return this.width * this.height;
    }

    return {
        width,
        height,
        'color': color.replace(color[0], color[0].toUpperCase()),
        calcArea
    }
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());