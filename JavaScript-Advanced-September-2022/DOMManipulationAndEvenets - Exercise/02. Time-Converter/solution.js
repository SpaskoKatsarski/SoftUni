function attachEventsListeners() {
    //Make the input value to days (if hour button is clicked, get the value and give it to a funciton as value / 24)
    let buttons = document.querySelectorAll('input[type=button]')

    for (let button of buttons) {
        button.addEventListener('click', convert);
    }

    function convert(e) {
        let val = Number(e.target.parentElement.querySelectorAll('input[type=text]')[0].value);
        let caller = e.target.id;
        
        if (caller === 'hoursBtn') {
            val /= 24;
        } else if (caller === 'minutesBtn') {
            val = val / 24 / 60;
        } else if (caller === 'secondsBtn') {
            val = val / 24 / 60 / 60;
        }

        populate(val);
    }

    function populate(val) {
        let inputs = document.querySelectorAll('input[type=text]');

        inputs[0].value = val;
        val *= 24;

        for (let i = 1; i < inputs.length; i++) {
            inputs[i].value = val;
            val *= 60;
        }
    }
}