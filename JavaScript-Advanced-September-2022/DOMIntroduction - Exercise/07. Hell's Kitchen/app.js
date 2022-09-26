function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let result = [];

   function onClick() {
      let input = JSON.parse(document.getElementById('inputs').children[1].value);
      let bestRestaurantInfo = document.querySelector('#bestRestaurant p');
      let bestResWorkers = document.querySelector('#workers p');

      for (let data of input) {
         let [restaurant, workersList] = data.split(' - ');
         if (!result.find(e => e.restaurant === restaurant)) {
            result.push({
               restaurant,
               avgSalary: 0,
               highestSalary: 0,
               totalSalary: 0,
               workers: []
            });
         }

         let currRestaurant = result.find(e => e.restaurant === restaurant);
         workersList = workersList && workersList.split(', ');

         for (let worker of workersList) {
            updateRestaurant(currRestaurant, worker);
         }
      }

      let bestRestaurant = result.sort((a, b) => b.avgSalary - a.avgSalary)[0];
      bestRestaurantInfo.textContent = `Name: ${bestRestaurant.restaurant} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.highestSalary.toFixed(2)}`;

      let bestWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);
      let workersOuput = '';

      for (let worker of bestWorkers) {
         workersOuput += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }

      bestResWorkers.textContent += workersOuput.trimEnd();
   }

   function updateRestaurant(restaurant, worker) {
      let [name, salary] = worker.split(' ');
      salary = Number(salary);
      restaurant.totalSalary += salary;

      if (restaurant.highestSalary < salary) {
         restaurant.highestSalary = salary;
      }

      restaurant.workers.push({
         name,
         salary
      });

      restaurant.avgSalary = restaurant.totalSalary / restaurant.workers.length;
   }
}