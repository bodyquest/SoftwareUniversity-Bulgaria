function getArticleGenerator(articles) {
    const div = document.getElementById('content');

    let i = 0;
    function nextArticle(){
        if (i >= articles.length) {
            return;
        }

        let html = 
    `<article>
        <p>
           ${articles[i++]} 
        </p>
    <article>`;

        div.innerHTML += html;
    }

    return nextArticle;
}
