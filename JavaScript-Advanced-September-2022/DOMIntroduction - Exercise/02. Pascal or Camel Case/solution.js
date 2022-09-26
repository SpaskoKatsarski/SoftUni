function solve() {
  let text = document.getElementById('text').value;
  let typeCase = document.getElementById('naming-convention').value;
  let textArr = text.split(' ').map(w => w.toLowerCase());
  let result = '';

  if (typeCase === 'Camel Case') {
    result += textArr[0];

    for (let i = 1; i < textArr.length; i++) {
      result += textArr[i][0].toUpperCase() + textArr[i].substring(1);
    }
  } else if (typeCase === 'Pascal Case') {
    for (let i = 0; i < textArr.length; i++) {
      result += textArr[i][0].toUpperCase() + textArr[i].substring(1);
    }
  } else {
    result = 'Error!'
  }

  document.getElementById('result').textContent = result;
}