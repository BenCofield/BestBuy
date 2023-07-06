using System;
namespace BestBuy.Models.ViewModels
{
	public class BaseViewModel
	{
		public bool IsError { get; set; }
		public List<string> ErrorMsgs { get; set; }
		public List<string> UserRoles { get; set; }
	}
}

