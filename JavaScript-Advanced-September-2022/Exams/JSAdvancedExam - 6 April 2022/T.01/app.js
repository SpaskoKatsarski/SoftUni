window.addEventListener("load", solve);

function solve() {
  document.getElementById('publish-btn').addEventListener('click', sendPost);

  let titleEl = document.getElementById('post-title');
  let categoryEl = document.getElementById('post-category');
  let contentEl = document.getElementById('post-content');

  let reviewList = document.getElementById('review-list');
  let publishList = document.getElementById('published-list');

  document.getElementById('clear-btn').addEventListener('click', clear);

  function clear() {
    Array.from(publishList.children).forEach(e => e.remove());
  }

  function sendPost() {
    let title = titleEl.value;
    let category = categoryEl.value;
    let content = contentEl.value;

    if (!title || !category || !content) {
      return;
    }

    let li = document.createElement('li');
    li.classList.add('rpost');

    let article = document.createElement('article');

    let contetH = document.createElement('h4');
    let categoryP = document.createElement('p');
    let contentP = document.createElement('p');

    contetH.textContent = title;
    categoryP.textContent = `Category: ${category}`;
    contentP.textContent = `Content: ${content}`;

    let editBtn = document.createElement('button');
    let approveBtn = document.createElement('button');

    editBtn.textContent = 'Edit';
    editBtn.setAttribute('class', 'action-btn edit');
    editBtn.addEventListener('click', edit);

    approveBtn.setAttribute('class', 'action-btn approve');
    approveBtn.textContent = 'Approve'
    approveBtn.addEventListener('click', approve);

    article.appendChild(contetH);
    article.appendChild(categoryP);
    article.appendChild(contentP);

    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(approveBtn);
    
    reviewList.appendChild(li);

    titleEl.value = '';
    categoryEl.value = '';
    contentEl.value = '';

    function edit(event) {
      let info = event.target.parentElement.getElementsByTagName('article')[0].children;

      debugger;
      let titleText = info[0].textContent;
      let categoryText = info[1].textContent.split('Category:')[1].substring(1);
      let contentText = info[2].textContent.split('Content:')[1].substring(1);;

      titleEl.value = titleText;
      categoryEl.value = categoryText;
      contentEl.value = contentText;

      event.target.parentElement.remove();
    }

    function approve(event) {
      let li = event.target.parentElement;

      let buttons = Array.from(li.getElementsByTagName('button'));

      for (let b of buttons) {
        b.remove();
      }

      publishList.appendChild(li);

      event.target.parentElement.remove();
    }
  }
}