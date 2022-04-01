using System;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.Modules.Manifest
{
    /// <summary>
    /// Defines a Module which is composed of features. If the Module has only one default
    /// feature, it may be defined there.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class ModuleAttribute : FeatureAttribute
    {
        /// <summary>
        /// &quot;&quot;
        /// </summary>
        internal const string DefaultAuthor = "";

        /// <summary>
        /// &quot;&quot;
        /// </summary>
        internal const string DefaultWebsiteUrl = "";

        /// <summary>
        /// &quot;0.0&quot;
        /// </summary>
        internal const string DefaultVersionZero = "0.0";

        /// <summary>
        /// &quot;&quot;
        /// </summary>
        internal const string DefaultTags = "";

        /// <summary>
        /// Default parameterless ctor.
        /// </summary>
        public ModuleAttribute() : this(DefaultName, DefaultName)
        {
        }

        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="id">The identifier for the Module.</param>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
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
        public ModuleAttribute(
            string id
            , string name
            , string description = DefaultDescription
            , string author = DefaultAuthor
            , string semVer = DefaultVersionZero
            , string featureDependencies = DefaultFeatureDependencies
            , string websiteUrl = DefaultWebsiteUrl
            , string tags = DefaultTags
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        ) : this(
            id
            , name
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
        /// <param name="id">The identifier for the Module.</param>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
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
        public ModuleAttribute(
            string id
            , string name
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
            id
            , name
            , category
            , description
            , featureDependencies
            , defaultTenant
            , alwaysEnabled
        )
        {
            Author = author;
            Website = websiteUrl;
            Version = semVer;
            DelimitedTags = tags;
        }

        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="id">The identifier for the Module.</param>
        /// <param name="name">The feature name, defaults to <see cref="FeatureAttribute.Id"/>
        /// when null or blank.</param>
        /// <param name="category">A simple feature category.</param>
        /// <param name="priority">Priority for the Module.</param>
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
        public ModuleAttribute(
            string id
            , string name
            , string category
            , string priority
            , string description = DefaultDescription
            , string author = DefaultAuthor
            , string semVer = DefaultVersionZero
            , string featureDependencies = DefaultFeatureDependencies
            , string websiteUrl = DefaultWebsiteUrl
            , string tags = DefaultTags
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        ) : base(
            id
            , name
            , category
            , priority
            , description
            , featureDependencies
            , defaultTenant
            , alwaysEnabled
        )
        {
            Author = author;
            Website = websiteUrl;
            Version = semVer;
            DelimitedTags = tags;
        }

        /// <summary>
        /// Returns the <see cref="System.Reflection.MemberInfo.Name"/> less the
        /// <see cref="Attribute"/> suffix when present.
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        protected internal static string GetAttributePrefix(Type attributeType)
        {
            const string attributeSuffix = nameof(Attribute);

            // Drops the 'Attribute' suffix from the conventional abbreviation, or leaves it alone
            static string GetTypeNamePrefix(string typeName) =>
                typeName.EndsWith(attributeSuffix)
                ? typeName.Substring(0, typeName.Length - attributeSuffix.Length)
                : typeName
                ;

            return GetTypeNamePrefix(attributeType.Name);
        }

        private string _type;

        /// <summary>
        /// Logical id allowing a module project to change its &apos;AssemblyName&apos; without
        /// having to update the code. If not provided, the assembly name will be used. Override
        /// in order to specify a name other than &quot;Module&quot;.
        /// </summary>
        public virtual string Type
        {
            get => _type ??= GetAttributePrefix(GetType());
            set
            {
                _type = value;

                if (_type != null)
                {
                    _type = _type.Trim();
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the developer.
        /// </summary>
        /// <see cref="DefaultAuthor" />
        public virtual string Author { get; set; } = DefaultAuthor;

        /// <summary>
        /// Gets or sets the URL for the website of the developer.
        /// </summary>
        /// <see cref="DefaultWebsiteUrl" />
        public virtual string Website { get; set; } = DefaultWebsiteUrl;

        /// <summary>
        /// Gets or sets the Semantic Version string.
        /// </summary>
        /// <see cref="!:https://semver.org">Semantic Versioning</see>
        /// <see cref="DefaultVersionZero" />
        public virtual string Version { get; set; } = DefaultVersionZero;

        /// <summary>
        /// Set-only <see cref="Tags"/> property.
        /// </summary>
        private string DelimitedTags
        {
            set => Tags = (value ?? DefaultTags).Trim().Split(ListDelims, DefaultSplitOptions);
        }

        private string[] _tags = GetValues<string>().ToArray();

        /// <summary>
        /// Gets or sets an array of enumerated Tags.
        /// </summary>
        public virtual string[] Tags
        {
            get => _tags;
            set => (value ?? GetValues<string>()).Select(_ => _.Trim()).ToArray();
        }

        /// <summary>
        /// Gets a list of Features attributes associated with the Module.
        /// </summary>
        public virtual List<FeatureAttribute> Features { get; } = GetValues<FeatureAttribute>().ToList();
    }
}
