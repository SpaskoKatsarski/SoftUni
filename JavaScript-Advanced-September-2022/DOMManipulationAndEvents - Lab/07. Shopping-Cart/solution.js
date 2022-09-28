function solve() {
   let shoppingCart = document.getElementsByClassName('shopping-cart')[0];
   let resultArea = document.getElementsByTagName('textarea')[0];

   let products = [];
   let totalPrice = 0;

   let checkoutDone = false;
   let buttons = document.getElementsByTagName('button');

   shoppingCart.addEventListener('click', function (event) {
      if (checkoutDone) {
         for (let button of buttons) {
            button.attributes.add('disabled');
         }
      }

      if (event.target.nodeName !== 'BUTTON') {
         return;
      }

      let btn = event.target;
      if (Array.from(btn.classList).indexOf('checkout') >= 0) {
         let items = products.join(', ');
         resultArea.textContent += `You bought ${items} for ${totalPrice.toFixed(2)}.`;

         checkoutDone = true;
      }

      if (Array.from(btn.classList).indexOf('add-product') < 0) {
         return
      }

      let productElement = event.target.parentElement.parentElement;
      let title = productElement.querySelector('.product-title').textContent;
      let price = productElement.querySelector('.product-line-price').textContent;

      if (!products.includes(title)) {
         products.push(title);
      }

      totalPrice += Number(price);

      resultArea.textContent += `Added ${title} for ${price} to the cart.\n`
   })
}