function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName('button');
    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);
    let textAreas = document.querySelectorAll('textArea');

    function encode() {
        textAreas = document.getElementsByTagName('textarea');
        let inputText = textAreas[0].value;
        
        let encodedText = '';

        for (let i = 0; i < inputText.length; i++) {
            encodedText += String.fromCharCode(inputText.charCodeAt(i) + 1);
        }

        textAreas[1].value = encodedText;
        textAreas[0].value = '';
        buttons[1].disabled = false;
    }

    function decode() {
        let textToDecode = textAreas[1].value;
        let result = '';

        for (let i = 0; i < textToDecode.length; i++) {
            result += String.fromCharCode(textToDecode.charCodeAt(i) - 1);
        }

        textAreas[1].value = result;
        buttons[1].disabled = true;
    }
}