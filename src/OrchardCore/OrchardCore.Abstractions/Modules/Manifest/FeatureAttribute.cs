using System;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.Modules.Manifest
{
    using static StringSplitOptions;

    /// <summary>
    /// Defines a Feature in a Module, can be used multiple times.
    /// If at least one Feature is defined, the Module default feature is ignored.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class FeatureAttribute : Attribute
    {
        /// <summary>
        /// &quot;&quot;
        /// </summary>
        protected internal const string DefaultName = "";

        /// <summary>
        /// &quot;&quot;
        /// </summary>
        protected internal const string DefaultDescription = "";

        /// <summary>
        /// &quot;Uncategorized&quot;
        /// </summary>
        protected private const string Uncategorized = nameof(Uncategorized);

        /// <summary>
        /// &quot;&quot;
        /// </summary>
        protected internal const string DefaultCategory = "";

        /// <summary>
        /// &quot;&quot;
        /// </summary>
        protected internal const string DefaultFeatureDependencies = "";

        /// <summary>
        /// <c>false</c>
        /// </summary>
        protected internal const bool DefaultDefaultTenantOnly = false;

        /// <summary>
        /// <c>false</c>
        /// </summary>
        protected internal const bool DefaultAlwaysEnabled = false;

        /// <summary>
        /// Default parameterless ctor.
        /// </summary>
        public FeatureAttribute()
        {
        }

        /// <summary>
        /// Constructs an instance of the attribute with some default values.
        /// </summary>
        /// <param name="id">An identifier overriding the Name.</param>
        /// <param name="name">The feature name, defaults to <see cref="Id"/> when null or
        /// blank.</param>
        /// <param name="description">A simple feature description.</param>
        /// <param name="featureDependencies">Zero or more delimited feature dependencies,
        /// corresponding to each of the feature <see cref="Name"/> properties.</param>
        /// <param name="defaultTenant">Whether considered default tenant only.</param>
        /// <param name="alwaysEnabled">Whether feature is always enabled.</param>
        public FeatureAttribute(
            string id
            , string name
            , string description = DefaultDescription
            , string featureDependencies = DefaultFeatureDependencies
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        ) : this(
            id
            , name
            , DefaultCategory
            , description
            , featureDependencies
            , defaultTenant
            , alwaysEnabled
        )
        {
        }

        /// <summary>
        /// Constructs an instance of the attribute with some default values.
        /// </summary>
        /// <param name="id">An identifier overriding the Name.</param>
        /// <param name="name">The feature name, defaults to <see cref="Id"/> when null or
        /// blank.</param>
        /// <param name="category">A simple feature category.</param>
        /// <param name="description">A simple feature description.</param>
        /// <param name="featureDependencies">Zero or more delimited feature dependencies,
        /// corresponding to each of the feature <see cref="Name"/> properties.</param>
        /// <param name="defaultTenant">Whether considered default tenant only.</param>
        /// <param name="alwaysEnabled">Whether feature is always enabled.</param>
        public FeatureAttribute(
            string id
            , string name
            , string category
            , string description = DefaultDescription
            , string featureDependencies = DefaultFeatureDependencies
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        )
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            DelimitedDependencies = featureDependencies;
            DefaultTenantOnly = defaultTenant;
            IsAlwaysEnabled = alwaysEnabled;
        }

        /// <summary>
        /// Constructs an instance of the attribute with some default values.
        /// </summary>
        /// <param name="id">An identifier overriding the Name.</param>
        /// <param name="name">The feature name, defaults to <see cref="Id"/> when null or
        /// blank.</param>
        /// <param name="category">A simple feature category.</param>
        /// <param name="priority">The priority of the Feature.</param>
        /// <param name="description">A simple feature description.</param>
        /// <param name="featureDependencies">Zero or more delimited feature dependencies,
        /// corresponding to each of the feature <see cref="Name"/> properties.</param>
        /// <param name="defaultTenant">Whether considered default tenant only.</param>
        /// <param name="alwaysEnabled">Whether feature is always enabled.</param>
        public FeatureAttribute(
            string id
            , string name
            , string category
            , string priority
            , string description = DefaultDescription
            , string featureDependencies = DefaultFeatureDependencies
            , bool defaultTenant = DefaultDefaultTenantOnly
            , bool alwaysEnabled = DefaultAlwaysEnabled
        )
        {
            Id = id;
            Name = name;
            Category = category;
            Priority = priority;
            Description = description;
            DelimitedDependencies = featureDependencies;
            DefaultTenantOnly = defaultTenant;
            IsAlwaysEnabled = alwaysEnabled;
        }

        /// <summary>
        /// Whether the feature exists based on the <see cref="Id"/>.
        /// </summary>
        public virtual bool Exists => Id != null;

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        public virtual string Id { get; set; }

        private string _name;

        /// <summary>
        /// Gets or sets the human readable or canonical feature name. <see cref="Id"/> will be
        /// returned when not provided or blank.
        /// </summary>
        public virtual string Name
        {
            get => string.IsNullOrEmpty(_name) ? Id : _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets or sets a brief summary of what the feature does.
        /// </summary>
        public virtual string Description { get; set; } = DefaultDescription;

        /// <summary>
        /// Yields return of the <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        protected static IEnumerable<T> GetValues<T>(params T[] values)
        {
            foreach (var value in values)
            {
                yield return value;
            }
        }

        /// <summary>
        /// <see cref="TrimEntries"/> | <see cref="RemoveEmptyEntries"/>, trim the entries, and
        /// remove the empty ones.
        /// </summary>
        internal protected const StringSplitOptions DefaultSplitOptions = TrimEntries | RemoveEmptyEntries;

        /// <summary>
        /// Returns the <paramref name="delims"/> as an array of <see cref="char"/>.
        /// </summary>
        /// <param name="delims"></param>
        internal protected static char[] Delims(params char[] delims) => delims;

        /// <summary>
        /// Gets the default known ListDelims supporting <see cref="Dependencies"/> splits, etc.
        /// Semi-colon (&apos;;&apos;) delimiters are most common, expected from a <em>CSPROJ</em>
        /// perspective. Also common are comma (&apos;,&apos;) and space (&apos; &apos;)
        /// delimiters.
        /// </summary>
        /// <see cref="string.Split(char[], StringSplitOptions)"/>
        internal protected char[] ListDelims { get; } = Delims(';', ',', ' ');

        /// <summary>
        /// Set-only <see cref="Dependencies"/> property.
        /// </summary>
        private string DelimitedDependencies
        {
            set => Dependencies = (value ?? DefaultFeatureDependencies).Trim().Split(ListDelims, DefaultSplitOptions);
        }

        private string[] _dependencies = GetValues<string>().ToArray();

        /// <summary>
        /// Gets or sets an array of Feature Dependencies. Used to arrange drivers, handlers
        /// invoked during startup and so forth.
        /// </summary>
        public virtual string[] Dependencies
        {
            get => _dependencies;
            set => _dependencies = (value ?? GetValues<string>()).Select(_ => _.Trim()).ToArray();
        }

        /// <summary>
        /// 0
        /// </summary>
        protected internal const int DefaultPriority = 0;

        /// <summary>
        /// Gets or sets the feature priority without breaking the <see cref="Dependencies"/>
        /// order. The higher is the priority, the later the drivers / handlers are invoked.
        /// </summary>
        public virtual string Priority { get; set; } = $"{DefaultPriority}";

        /// <summary>
        /// Gets the <see cref="Priority"/>, parsed and ready to go for Internal use. May yield
        /// <c>null</c> when failing to <see cref="int.TryParse(string, out int)"/>.
        /// </summary>
        internal int? InternalPriority => int.TryParse(Priority, out var result) ? result : null;

        //// TODO: TBD: assuming 'Uncategorized' is 'Uncategorized' ...
        //// TODO: TBD: probably do not need cross-cutting AOP treatment for 'Uncategorized' Category in this regard...
        //private string _category;

        ///// <summary>
        ///// Supports grouping features by the Category to which a module belongs. Defaults to
        ///// &quot;Uncategorized&quot; when not provided.
        ///// </summary>
        //public virtual string Category
        //{
        //    get => string.IsNullOrEmpty(_category) ? DefaultDefaultCategory : _category;
        //    set => _category = value;
        //}

        /// <summary>
        /// 
        /// </summary>
        public virtual string Category { get; set; }

        /// <summary>
        /// Categorizes the <paramref name="feature"/> and <paramref name="module"/>, presents the
        /// <see cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <see cref="Category"/> that is not Null nor Empty, or returns <see cref="DefaultCategory"/>
        /// by default.
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static string Categorize(FeatureAttribute feature, ModuleAttribute module)
        {
            static bool IsNotNullOrEmpty(string value) => !string.IsNullOrEmpty(value);
            var categories = GetValues(feature, module).Select(_ => _.Category);
            return categories.Where(IsNotNullOrEmpty).FirstOrDefault() ?? DefaultCategory;
        }

        /// <summary>
        /// Set to <c>true</c> to only allow the <em>Default tenant to enable or disable</em> the feature.
        /// </summary>
        public virtual bool DefaultTenantOnly { get; set; }

        /// <summary>
        /// Once enabled, check whether the feature cannot be disabled. Defaults to <c>false</c>.
        /// </summary>
        public virtual bool IsAlwaysEnabled { get; set; } = false;
    }
}
