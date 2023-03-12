namespace FastFood.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        // List<string> to get the item name ? 
        public List<int> Items { get; set; } = null!;

        // TODO: change the List<int> to List<ViewModel>
        public List<int> Employees { get; set; } = null!;
    }
}
