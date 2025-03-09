using System;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSpace.WebUI.Areas.User.ViewComponents.User
{
	public class FooterViewComponentLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

