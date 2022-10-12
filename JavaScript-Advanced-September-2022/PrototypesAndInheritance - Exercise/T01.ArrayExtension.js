(function solve() {
    let myArr = [1, 2, 3, 4];

    Array.prototype.last = function() {
        return this[this.length - 1];
    }

    Array.prototype.skip = function(n) {
        return this.slice(n);
    }

    Array.prototype.take = function(n) {
        return this.slice(0, n);
    }

    Array.prototype.sum = function() {
        return this.reduce((acc, curr) => {
            acc += curr;
            return acc;
        }, 0)
    }

    Array.prototype.average = function() {
        let total = this.sum();

        return total / this.length;
    }
})();