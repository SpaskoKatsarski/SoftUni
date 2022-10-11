function solve() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area() {
            return;
        }

        changeUnits(unit) {
            this.units = unit;
        }

        scaleParam(param) {
            switch (this.units) {
                case 'm':
                    param /= 10;
                    break;
                case 'cm':
                    break;
                case 'mm':
                    param *= 10;
                    break;
                default:
                    break;
            }
            return param;
        }

        toString() {
            let firstPart = `Figures units: ${this.units} Area: ${this.area} - `;

            let keysAndValues = [];

            for (let key of Object.keys(this)) {
                if (key === 'units' || key === 'area') {
                    continue;
                }

                if (key.includes('_')) {
                    key = key.replace('_', '');
                }

                keysAndValues.push(`${key}: ${this[key]}`);
            }

            let properties = keysAndValues.join(', ');

            return firstPart + properties;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);

            this.radius = radius;
        }

        get radius() {
            return this.scaleParam(this._radius);
        }

        set radius(value) {
            this._radius = value;
        }

        get area() {
            return Math.PI * this.radius ** 2;
        };
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);

            this.width = width;
            this.height = height;
        }

        get width() {
            return this.scaleParam(this._width);
        }

        set width(value) {
            this._width = value;
        }

        get height() {
            return this.scaleParam(this._height);
        }

        set height(value) {
            this._height = value;
        }

        get area() {
            return this.width * this.height;
        };
    }

    return {
        Figure,
        Circle,
        Rectangle
    };
}

let shapes = solve();

let Circle = shapes.Circle;
let Rectangle = shapes.Rectangle;

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50