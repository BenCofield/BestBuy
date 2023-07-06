using System;
namespace BestBuy.Models.ViewModels
{
	public class CreateProductViewModel : BaseViewModel
	{
		public Product Product { get; set; }

		public List<Category> Categories { get; set; }


	}
}

