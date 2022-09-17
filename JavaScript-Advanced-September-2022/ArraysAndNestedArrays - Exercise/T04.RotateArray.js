function rotate(arr, times) {
    for (let i = 0; i < times; i++) {
        let el = arr.pop();
        arr.unshift(el);
    }

    console.log(arr.join(' '));
}

rotate(['1', 
'2', 
'3', 
'4'], 
2);