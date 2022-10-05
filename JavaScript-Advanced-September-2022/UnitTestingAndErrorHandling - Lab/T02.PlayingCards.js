function solve(face, suit) {
    let cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let carSuits = ['S', 'H', 'D', 'C'];

    if (!cardFaces.includes(face) || !carSuits.includes(suit)) {
        throw new Error();
    }

    if (suit === 'S') {
        suit = '\u2660';
    } else if (suit === 'H') {
        suit = '\u2665';
    } else if (suit === 'D') {
        suit = '\u2666';
    } else {
        suit = '\u2663'
    }

    let card = {
        face,
        suit
    }

    card.toString = function () {
        return `${this.face}${this.suit}`;
    }

    return card;
}

console.log(solve('2', 'D'));