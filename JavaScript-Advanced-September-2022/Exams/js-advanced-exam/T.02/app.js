class SmartHike {
    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [],
        this.resources = 100;
    }

    addGoal(peak, altitude) {
        if (this.goals.hasOwnProperty(peak)) {
            return `${peak} has already been added to your goals`;
        }

        this.goals[peak] = altitude;

        return `You have successfully added a new goal - ${peak}`;
    }

    hike(peak, time, difficultyLevel) {
        if (!this.goals.hasOwnProperty(peak)) {
            throw new Error(`${peak} is not in your current goals`);
        }

        if (this.resources === 0) {
            throw new Error('You don\'t have enough resources to start the hike');
        }

        const neededResources = time * 10;
        const diff = this.resources - neededResources;

        if (diff < 0) {
            return 'You don\'t have enough resources to complete the hike';
        }

        this.resources -= neededResources;

        this.listOfHikes.push({ peak, time, difficultyLevel });

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest(time) {
        this.resources += time * 10;

        if (this.resources >= 100) {
            this.resources = 100;
            return 'Your resources are fully recharged. Time for hiking!';
        }

        return `You have rested for ${time} hours and gained ${time * 10}% resources`;
    }

    showRecord(criteria) {
        if (this.listOfHikes.length == 0) {
            return `${this.username} has not done any hiking yet`;
        }

        if (criteria === 'all') {
            const result = [];
            result.push('All hiking records:');

            for (const hike of this.listOfHikes) {
                result.push(`${this.username} hiked ${hike.peak} for ${hike.time} hours`);
            }

            return result.join('\n');
        }

        if (!this.listOfHikes.find(h => h.criteria === criteria)) {
            return `${this.username} has not done any ${criteria} hiking yet`;
        }

        const bestHike = this.listOfHikes.filter(h => h.difficultyLevel === criteria).sort((a, b) => a.time - b.time)[0];
        
        return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`;
    }
}