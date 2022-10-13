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

        if (str.length <= n) {
            return str;
        }

        if (n < 4) {
            let res = '';

            for (let i = n; i > 0; i--) {
                res += '.';
            }

            return res;
        }

        if (!str.includes(' ')) {
            return str.substring(0, n - 3) + '...';
        }

        while (str.length + 3 > n) {
            let words = str.split(' ');

            words.splice(words.length - 1);

            str = words.join(' ');
        }

        return str + '...';
    }

    String.format = function(string, ...params) {
        let result = [];

        let words = string.split(' ');

        for (let word of words) {
            if (word.startsWith('{') && word.endsWith('}')) {
                if (params.length > 0) {
                    word = params.shift();
                }
            }

            result.push(word);
        }

        return result.join(' ');
    }
})();

let str = 'my string';

str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);