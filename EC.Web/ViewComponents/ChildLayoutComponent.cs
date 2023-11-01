﻿using EC.Service;
using EC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EC.Web.ViewComponents
{
    public class ChildLayoutComponent : ViewComponent
    {
        #region Constructor
        private readonly ISettingService _settingService;
        public ChildLayoutComponent(ISettingService settingService)
        {
            _settingService = settingService;
        }
        #endregion

        #region Get Side bar Content
        public Task<IViewComponentResult> InvokeAsync()
        {
            SidebarViewModel model = new SidebarViewModel();
            var entity = _settingService.GetLogoSettingList();
            if (entity != null)
            {
                model.Logo = entity[0].ConfigValue;
                model.FaviconLogo = entity[1].ConfigValue;
            }
            return Task.FromResult<IViewComponentResult>(View("~/Areas/Admin/Views/Shared/_ChildLayout.cshtml", model));
        }
        #endregion
    }
}
