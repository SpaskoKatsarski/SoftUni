function createAssemblyLine() {
    let hasClima = function (obj) {
        obj.temp = 21;
        obj.tempSettings = 21;
        obj.adjustTemp = function () {
            if (this.temp < this.tempSettings) {
                this.temp++;
            } else if (this.temp > this.tempSettings) {
                this.temp--;
            }
        }
    }

    let hasAudio = function (obj) {
        obj.currentTrack = {
            name : null,
            artist: null
        }
        obj.nowPlaying = function () {
            if (this.currentTrack !== null) {
                console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`);
            }
        }   
    }

    let hasParktronic = function (obj) {
        obj.checkDistance = (distance) => distance < 0.1 ? console.log('Beep! Beep! Beep!') 
        : distance >= 0.1 && distance < 0.25 ? console.log('Beep! Beep!')
        : distance >= 0.25 && distance < 0.5 ? console.log('Beep!')
        : console.log('');
    }

    return {
        hasClima,
        hasAudio,
        hasParktronic
    };
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();