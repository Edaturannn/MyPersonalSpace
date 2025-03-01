using System;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSpace.WebUI.Areas.Admin.ViewComponents.Admin
{
	public class _HeadViewComponentAdminLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

