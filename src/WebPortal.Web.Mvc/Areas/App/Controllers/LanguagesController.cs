using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Extensions;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebPortal.Authorization;
using WebPortal.Localization;
using WebPortal.Web.Areas.App.Models.Languages;
using WebPortal.Web.Controllers;

namespace WebPortal.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Languages)]
    public class LanguagesController : WebPortalControllerBase
    {
        private readonly ILanguageAppService _languageAppService;
        private readonly ILanguageManager _languageManager;
        private readonly IApplicationLanguageTextManager _applicationLanguageTextManager;

        public LanguagesController(
            ILanguageAppService languageAppService,
            ILanguageManager languageManager,
            IApplicationLanguageTextManager applicationLanguageTextManager)
        {
            _languageAppService = languageAppService;
            _languageManager = languageManager;
            _applicationLanguageTextManager = applicationLanguageTextManager;
        }

        public ActionResult Index()
        {
            var viewModel = new LanguagesIndexViewModel
            {
                IsTenantView = AbpSession.TenantId.HasValue
            };

            return View(viewModel);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Languages_Create, AppPermissions.Pages_Administration_Languages_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _languageAppService.GetLanguageForEdit(new NullableIdDto { Id = id });
            var viewModel = new CreateOrEditLanguageModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Languages_ChangeTexts)]
        public ActionResult Texts(
            string languageName, 
            string sourceName = "", 
            string baseLanguageName = "", 
            string targetValueFilter = "ALL", 
            string filterText = "")
        {
            //Normalize arguments
            if (sourceName.IsNullOrEmpty())
            {
                sourceName = WebPortalConsts.LocalizationSourceName;
            }

            if (baseLanguageName.IsNullOrEmpty())
            {
                baseLanguageName = _languageManager.CurrentLanguage.Name;
            }

            //Create view model
            var viewModel = new LanguageTextsViewModel();
            
            viewModel.LanguageName = languageName;

            viewModel.Languages = _languageManager.GetLanguages().ToList();

            viewModel.Sources = LocalizationManager
                .GetAllSources()
                .Where(s => s.GetType() == typeof (MultiTenantLocalizationSource))
                .Select(s => new SelectListItem()
                {
                    Value = s.Name, 
                    Text = s.Name, 
                    Selected = s.Name == sourceName
                })
                .ToList();

            viewModel.BaseLanguageName = baseLanguageName;

            viewModel.TargetValueFilter = targetValueFilter;
            viewModel.FilterText = filterText;

            return View(viewModel);            
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Languages_ChangeTexts)]
        public PartialViewResult EditTextModal(
            string sourceName, 
            string baseLanguageName, 
            string languageName,
            string key)
        {
            var languages = _languageManager.GetLanguages();

            var baselanguage = languages.FirstOrDefault(l => l.Name == baseLanguageName);
            if (baselanguage == null)
            {
                throw new Exception("Could not find language: " + baseLanguageName);
            }

            var targetLanguage = languages.FirstOrDefault(l => l.Name == languageName);
            if (targetLanguage == null)
            {
                throw new Exception("Could not find language: " + languageName);
            }

            var baseText = _applicationLanguageTextManager.GetStringOrNull(
                AbpSession.TenantId,
                sourceName,
                CultureInfoHelper.Get(baseLanguageName),
                key
                );

            var targetText = _applicationLanguageTextManager.GetStringOrNull(
                AbpSession.TenantId,
                sourceName,
                CultureInfoHelper.Get(languageName),
                key,
                false
                );

            var viewModel = new EditTextModalViewModel
            {
                SourceName = sourceName,
                BaseLanguage = baselanguage,
                TargetLanguage = targetLanguage,
                BaseText = baseText,
                TargetText = targetText,
                Key = key
            };

            return PartialView("_EditTextModal", viewModel);
        }
    }
}