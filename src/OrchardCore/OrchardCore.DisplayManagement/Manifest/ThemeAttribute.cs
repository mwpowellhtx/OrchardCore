using System;

namespace OrchardCore.DisplayManagement.Manifest
{
    using Modules.Manifest;

    /// <summary>
    /// Defines a Theme which is a dedicated Module for theming purposes.
    /// If the Theme has only one default feature, it may be defined there.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class ThemeAttribute : ModuleAttribute
    {
        /// <summary>
        /// &quot;&quot;
        /// </summary>
        internal const string DefaultBaseTheme = "";

        // Avoids ambiguities:
        /// <summary>
        /// Default parameterless ctor.
        /// </summary>
        public ThemeAttribute() : this(name: DefaultName, category: DefaultCategory, DefaultBaseTheme)
            //                         ^^^^^              ^^^^^^^^^
        {
        }

        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
        /// <param name="baseTheme">The base theme.</param>
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
        public ThemeAttribute(
            string name
            , string baseTheme
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
            , DefaultCategory
            , baseTheme
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
        /// <param name="category">A simple feature category.</param>
        /// <param name="baseTheme">The base theme.</param>
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
        public ThemeAttribute(
            string name
            , string category
            , string baseTheme
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
            BaseTheme = baseTheme;
        }

        //// TODO: TBD: handled exclusively at the base class level
        //public override string Type => "Theme";

        private string _baseTheme;

        /// <summary>
        /// Gets or sets the Base Theme if the theme is derived from an existing one.
        /// </summary>
        public string BaseTheme
        {
            get => _baseTheme;
            // Only case we need to be concerned about is Null, everything else we Trim up front
            set => _baseTheme = (value ?? DefaultBaseTheme).Trim();
        }
    }
}
