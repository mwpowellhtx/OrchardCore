using System;

namespace OrchardCore.Modules.Manifest
{
    /// <summary>
    /// Marks an assembly as a module of a given type, auto generated on building.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class ModuleMarkerAttribute : ModuleAttribute
    {
        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
        /// <param name="type">The overridden Type of the Module.</param>
        /// <param name="description">A simple feature description.</param>
        /// <param name="author">The module author name.</param>
        /// <param name="semVer">Semantic Version string.</param>
        /// <param name="featureDependencies">Zero or more delimited feature dependencies,
        /// corresponding to each of the feature <see cref="FeatureAttribute.Name"/>
        /// properties.</param>
        /// <param name="websiteUrl">The module website URL.</param>
        /// <param name="tags">Tags associated with the Module.</param>
        /// <param name="defaultTenant">Whether considered default tenant only.</param>
        /// <param name="alwaysEnabled">Whether feature is always enabled.</param>
        /// <see cref="!:https://semver.org">Semantic Versioning</see>
        /// <remarks>At least <paramref name="author" /> expected herein to differentiate with
        /// parameterless ctor.</remarks>
        public ModuleMarkerAttribute(
            string name
            , string type
            , string description = DefaultDescription
            , string author = DefaultAuthor
            , string semVer = DefaultVersionZero
            , string featureDependencies = DefaultFeatureDependencies
            , string websiteUrl = DefaultWebsiteUrl
            , string tags = DefaultTags
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        ) : this(
            name
            , type
            , DefaultCategory
            , description
            , author
            , semVer
            , featureDependencies
            , websiteUrl
            , tags
            , defaultTenant
            , alwaysEnabled
        )
        {
        }

        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
        /// <param name="type">The overridden Type of the Module.</param>
        /// <param name="category">A simple feature category.</param>
        /// <param name="description">A simple feature description.</param>
        /// <param name="author">The module author name.</param>
        /// <param name="semVer">Semantic Version string.</param>
        /// <param name="featureDependencies">Zero or more delimited feature dependencies,
        /// corresponding to each of the feature <see cref="FeatureAttribute.Name"/>
        /// properties.</param>
        /// <param name="websiteUrl">The module website URL.</param>
        /// <param name="tags">Tags associated with the Module.</param>
        /// <param name="defaultTenant">Whether considered default tenant only.</param>
        /// <param name="alwaysEnabled">Whether feature is always enabled.</param>
        /// <see cref="!:https://semver.org">Semantic Versioning</see>
        /// <remarks>At least <paramref name="author" /> expected herein to differentiate with
        /// parameterless ctor.</remarks>
        public ModuleMarkerAttribute(
            string name
            , string type
            , string category
            , string description = DefaultDescription
            , string author = DefaultAuthor
            , string semVer = DefaultVersionZero
            , string featureDependencies = DefaultFeatureDependencies
            , string websiteUrl = DefaultWebsiteUrl
            , string tags = DefaultTags
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        ) : base(
            name
            , category
            , description
            , author
            , semVer
            , featureDependencies
            , websiteUrl
            , tags
            , defaultTenant
            , alwaysEnabled
        )
        {
            Type = type;
        }

        /// <inheritdoc/>
        public override string Type { get; }
    }
}
