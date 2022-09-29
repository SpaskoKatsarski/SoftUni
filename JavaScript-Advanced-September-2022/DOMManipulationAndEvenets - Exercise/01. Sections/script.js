function create(words) {
   let mainDiv = document.getElementById('content');

   for (const word of words) {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.textContent = word;
      p.style.display = 'none';

      div.appendChild(p);
      div.addEventListener('click', showText);
      
      mainDiv.appendChild(div);
   }

   function showText(event) {
      if (event.target.nodeName === 'P') {
         return;
      }

      event.target.children[0].style.display = 'block';
   }
}