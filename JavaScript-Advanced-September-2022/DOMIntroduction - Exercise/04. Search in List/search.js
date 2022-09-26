function search() {
   let townList = Array.from(document.querySelectorAll('ul li'));

   let searchText = document.getElementById('searchText').value;
   let matches = 0;
   
   for (let town of townList) {
      let content = town.textContent;

      if (content.includes(searchText)) {
         matches++;
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
      } else {
         town.style.textDecoration = '';
         town.style.fontWeight = '';
      }
   }

   document.getElementById('result').textContent = `${matches} matches found`;
}
