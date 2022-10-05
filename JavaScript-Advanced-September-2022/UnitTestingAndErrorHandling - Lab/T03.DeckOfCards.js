function printDeckOfCards(cards) {
    let deck = [];
    let hasInvalidCard = false;

    for (const currCard of cards) {
        let face = currCard.substring(0, currCard.length - 1);
        let suit = currCard[currCard.length - 1];

        let card = createCard(face, suit);

        if (hasInvalidCard) {
            return;
        }

        deck.push(card);
    }

    console.log(deck.join(' '));

    function createCard(face, suit) {
        let cardFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let carSuits = ['S', 'H', 'D', 'C'];
    
        if (!cardFaces.includes(face) || !carSuits.includes(suit)) {
            console.log(`Invalid card: ${face}${suit}`);
            hasInvalidCard = true;
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
}

module.exports = { printDeckOfCards };