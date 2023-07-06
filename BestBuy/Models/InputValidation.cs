using System;
namespace BestBuy.Models
{
	public static class InputValidation
	{
        public static List<string> ValidateChanges(Product product)
        {
            var errorMsgs = new List<string>();
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                errorMsgs.Add("Name cannot be empty");
            }
            if (product.Price < 0)
            {
                errorMsgs.Add("Price must be 0 or greater");
            }
            if (product.StockLevel < 0)
            {
                errorMsgs.Add("Stock level must be 0 or greater");
            }
            return errorMsgs;
        }
    }
}

