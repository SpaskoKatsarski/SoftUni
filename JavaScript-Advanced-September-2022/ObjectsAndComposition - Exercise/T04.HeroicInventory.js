function registerHeroes(heroesArr) {
    let result = [];

    for (let hero of heroesArr) {
        //'Isacc / 25 / Apple, GravityGun'
        hero = hero.split(' / ');

        let name = hero[0];
        let level = Number(hero[1]);
        let items = hero.length === 2 ? [] : hero[2].split(', ');

        result.push({
            name,
            level,
            items
        });
    }

    return JSON.stringify(result);
} 

console.log(registerHeroes(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']));

console.log('-----');

console.log(registerHeroes(['Jake / 1000 / Gauss, HolidayGrenade']));