(function solve() {
    String.prototype.ensureStart = function(str) {
        return this.startsWith(str) ? this.toString() : str + this;
    };

    String.prototype.ensureEnd = function(str) {
        return this.endsWith(str) ? this.toString() : this + str;
    };

    String.prototype.isEmpty = function() {
        return this.toString().length === 0;
    };

    String.prototype.truncate = function(n) {
        let str = this.toString();

        if (str.length < n) {
            return str;
        }

        while (str.length > n) {
            let words = str.split(' ');

            words.splice(words.length - 1);

            str = words.join(' ');
        }

        let result = str + '...';

        if (condition) {
            
        }
        return str + '...';
    }

    String.prototype.format = function(string, ...params) {

    }
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');