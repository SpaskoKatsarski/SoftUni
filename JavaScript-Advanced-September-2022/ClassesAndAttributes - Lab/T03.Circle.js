class Circle {
    _diameter;

    constructor(radius) {
        this.radius = radius;
        this.diameter = radius * 2;
    }

    get diameter() {
        return this._diameter;
    }

    set diameter(value) {
        this._diameter = value;
        this.radius = this.diameter / 2;

        return this.diameter;
    }

    get area() {
        return Math.PI * (this.radius ** 2);
    }
}


let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);