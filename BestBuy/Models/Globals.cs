using System;
namespace BestBuy.Models
{
	public static class Globals {
		public static int Yes = 1;
		public static int No = 0;
		public static Dictionary<int, string> YesNo = new Dictionary<int, string>()
		{
			{ 0, "No" },
			{ 1, "Yes" }
		};
		public enum YesOrNo
		{
			Yes = 1,
			No = 0
		}
	}

}

