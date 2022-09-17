function solve(commands) {
    let res = [];
    let initialNum = 1;

    for (const command of commands) {
        if (command === 'add') {
            res.push(initialNum);
        } else if (command === 'remove') {
            res.pop();
        }

        initialNum++;
    }

    let ouputStr = res.length > 0 ? res.join('\n') : 'Empty';
    console.log(ouputStr);
}

solve(['add', 
'add', 
'add', 
'add']);

console.log('-----');

solve(['remove', 
'remove', 
'remove']);