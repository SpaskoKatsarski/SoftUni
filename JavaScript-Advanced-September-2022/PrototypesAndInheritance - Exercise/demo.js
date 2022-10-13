let animal = {
    canEat: () => {
        return 'Eating!';
    },

    canWalk: () => {
        return 'Walking!';
    }
}

let cat = {
    name: 'Sharo',
}

cat.__proto__ = Object.create(animal);

console.log(cat.canEat());
console.log(cat.canWalk());