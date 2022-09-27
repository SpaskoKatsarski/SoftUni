function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let elements = Array.from(document.querySelectorAll('tbody tr'));
      let inputText = document.getElementById('searchField').value; 

      elements.map(e => {
         e.className = '';
      });

      if (inputText === '') {
         return;
      }
      
      for (let i = 0; i < elements.length; i++) {
         let currTr = elements[i];

         let name = currTr.cells[0].childNodes[0].data;
         let email = currTr.cells[1].childNodes[0].data;
         let course = currTr.cells[2].childNodes[0].data;

         if (name.includes(inputText) || email.includes(inputText) || course.includes(inputText)) {
            currTr.className = 'select';
         }
      }
   }
}