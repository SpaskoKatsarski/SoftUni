function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const loadBtn = document.getElementById('btnLoadPosts');
    loadBtn.addEventListener('click', loadPosts);

    const viewBtn = document.getElementById('btnViewPost');
    viewBtn.addEventListener('click', viewPosts);

    const postsEl = document.getElementById('posts');

    const titleEl = document.getElementById('post-title');
    const bodyEl = document.getElementById('post-body');
    const commentsEl = document.getElementById('post-comments');

    async function viewPosts() {
        let selectedOption = postsEl.selectedOptions[0].value;
        
        let postResponse = await fetch(postsUrl);
        let postData = await postResponse.json();

        let commentResponse = await fetch(commentsUrl);
        let commentData = await commentResponse.json();

        let selectedPost = Object.values(postData).find(p => p.id === selectedOption);
        titleEl.textContent = selectedPost.title;
        bodyEl.textContent = selectedPost.body;

        let comments = Object.values(commentData).filter(c => c.postId === selectedOption);
        let commentsList = comments.map(c => {
            let li = document.createElement('li');
            li.textContent = c.text;

            return li;
        });

        commentsEl.replaceChildren(...commentsList);
    }

    async function loadPosts() {
        let response = await fetch(postsUrl);
        let data = await response.json();
        
        postsEl.innerHTML = '';

        Object.values(data).forEach(p => {
            let option = document.createElement('option');
            option.value = p.id;
            option.textContent = p.title;

            postsEl.appendChild(option);
        })
    }
}

attachEvents();