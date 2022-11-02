function solution() {
    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let mainSection = document.getElementById('main');

    fetch(url)
        .then(r => r.json())
        .then(handleData);

    function handleData(data) {
        let items = data.map(v => {
            let accordionDiv = document.createElement('div');
            accordionDiv.classList.add('accordion');

            let headDiv = document.createElement('div');
            headDiv.classList.add('head');

            let span = document.createElement('span');
            span.textContent = v.title;

            let btn = document.createElement('button');
            btn.classList.add('button');
            btn.id = v._id;
            btn.textContent = 'More';

            btn.addEventListener('click', showMore);

            headDiv.appendChild(span);
            headDiv.appendChild(btn);

            let extraDiv = document.createElement('div');
            extraDiv.classList.add('extra');

            let paragraphEl = document.createElement('p');
            setDescription(v._id, paragraphEl);

            extraDiv.appendChild(paragraphEl);

            accordionDiv.appendChild(headDiv);
            accordionDiv.appendChild(extraDiv);

            return accordionDiv;
        })

        for (const item of items) {
            mainSection.appendChild(item);
        }

        function showMore(e) {
            let currDiv = e.target.parentElement.parentElement;

            if (e.target.textContent === 'More') {
                e.target.textContent = 'Less';
                currDiv.getElementsByTagName('div')[1].style.display = 'block';
            } else {
                e.target.textContent = 'More';
                currDiv.getElementsByTagName('div')[1].style.display = 'none';
            }
        }

        async function setDescription(id, element) {
            let itemUrl = 'http://localhost:3030/jsonstore/advanced/articles/details/';

            let response = await fetch(itemUrl + id);
            let data = await response.json();

            element.textContent = data.content;
        }
    }
}

solution();