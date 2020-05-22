using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Microsoft.Extensions.Options;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using Volo.Abp.Settings;
using Volo.Abp.Features;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations.ObjectExtending;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Acme.BookStore.ExemplosService
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAbpApplicationConfigurationAppService))]
    public class CustomAbpApplicationConfigurationAppService : AbpApplicationConfigurationAppService
    {

        private readonly ISettingProvider _settingProvider;
        private readonly ISettingDefinitionManager _settingDefinitionManager;
        private readonly ICachedObjectExtensionsDtoService _cachedObjectExtensionsDtoService;


        public CustomAbpApplicationConfigurationAppService(IOptions<AbpLocalizationOptions> localizationOptions,
                                                           IOptions<AbpMultiTenancyOptions> multiTenancyOptions,
                                                           IServiceProvider serviceProvider,
                                                           IAbpAuthorizationPolicyProvider abpAuthorizationPolicyProvider,
                                                           IAuthorizationService authorizationService,
                                                           ICurrentUser currentUser,
                                                           ISettingProvider settingProvider,
                                                           ISettingDefinitionManager settingDefinitionManager,
                                                           IFeatureDefinitionManager featureDefinitionManager,
                                                           ILanguageProvider languageProvider,
                                                           ICachedObjectExtensionsDtoService cachedObjectExtensionsDtoService) :
                                                                                                                                    base(localizationOptions,
                                                                                                                                         multiTenancyOptions,
                                                                                                                                         serviceProvider,
                                                                                                                                         abpAuthorizationPolicyProvider,
                                                                                                                                         authorizationService,
                                                                                                                                         currentUser,
                                                                                                                                         settingProvider,
                                                                                                                                         settingDefinitionManager,
                                                                                                                                         featureDefinitionManager,
                                                                                                                                         languageProvider,
                                                                                                                                         cachedObjectExtensionsDtoService)

        {
            _cachedObjectExtensionsDtoService = cachedObjectExtensionsDtoService;
            _settingProvider = settingProvider;
            _settingDefinitionManager = settingDefinitionManager;
        }

        public override async Task<ApplicationConfigurationDto> GetAsync()
        {
     

            Logger.LogDebug("Executing AbpApplicationConfigurationAppService.GetAsync()...");

            var result = new ApplicationConfigurationDto
            {
                Auth = await GetAuthConfigAsync(),
                Features = await GetFeaturesConfigAsync(),
                Localization = await GetLocalizationConfigAsync(),
                CurrentUser = GetCurrentUser(),
                Setting = await GetSettingConfigAsync(),
                MultiTenancy = GetMultiTenancy(),
                CurrentTenant = GetCurrentTenant(),
                ObjectExtensions = _cachedObjectExtensionsDtoService.Get()
            };

            Logger.LogDebug("Executed AbpApplicationConfigurationAppService.GetAsync().");

            return result;
        }


        private async Task<ApplicationSettingConfigurationDto> GetSettingConfigAsync()
        {
            var result = new ApplicationSettingConfigurationDto
            {
                Values = new Dictionary<string, string>()
            };

            foreach (var settingDefinition in _settingDefinitionManager.GetAll())
            {
                if (!settingDefinition.IsVisibleToClients)
                {
                    continue;
                }

                result.Values[settingDefinition.Name] = await _settingProvider.GetOrNullAsync(settingDefinition.Name);
            }

            return result;
        }
    }
}
