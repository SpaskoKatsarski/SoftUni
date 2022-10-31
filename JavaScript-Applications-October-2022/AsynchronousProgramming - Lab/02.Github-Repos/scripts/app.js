function loadRepos() {
	let list = document.getElementById('repos');
	let username = document.getElementById('username').value;
	let url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(handleResponse)
		.then(handleData);

	function handleResponse(response) {
		if (!response.ok) {
			let li = document.createElement('li');
			li.textContent = 'Invalid URL!';
			list.replaceChildren(li);

			// throw new Error(`Error: ${response.status} ${response.statusText}`);
		}

		return response.json();
	}

	function handleData(data) {
		let repos = data.map(repo => {
			let li = document.createElement('li');
			let a = document.createElement('a');

			a.href = repo.html_url;
			a.textContent = repo.full_name;

			li.appendChild(a);

			return li;
		});

		list.replaceChildren(...repos);
	}
}