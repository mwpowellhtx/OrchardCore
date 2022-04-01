using System;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.Environment.Extensions.Features
{
    using Modules.Manifest;

    public class FeaturesProvider : IFeaturesProvider
    {
        public const string FeatureProviderStateKey = "FeatureProvider:Features";

        private readonly IEnumerable<IFeatureBuilderEvents> _featureBuilderEvents;

        public FeaturesProvider(IEnumerable<IFeatureBuilderEvents> featureBuilderEvents)
        {
            _featureBuilderEvents = featureBuilderEvents;
        }

        public IEnumerable<IFeatureInfo> GetFeatures(IExtensionInfo extensionInfo, IManifestInfo manifestInfo)
        {
            var featuresInfos = new List<IFeatureInfo>();

            const int defaultPriority = FeatureAttribute.DefaultPriority;

            // Features and Dependencies live within this section
            var features = manifestInfo.ModuleInfo.Features.ToList();
            if (features.Count > 0)
            {
                foreach (var feature in features)
                {
                    if (String.IsNullOrWhiteSpace(feature.Id))
                    {
                        throw new ArgumentException(
                            $"A feature is missing a mandatory 'Id' property in the Module '{extensionInfo.Id}'");
                    }

                    // TODO: TBD: was there a migration path involving 'ModuleAttribute.Type' at any point?
                    // Attribute properties are now internally resolved for convenience
                    var featureId = feature.Id;
                    var featureName = feature.Name;

                    var featureDependencyIds = feature.Dependencies;

                    // Simplified dealing with Priority parsing, transparent now via the attribute itself
                    var featurePriority = feature.InternalPriority ?? manifestInfo.ModuleInfo.InternalPriority;

                    var featureCategory = FeatureAttribute.Categorize(feature, manifestInfo.ModuleInfo);
                    var featureDescription = feature.Description ?? manifestInfo.ModuleInfo.Description;
                    var featureDefaultTenantOnly = feature.DefaultTenantOnly;
                    var featureIsAlwaysEnabled = feature.IsAlwaysEnabled;

                    var context = new FeatureBuildingContext
                    {
                        FeatureId = featureId,
                        FeatureName = featureName,
                        Category = featureCategory,
                        Description = featureDescription,
                        ExtensionInfo = extensionInfo,
                        ManifestInfo = manifestInfo,
                        Priority = featurePriority ?? defaultPriority,
                        FeatureDependencyIds = featureDependencyIds,
                        DefaultTenantOnly = featureDefaultTenantOnly,
                        IsAlwaysEnabled = featureIsAlwaysEnabled
                    };

                    foreach (var builder in _featureBuilderEvents)
                    {
                        builder.Building(context);
                    }

                    // TODO: TBD: bit broader discussion, wondering whether FeatureInfo should just fall out of FeatureAttribute, in the aggregate
                    var featureInfo = new FeatureInfo(
                        context.FeatureId,
                        context.FeatureName,
                        context.Priority,
                        context.Category,
                        context.Description,
                        context.ExtensionInfo,
                        context.FeatureDependencyIds,
                        context.DefaultTenantOnly,
                        context.IsAlwaysEnabled);

                    foreach (var builder in _featureBuilderEvents)
                    {
                        builder.Built(featureInfo);
                    }

                    featuresInfos.Add(featureInfo);
                }
            }
            else
            {
                // The Extension has only one feature, itself, and that can have dependencies
                var featureId = extensionInfo.Id;
                var featureName = manifestInfo.Name;

                var featureDependencyIds = manifestInfo.ModuleInfo.Dependencies;
                var featurePriority = manifestInfo.ModuleInfo.InternalPriority;

                var featureCategory = manifestInfo.ModuleInfo.Category;
                var featureDescription = manifestInfo.ModuleInfo.Description;
                var featureDefaultTenantOnly = manifestInfo.ModuleInfo.DefaultTenantOnly;
                var featureIsAlwaysEnabled = manifestInfo.ModuleInfo.IsAlwaysEnabled;

                var context = new FeatureBuildingContext
                {
                    FeatureId = featureId,
                    FeatureName = featureName,
                    Category = featureCategory,
                    Description = featureDescription,
                    ExtensionInfo = extensionInfo,
                    ManifestInfo = manifestInfo,
                    Priority = featurePriority ?? defaultPriority,
                    FeatureDependencyIds = featureDependencyIds,
                    DefaultTenantOnly = featureDefaultTenantOnly,
                    IsAlwaysEnabled = featureIsAlwaysEnabled
                };

                foreach (var builder in _featureBuilderEvents)
                {
                    builder.Building(context);
                }

                var featureInfo = new FeatureInfo(
                    context.FeatureId,
                    context.FeatureName,
                    context.Priority,
                    context.Category,
                    context.Description,
                    context.ExtensionInfo,
                    context.FeatureDependencyIds,
                    context.DefaultTenantOnly,
                    context.IsAlwaysEnabled);

                foreach (var builder in _featureBuilderEvents)
                {
                    builder.Built(featureInfo);
                }

                featuresInfos.Add(featureInfo);
            }

            return featuresInfos;
        }
    }
}
