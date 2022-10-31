function loadRepos() {
   let url = 'https://api.github.com/users/testnakov/repos';
   let divElement = document.getElementById('res');

   fetch(url)
      .then(handleResponse)
      .then(handleData);

   function handleResponse(response) {
      if (!response.ok) {
         throw new Error(`Error: ${response.status} ${response.statusText}`);
      }

      return response.json();
   }

   function handleData(data) {
      for (const repo of data) {
         divElement.textContent += JSON.stringify(repo)
      }
   }
}