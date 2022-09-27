function solve() {
    document.querySelector('#container button').addEventListener('click', convert)

    let selectorTo = document.getElementById("selectMenuTo");

    let optionBinary = document.createElement('option');
    let optionHexadecimal = document.createElement('option');

    optionBinary.text = 'Binary';
    optionBinary.value = 'binary';

    optionHexadecimal.text = 'Hexadecimal';
    optionHexadecimal.value = 'hexadecimal';

    selectorTo.add(optionBinary);
    selectorTo.add(optionHexadecimal);

    function convert() {
        let input = document.getElementById('selectMenuTo').value;
        let value = parseFloat(document.getElementById('input').value);
        let result = '';

        if (input === 'binary') {
            result = convertToBinary(value).toString();
        }

        document.getElementById('result').text = result;

        function convertToBinary(x) {
            let bin = 0;
            let rem, i = 1, step = 1;
            while (x != 0) {
                rem = x % 2;
                x = parseInt(x / 2);
                bin = bin + rem * i;
                i = i * 10;
            }

            return bin;
        }
    }
}