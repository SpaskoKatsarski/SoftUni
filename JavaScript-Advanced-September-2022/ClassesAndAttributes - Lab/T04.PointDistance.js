class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2) {
        return Math.sqrt((p1.x - p2.x) ** 2 + (p1.y - p2.y) ** 2); 
    }
}

let firstPoint = new Point(5, 5);
let secondPoint = new Point(9, 8);

console.log(Point.distance(firstPoint, secondPoint));