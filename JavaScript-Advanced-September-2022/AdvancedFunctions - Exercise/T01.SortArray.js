function solve(arr, sortType) {
    return sortType === 'asc' ? arr.sort((a, b) => a - b) : arr.sort((a, b) => b - a);
}