using System;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSpace.WebUI.Areas.Admin.ViewComponents.Admin
{
	public class _FooterViewComponentAdminLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

