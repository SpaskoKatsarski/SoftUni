class List {
    constructor() {
        this.elements = [];
        this.size = this.elements.length;
    }

    add(element) {
        this.elements.push(element);

        this.size = this.elements.length;

        this.orderArray();
    }

    remove(index) {
        if (this.isIndexValid(index)) {
            this.elements.splice(index, 1);

            this.size = this.elements.length;

            this.orderArray();
        }
    }

    get(index) {
        if (this.isIndexValid(index)) {
            this.orderArray();

            return this.elements[index];
        }
    }

    orderArray() {
        this.elements = this.elements.sort((a, b) => a - b);
    }

    isIndexValid(checkingIndex) {
        if (checkingIndex < 0 || checkingIndex >= this.size) {
            return false;
        }

        return true;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));