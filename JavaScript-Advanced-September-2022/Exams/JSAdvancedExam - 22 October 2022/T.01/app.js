window.addEventListener("load", solve);

function solve() {
  let fNameInput = document.getElementById('first-name');
  let lNameInput = document.getElementById('last-name');
  let ageInput = document.getElementById('age');
  let storyTitleInput = document.getElementById('story-title');
  let genreInput = document.getElementById('genre');
  let storyTextInput = document.getElementById('story');

  let publishBtn = document.getElementById('form-btn');
  let previewList = document.getElementById('preview-list');
  let mainDiv = document.getElementById('main');

  publishBtn.addEventListener('click', attach);

  function attach() {
    let firstName = fNameInput.value;
    let lastName = lNameInput.value;
    let age = ageInput.value;
    let storyTitle = storyTitleInput.value;
    let genre = genreInput.value;
    let storyText = storyTextInput.value;

    if (!firstName || !lastName || !age || !storyTitle || !storyText) {
      return;
    }

    fNameInput.value = '';
    lNameInput.value = '';
    ageInput.value = '';
    storyTitleInput.value = '';
    genreInput.value = '';
    storyTextInput.value = '';

    publishBtn.disabled = true;

    let li = document.createElement('li');
    li.classList.add('story-info');

    let article = document.createElement('article');
    
    let nameHeader = document.createElement('h4');
    nameHeader.textContent = `Name: ${firstName} ${lastName}`;

    let ageP = document.createElement('p');
    ageP.textContent = `Age: ${age}`;

    let titleP = document.createElement('p');
    titleP.textContent = `Title: ${storyTitle}`;

    let genreP = document.createElement('p');
    genreP.textContent = `Genre: ${genre}`;

    let textP = document.createElement('p');
    textP.textContent = storyText;

    article.appendChild(nameHeader);
    article.appendChild(ageP);
    article.appendChild(titleP);
    article.appendChild(genreP);
    article.appendChild(textP);

    let editBtn = document.createElement('button');

    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit Story';
    editBtn.addEventListener('click', edit);

    let saveBtn = document.createElement('button');

    saveBtn.classList.add('save-btn');
    saveBtn.textContent = 'Save Story';
    saveBtn.addEventListener('click', save);

    let deletBtn = document.createElement('button');

    deletBtn.classList.add('delete-btn');
    deletBtn.textContent = 'Delete Story';
    deletBtn.addEventListener('click', deleteStory);

    li.appendChild(article);
    li.appendChild(saveBtn);
    li.appendChild(editBtn);
    li.appendChild(deletBtn);

    previewList.appendChild(li);

    function edit(e) {
      let currArticle = e.target.parentElement.getElementsByTagName('article')[0];
      let articleChildren = currArticle.children;

      let names = articleChildren[0].textContent.split('Name: ')[1];
      let firstN = names.split(' ')[0];
      let secondName = names.split(' ')[1];
      fNameInput.value = firstN;
      lNameInput.value = secondName;

      let currAge = articleChildren[1].textContent.split('Age: ')[1];
      ageInput.value = currAge;

      let currTitle = articleChildren[2].textContent.split('Title: ')[1];
      storyTitleInput.value = currTitle;

      let currGenre = articleChildren[3].textContent.split('Genre: ')[1];
      genreInput.value = currGenre;

      let currStrText = articleChildren[4].textContent;
      storyTextInput.value = currStrText;

      e.target.parentElement.remove();
      publishBtn.disabled = false;
    }

    function save() {
      mainDiv.innerHTML = '<h1>Your scary story is saved!</h1>';
    }

    function deleteStory(e) {
      e.target.parentElement.remove();
      publishBtn.disabled = false;
    }
  }
}
