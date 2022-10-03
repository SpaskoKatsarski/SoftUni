function calculator() {
    let firstSelector = '';
    let secondSelector = '';
    let resSelector = '';

    return {
        init: (selector1, selector2, resultSelector) => {
            firstSelector = selector1;
            secondSelector = selector2;
            resSelector = resultSelector;
        },
        add: () => {
            let firstVal = Number(document.querySelector(firstSelector).value);
            let secondVal = Number(document.querySelector(secondSelector).value);
            let resultArea = document.querySelector(resSelector);

            resultArea.value = firstVal + secondVal;
        },
        subtract: () => {
            debugger;
            let firstVal = Number(document.querySelector(firstSelector).value);
            let secondVal = Number(document.querySelector(secondSelector).value);
            let resultArea = document.querySelector(resSelector);

            resultArea.value = firstVal - secondVal;
        }
    }
}

const calculate = calculator(); 
calculate.init('#num1', '#num2', '#result'); 