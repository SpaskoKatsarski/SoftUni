function solve(commands) {
    let result = [];

    function add(text) {
        result.push(text);
    }

    function remove(text) {
        for (const el of result) {
            if (el === text) {
                result.splice(result.indexOf(el), 1);
            }
        }
    }

    function print() {
        console.log(result.join(','));
    }

    for (let command of commands) {
        command = command.split(' ');

        if (command[0] === 'add') {
            add(command[1]);
        } else if (command[0] === 'remove') {
            remove(command[1]);
        }
         else if (command[0] === 'print') {
            print();
         }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);