using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Models.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		[ValidateNever] // to not ever validate this property
		public IEnumerable<SelectListItem> CategoryList { get; set; }
	}
}

