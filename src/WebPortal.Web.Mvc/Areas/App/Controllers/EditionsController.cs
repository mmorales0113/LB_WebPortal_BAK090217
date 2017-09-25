using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Authorization;
using WebPortal.Editions;
using WebPortal.Web.Areas.App.Models.Editions;
using WebPortal.Web.Controllers;

namespace WebPortal.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Editions)]
    public class EditionsController : WebPortalControllerBase
    {
        private readonly IEditionAppService _editionAppService;

        public EditionsController(IEditionAppService editionAppService)
        {
            _editionAppService = editionAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Editions_Create, AppPermissions.Pages_Editions_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _editionAppService.GetEditionForEdit(new NullableIdDto { Id = id });
            var editionItems = await _editionAppService.GetEditionComboboxItems();
            var freeEditionItems = await _editionAppService.GetEditionComboboxItems(output.Edition.ExpiringEditionId, false, true);

            var viewModel = new CreateOrEditEditionModalViewModel(output, editionItems, freeEditionItems);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}