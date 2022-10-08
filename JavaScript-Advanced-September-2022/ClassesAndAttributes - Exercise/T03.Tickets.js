function solve(ticketsInput, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let sortedTickets = [];

    for (const ticketInfo of ticketsInput) {
        let ticket = ticketInfo.split('|');

        let destination = ticket[0];
        let price = Number(ticket[1]);
        let status = ticket[2];

        sortedTickets.push(new Ticket(destination, price, status));
    }

    if (criteria === 'destination') {
        return sortedTickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (criteria === 'price') {
        return sortedTickets.sort((a, b) => a - b);
    } else if (criteria === 'status') {
        return sortedTickets.sort((a, b) => a.status.localeCompare(b.status));
    }
}