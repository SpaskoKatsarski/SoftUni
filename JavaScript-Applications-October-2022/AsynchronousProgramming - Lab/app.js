console.log('Before promise');

new Promise((resolve, reject) => {
    console.log('Start Executor');
    setTimeout(resolve, 2000, 'Yay!');
    console.log('End Executor');
}).then((res) => {
    console.log(res);
}).catch(onError);

console.log('After promise');

function onSuccess(res) {
    console.log(res)
}

function onError(error) {
    console.log('Error: ', error);
}

function wait() {
    return new Promise(resolve => setTimeout(resolve, 2000, 'resolved'));
}

console.log('before');

wait().then(v => console.log(v));

console.log('after');

async function start() {
    console.log('before');

    await wait().then(v => console.log(v));

    console.log('after');
}

start();