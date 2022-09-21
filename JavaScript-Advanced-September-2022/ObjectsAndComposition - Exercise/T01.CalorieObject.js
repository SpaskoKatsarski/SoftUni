function solve(food) {
    let result = {};

    for (let i = 0; i < food.length; i += 2) {
        result[food[i]] = Number(food[i + 1]);
    }

    console.log(result);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);