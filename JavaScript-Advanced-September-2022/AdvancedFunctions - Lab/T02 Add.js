function solution(counter) {
    return (num) => counter + num;
}

console.log(solution(5)(3));
console.log(solution(5)(2));