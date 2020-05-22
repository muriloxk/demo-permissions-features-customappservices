using System;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Features;

namespace Acme.BookStore.ExemplosService
{

    [Authorize(BookStorePermissions.NomeDaPermissao.Default)]
    public class ExemploFeatureService : BookStoreAppService
    {
       
        public ExemploFeatureService()
        {
        }

        [RequiresFeature("BooleanFeature")]
        public async Task GetExemploAsync()
        {
           await FeatureChecker.CheckEnabledAsync("BooleanFeature");
           var max = (await FeatureChecker.GetOrNullAsync("Max")).To<int>();

           //if(max <= AlgumRepositorio)...
        }
    }
}
