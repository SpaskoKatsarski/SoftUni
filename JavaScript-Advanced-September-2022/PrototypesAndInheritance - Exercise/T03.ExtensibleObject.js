function extensibleObject() {
    let extend = function (temp) {

        for (let prp of Object.keys(temp)) {

            if (typeof (temp[prp]) === 'function') {
                Object.defineProperty(Object.getPrototypeOf(temp), prp, {
                    value: temp[prp]
                });
            } else {
                this[prp] = temp[prp];
            }

        }

    }

    return { extend };
}

const myObj = extensibleObject();

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
myObj.extend(template);

console.log(myObj);
