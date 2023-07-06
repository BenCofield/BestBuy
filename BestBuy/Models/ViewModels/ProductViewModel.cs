using System;
namespace BestBuy.Models.ViewModels
{
	public class ProductsListViewModel : BaseViewModel
	{
		public List<Product> Products { get; set; }
		public string SearchTerms { get; set; }
	}
}

