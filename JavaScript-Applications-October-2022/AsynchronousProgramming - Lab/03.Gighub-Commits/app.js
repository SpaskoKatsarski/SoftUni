function loadCommits() {
    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;
    let list = document.getElementById('commits');

    let api = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(api)
        .then(handleResponse)
        .then(handleData)
        .catch(handleError);

    function handleResponse(response) {
        if (!response.ok) {
            throw new Error(`Error: ${response.status} (Not Found)`);
        }

        return response.json();
    }

    function handleData(data) {
        let commits = data.map(c => {
            debugger;
            let li = document.createElement('li');
            li.textContent = `${c.commit.author.name}: ${c.commit.message}`;

            return li;
        });
        
        list.replaceChildren(...commits);
    }

    function handleError(error) {
        list.replaceChildren(error.message);
    }
}