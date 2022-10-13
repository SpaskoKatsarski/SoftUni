let animal = {
    classification: 'animals',

    canEat: () => {
        return 'Eating!';
    },

    canWalk: () => {
        return 'Walking!';
    },
}

let cat = {
    name: 'Sharo',
}

// cat.__proto__ = Object.create(animal);
Object.setPrototypeOf(cat, animal);

console.log(cat.canEat());
console.log(cat.canWalk());
console.log(cat.classification);