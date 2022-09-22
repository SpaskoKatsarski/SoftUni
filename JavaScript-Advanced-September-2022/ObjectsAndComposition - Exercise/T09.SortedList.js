function createSortedList() {
    let arr = [];

    let add = function(number) {
        this.arr.push(number);
        this.arr.sort((a, b) => a - b);
        this.size++;
    }

    let remove = function(index) {
        if (index < 0 || index >= arr.length) {
            throw 'Index is outside the bounds of the array!'
        }

        this.arr.splice(index, 1);
        this.size--;
    }

    let get = function(index) {
        if (index < 0 || index >= this.arr.length) {
            throw 'Index is outside the bounds of the array!'
        }

        return this.arr.find((x, i) => i === index);
    }
    
    let list = {
        arr,
        add,
        remove,
        get,
        size: 0
    };

    return list;
}

let list = createSortedList();
list.add(5);
list.add(4);
list.remove(1);
console.log(list.size);