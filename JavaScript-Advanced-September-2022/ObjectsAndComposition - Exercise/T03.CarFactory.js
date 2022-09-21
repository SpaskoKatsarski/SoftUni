function modifyCar(car) {
    let modifiedCar = {};
    modifiedCar.model = car.model;

    let enginesEnum = {
        'Small engine' : {
            power: 90,
            volume: 1800
        },
        'Normal engine': {
            power: 120, 
            volume: 2400
        },
        'Monster engine': {
             power: 200, 
             volume: 3500 
        }
    }

    let carriagesEnum = {
        Hatchback: function (color) {
            return {
                type: 'hatchback',
                color
            }
        },
        Coupe: function (color) { 
            return {
                type: 'coupe',
                color
            }
        }
    }

    car.power <= 90 ? modifiedCar.engine = enginesEnum["Small engine"]
    : car.power <= 120 ? modifiedCar.engine = enginesEnum['Normal engine']
    : modifiedCar.engine = enginesEnum['Monster engine'];

    if (car.carriage === 'hatchback') {
        modifiedCar.carriage = carriagesEnum.Hatchback(car.color);
    } else {
        modifiedCar.carriage = carriagesEnum.Coupe(car.color);
    }

    if (car.wheelsize % 2 === 0) {
        car.wheelsize--;
    } 

    let wheels = new Array(4).fill(car.wheelsize);
    modifiedCar.wheels = wheels;

    return modifiedCar;
}

console.log(modifyCar({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));