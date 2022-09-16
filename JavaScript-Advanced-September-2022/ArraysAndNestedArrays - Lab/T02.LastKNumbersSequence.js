function solve(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        let sum = 0;
        let counter = k;

        for (let j = i - 1; counter > 0; j--) {
            if (j < 0) {
                break;
            }

            sum += arr[j];
            counter--;
        }

        arr[i] = sum;
    }

    return arr;
}

solve(8, 2);