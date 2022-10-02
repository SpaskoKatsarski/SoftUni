function argumentInfo(...params) {
    let typeCounts = {};

    for(let arg of params){
        console.log(`${typeof(arg)}: ${arg}`);
        
        if(! typeCounts[typeof(arg)]){
            typeCounts[typeof(arg)] = 1;
        } else {
            typeCounts[typeof(arg)]++;
        }
    }
 
    Object.keys(typeCounts).sort((a, b) => b - a).forEach(k => console.log(`${k} = ${typeCounts[k]}`));
}

argumentInfo('cat', 42, function () { console.log('Hello world!') });