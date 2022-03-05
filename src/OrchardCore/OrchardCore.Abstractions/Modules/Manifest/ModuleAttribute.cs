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
        /// Default author, empty string, &quot;&quot;.
        /// </summary>
        internal const string DefaultAuthor = "";

        /// <summary>
        /// Default website URL, empty string, &quot;&quot;.
        /// </summary>
        internal const string DefaultWebsiteUrl = "";

        /// <summary>
        /// Default version, zero, &quot;0.0&quot;.
        /// </summary>
        internal const string DefaultVersionZero = "0.0";

        /// <summary>
        /// Default parameterless ctor.
        /// </summary>
        public ModuleAttribute()
        {
        }

        // TODO: MWP: not sure how else to specify Features in this sense...
        // TODO: MWP: ...short of perhaps mixing tags and features in the same params object[] arg and discerning OfType and so forth
        /// <summary>
        /// Ctor allowing <paramref name="author"/>, as well as defaults for
        /// <paramref name="websiteUrl"/>, <paramref name="semVer"/>, and <paramref name="tags"/>.
        /// </summary>
        /// <param name="author">Author of the Module.</param>
        /// <param name="websiteUrl">Website URL for the Module.</param>
        /// <param name="semVer">Semantic Version string.</param>
        /// <param name="tags">Tags associated with the Module.</param>
        /// <see cref="!:https://semver.org">Semantic Versioning</see>
        /// <remarks>At least <paramref name="author" /> expected herein to differentiate with parameterless ctor.</remarks>
        public ModuleAttribute(string author, string websiteUrl = DefaultWebsiteUrl, string semVer = DefaultVersionZero, params string[] tags)
        {
            this.Author = author;
            this.Website = websiteUrl;
            this.Version = semVer;
            this.Tags = tags;
        }

        // TODO: MWP: is 'Type' really the best name here; speaking from experience under debugging confusion when the keyword TYPE is discovered
        // TODO: MWP: also not clear on its usage, should be be overridden, is it acceptable to derive a module specific ModuleAttribute class...
        // TODO: MWP: ...which is a whole other can of worms, IMO, especially if this is potentially consumed at the csproj level
        /// <summary>
        /// Logical id allowing a module project to change its &apos;AssemblyName&apos; without
        /// having to update the code. If not provided, the assembly name will be used. Override
        /// in order to specify a name other than &quot;Module&quot;.
        /// </summary>
        public virtual string Type => "Module";

        // TODO: MWP: this is a bit broader scope than first expected, for the team to consider...
        // TODO: MWP: is there a unique reason why these must be new properties? ought not this to work?
        // TODO: MWP: i.e. just because it is an Attribute, the same sort of virtual override principles still apply, yes?
        // TODO: MWP: in other words, public virtual bool FeatureAttribute.Exists { get; }
        // TODO: MWP: and, public override bool FeatureAttribute.Exists { get; }
        /// <summary>
        /// Gets whether the <see cref="Id" /> exists i.e. is not Null.
        /// </summary>
        /// <remarks>It is a new property overshadowing that of <see ="FeatureAttribute.Exists" />.</remarks>
        public new bool Exists => Id != null;

        // TODO: MWP: also it seems as though perhaps Id and Type are not so mutually exclusive?
        // TODO: MWP: clarification would be fantastic therein...
        /// <summary>
        /// Logical id allowing a module project to change its &apos;AssemblyName&apos; without
        /// having to update the code. If not provided, the assembly name will be used.
        /// </summary>
        /// <remarks>It is a new property overshadowing that of <see ="FeatureAttribute.Id" />.</remarks>
        public new string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the developer.
        /// </summary>
        /// <see cref="DefaultAuthor" />
        public string Author { get; set; } = DefaultAuthor;

        /// <summary>
        /// Gets or sets the URL for the website of the developer.
        /// </summary>
        /// <see cref="DefaultWebsiteUrl" />
        public string Website { get; set; } = DefaultWebsiteUrl;

        /// <summary>
        /// Gets or sets the Semantic Version string.
        /// </summary>
        /// <see cref="!:https://semver.org">Semantic Versioning</see>
        /// <see cref="DefaultVersionZero" />
        public string Version { get; set; } = DefaultVersionZero;

        /// <summary>
        /// Gets or sets an array of enumerated Tags.
        /// </summary>
        public string[] Tags { get; set; } = Enumerable.Empty<string>().ToArray();

        /// <summary>
        /// Gets a list of Features attributes associated with the Module.
        /// </summary>
        public List<FeatureAttribute> Features { get; } = Enumerable.Empty<FeatureAttribute>().ToList();
    }
}
