function play(moves) {
    let isFirst = true;
    
    let dashBoard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]]; 

    for (let i = 0; i < moves.length; i++) {
        let marker = isFirst ? 'X' : 'O';

        let currMoves = moves[i].split(' ');

        let row = parseInt(currMoves[0]);
        let col = parseInt(currMoves[1]);

        if (isTaken(row, col)) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        dashBoard[row][col] = marker;

        if (hasWin(dashBoard, marker)) {
            console.log(`Player ${marker} wins!`)
            printBoard(dashBoard);
            return;
        } else if (!isFreeSpaceLeft(dashBoard)) {
            console.log('The game ended! Nobody wins :(')
            printBoard(dashBoard);
            return;
        }

        isFirst = !isFirst;
    }
    
    function isTaken(row, col) {
        return dashBoard[row][col] === 'X' || dashBoard === 'O';
    }

    function hasWin(dashBoard, marker) {
        let hasWin = false;

        for (let row = 0; row < dashBoard.length; row++) {
            if (dashBoard[row][0] === marker && dashBoard[row][1] === marker && dashBoard[row][2] === marker) {
                hasWin = true;
                break;
            }
        }

        for (let row = 0; row < dashBoard.length; row++) {
            if (dashBoard[0][row] === marker && dashBoard[1][row] === marker && dashBoard[2][row] === marker) {
                hasWin = true;
                break;
            }
        }

        if ((dashBoard[0][0] === marker && dashBoard[1][1] === marker && dashBoard[2][2] === marker)
            || (dashBoard[0][2] === marker && dashBoard[1][1] === marker && dashBoard[2][0] === marker)) {
            hasWin = true;
        }

        return hasWin;
    }

    function isFreeSpaceLeft(dashBoard) {
        for (let row = 0; row < dashBoard.length; row++) {
            if (dashBoard[row].some(x => !x)) {
                return true;
            }
        }

        return false;
    }

    function printBoard(dashBoard) {
        for (let row = 0; row < dashBoard.length; row++) {
            console.log(dashBoard[row].join('\t'));
        }
    }
}

play(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]);

console.log('------------------');

play(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]);

console.log('------------------');

play(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]);