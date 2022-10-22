class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        for (const p of footballPlayers) {
            let info = p.split('/');

            let name = info[0];
            let age = Number(info[1]);
            let playerValue = Number(info[2]);

            let player = this.invitedPlayers.find(p => p.name === name);

            if (player) {
                if (value > player.playerValue) {
                    player.playerValue = playerValue;
                }
            } else {
                this.invitedPlayers.push({
                    name,
                    age,
                    playerValue
                })
            }
        }

        let names = [];
        this.invitedPlayers.forEach(p => names.push(p.name));

        return `You successfully invite ${names.join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let info = selectedPlayer.split('/');
        
        let name = info[0];
        let playerOffer = Number(info[1]);

        let player = this.invitedPlayers.find(p => p.name === name);

        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (playerOffer < player.playerValue) {
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.playerValue - playerOffer} million more are needed to sign the contract!`)
        }

        player.playerValue = 'Bought';

        return `Congratulations! You sign a contract with ${player.name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age) {
        let player = this.invitedPlayers.find(p => p.name === name);

        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (player.age < age) {
            let diff = age - player.age;

            if (diff < 5) {
                return `${player.name} will sign a contract for ${diff} years with ${this.clubName} in ${this.country}!`
            }

            if (diff > 5) {
                return `${player.name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
        }

        if (player.age >= age) {
            return `${player.name} is above age limit!`;
        }
    }

    transferWindowResult() {
        let result = [];
        result.push('Players list:');

        for (const p of this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))) {
            result.push(`Player ${p.name}-${p.playerValue}`);
        }

        return result.join('\n');
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());