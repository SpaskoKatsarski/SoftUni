function calculateTime(steps, footprint, speed) {
    let distanceInMeters = steps * footprint;
    let speedInMetersPerSec = speed / 3.6;
    let time = distanceInMeters / speedInMetersPerSec;
    let timeInMinutes = Math.floor(time / 60);

    let minutesToRest = Math.floor(distanceInMeters / 500);

    let timeInSeconds = Math.ceil(time - (timeInMinutes * 60));

    let timeInHours = Math.floor(timeInMinutes / 60);

    if(timeInMinutes + minutesToRest >= 60) {
        while(timeInMinutes + minutesToRest >= 60) {
            timeInHours++;
            timeInMinutes -= 60;
        }
    } else {
        timeInMinutes += minutesToRest;
    }

    let formattedHours = timeInHours < 10 ? `0${timeInHours}` : `${timeInHours}`; 
    let formattedMinutes = timeInMinutes < 10 ? `0${timeInMinutes}` : `${timeInMinutes}`; 
    let formattedSeconds = timeInSeconds < 10 ? `0${timeInSeconds}` : `${timeInSeconds}`; 

    console.log(`${formattedHours}:${formattedMinutes}:${formattedSeconds}`)
}   
calculateTime(4000, 0.60, 5);
calculateTime(2564, 0.70, 5.5);