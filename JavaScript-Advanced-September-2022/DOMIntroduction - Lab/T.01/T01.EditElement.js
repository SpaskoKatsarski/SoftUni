function edit(ref, match, replacer) {
    let result = '';
    let text = ref[0].textContent;

    ref.textContent = result.trimEnd();
}

edit(document.getElementsByTagName('H1'), '%page%', 'SITE');