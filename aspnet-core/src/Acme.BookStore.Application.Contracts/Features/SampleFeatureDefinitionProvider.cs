using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Features;
using Volo.Abp.Validation.StringValues;

namespace Acme.BookStore.Features
{
    public class SampleFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public SampleFeatureDefinitionProvider()
        {

        }

        public override void Define(IFeatureDefinitionContext context)
        {
            var sampleFeatureGroup = context.AddGroup("NomeDoGrupo");

            var feature = sampleFeatureGroup.AddFeature(name: "BooleanFeature",
                                          defaultValue: false.ToString().ToLowerInvariant(),
                                          valueType: new ToggleStringValueType());

           feature.CreateChild(name: "Max",
                               defaultValue: "10",
                               valueType: new FreeTextStringValueType(new NumericValueValidator(1, 1000)));
        }
    }
}
