using System;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSpace.WebUI.Areas.User.ViewComponents.User
{
	public class ScriptViewComponentLayout : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

