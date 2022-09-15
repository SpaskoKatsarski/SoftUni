function drive(speed, area) {
    const motorwaySpeed = 130;
    const interstateSpeed = 90;
    const citySpeed = 50;
    const residentialSpeed = 20;

    if(area === 'motorway') {
        if (speed > motorwaySpeed) {
            if (speed - motorwaySpeed > 40) {
                console.log(`The speed is ${speed - motorwaySpeed} km/h faster than the allowed speed of ${motorwaySpeed} - reckless driving`);
            }else if (speed - motorwaySpeed > 20) {
                console.log(`The speed is ${speed - motorwaySpeed} km/h faster than the allowed speed of ${motorwaySpeed} - excessive speeding`);
            }else {
                console.log(`The speed is ${speed - motorwaySpeed} km/h faster than the allowed speed of ${motorwaySpeed} - speeding`);
            }
        } else {
            console.log(`Driving ${speed} km/h in a ${motorwaySpeed} zone`);
        }
    } else if(area === 'interstate') {
        if (speed > interstateSpeed) {
            if (speed - interstateSpeed > 40) {
                console.log(`The speed is ${speed - interstateSpeed} km/h faster than the allowed speed of ${interstateSpeed} - reckless driving`);
            }else if (speed - interstateSpeed > 20) {
                console.log(`The speed is ${speed - interstateSpeed} km/h faster than the allowed speed of ${interstateSpeed} - excessive speeding`);
            }else {
                console.log(`The speed is ${speed - interstateSpeed} km/h faster than the allowed speed of ${interstateSpeed} - speeding`);
            }
        } else {
            console.log(`Driving ${speed} km/h in a ${interstateSpeed} zone`);
        }
    } else if(area === 'city') {
        if (speed > citySpeed) {
            if (speed - citySpeed > 40) {
                console.log(`The speed is ${speed - citySpeed} km/h faster than the allowed speed of ${citySpeed} - reckless driving`);
            }else if (speed - citySpeed > 20) {
                console.log(`The speed is ${speed - citySpeed} km/h faster than the allowed speed of ${citySpeed} - excessive speeding`);
            }else {
                console.log(`The speed is ${speed - citySpeed} km/h faster than the allowed speed of ${citySpeed} - speeding`);
            }
        } else {
            console.log(`Driving ${speed} km/h in a ${citySpeed} zone`);
        }
    } else if(area === 'residential') {
        if (speed > residentialSpeed) {
            if (speed - residentialSpeed > 40) {
                console.log(`The speed is ${speed - residentialSpeed} km/h faster than the allowed speed of ${residentialSpeed} - reckless driving`);
            }else if (speed - residentialSpeed > 20) {
                console.log(`The speed is ${speed - residentialSpeed} km/h faster than the allowed speed of ${residentialSpeed} - excessive speeding`);
            }else {
                console.log(`The speed is ${speed - residentialSpeed} km/h faster than the allowed speed of ${residentialSpeed} - speeding`);
            }
        } else {
            console.log(`Driving ${speed} km/h in a ${residentialSpeed} zone`);
        }
    }
}

drive(87, 'city');