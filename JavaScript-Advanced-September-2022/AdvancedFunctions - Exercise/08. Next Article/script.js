function getArticleGenerator(articles) {
    let allArticles = Array.from(articles);
    let div = document.getElementById('content');

    return function showNext() {
        if (!allArticles.length){
            return;
        } 

        div.innerHTML += `<article>${allArticles.shift()}</article>`;
    }
}
