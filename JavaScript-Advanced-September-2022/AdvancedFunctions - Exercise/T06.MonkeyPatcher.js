function solution(arg) {
    if (arg === 'upvote') {
        this.upvotes++;
    } else if (arg === 'downvote') {
        this.downvotes++;
    } else if (arg === 'score') {
        let bonus = 0;

        if (this.upvotes + this.downvotes > 50) {
            let biggerVal = Math.max(this.upvotes, this.downvotes);

            bonus = Math.ceil(0.25 * biggerVal);
        }

        let obfuscatedUpvotes = this.upvotes + bonus;
        let obfuscatedDownvotes = this.downvotes + bonus;

        let res = [];
        let totalVotes = obfuscatedUpvotes + obfuscatedDownvotes;

        res.push(obfuscatedUpvotes);
        res.push(obfuscatedDownvotes);

        let balance = obfuscatedUpvotes - obfuscatedDownvotes;
        res.push(balance);
        
        let rating = '';

        if (obfuscatedUpvotes > totalVotes * 0.66) {
            rating = 'hot';
        } else if (balance >= 0 && (this.upvotes > 100 || this.downvotes > 100)) {
            rating = 'controversial';
        } else if (balance < 0) {
            rating = 'unpopular';
        } else if (balance < 10) {
            rating = 'new';
        }

        res.push(rating);

        return res;
    }
}