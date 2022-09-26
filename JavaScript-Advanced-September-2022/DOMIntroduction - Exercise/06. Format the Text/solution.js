// function solve() {
//   let input = document.getElementById('input').value;
//   let arrayText = input.split('. ').filter(e => e.length > 0);
//   let buff = '';

//   for (let i = 0; i < arrayText.length; i += 3) {
//     buff += '<p>';
//     for (let j = 0; j < 3; j++) {
//       if (j + i >= arrayText.length) {
//         break;
//       }

//       if (j + i === arrayText.length - 1) {
//         buff += arrayText[j + i]
//       } else {
//         buff += arrayText[j + i] + '. ';
//       }
      
//     }
//     buff = buff.trimEnd() + '</p>';
//     document.getElementById('output').innerHTML = buff;
//   }
// }

function solve() {
  document.getElementById('output').innerHTML = '';
  let input = document.getElementById('input').value;
  let arrText = input.split('.').filter(e => e.length > 0);

  for (let i = 0; i < arrText.length; i += 3) {
    let res = [];

    for (let j = 0; j < 3; j++) {
      if (arrText[i + j]) {
        res.push(arrText[i + j]);
      }
    }

    let resText = res.join('. ') + '.'.trim();
    document.getElementById('output').innerHTML += `<p>${resText}</p>`
  }
}