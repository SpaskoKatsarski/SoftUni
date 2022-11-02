function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const loadBtn = document.getElementById('btnLoadPosts');
    loadBtn.addEventListener('click', loadPosts);

    const viewBtn = document.getElementById('btnViewPost');
    viewBtn.addEventListener('click', viewPosts);

    const postsEl = document.getElementById('posts');

    async function viewPosts(event) {
        
        let currId = postsEl.options[postsEl.selectedIndex].value;
        console.log(currId);

        let response = await fetch(commentsUrl + '/' + currId); // Here is the problem with the id that we set on row 32
        let data = await response.json();
    }

    function loadPosts() {
        fetch(postsUrl)
            .then(r => r.json())
            .then(handlePostsData);
    }

    function handlePostsData(data) {
        let options = [];

        for (const post in data) {
            let id = post;
            let title = data[post].title;

            let option = document.createElement('option');
            option.value = id;
            option.textContent = title;

            options.push(option);
        }
        postsEl.replaceChildren(...options);
    }
}

attachEvents();