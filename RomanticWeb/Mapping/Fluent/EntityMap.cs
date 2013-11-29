﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using RomanticWeb.Mapping.Model;

namespace RomanticWeb.Mapping.Fluent
{
    /// <summary>
    /// Base class for fluently defining entity entityMappings
    /// </summary>
    public abstract class EntityMap<TEntity> : EntityMap
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMap{TEntity}"/> class.
        /// </summary>
		protected EntityMap()
			: base(typeof(TEntity))
		{
		}

        /// <summary>
        /// Gets a builder for mapping a property
        /// </summary>
		protected PropertyMap Property<TReturnType>(Expression<Func<TEntity, TReturnType>> prop)
		{
			var propertyMap = new PropertyMap(prop.ExtractPropertyInfo());

			MappedProperties.Add(propertyMap);

			return propertyMap;
		}

        /// <summary>
        /// Gets a builder for mapping a collecition property
        /// </summary>
        protected CollectionMap Collection<TReturnType>(Expression<Func<TEntity, TReturnType>> prop)
		{
			var propertyMap = new CollectionMap(prop.ExtractPropertyInfo());

			MappedProperties.Add(propertyMap);

			return propertyMap;
		}
	}

    /// <summary>
    /// Base class for fluently defining entity entityMappings
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules","SA1402:FileMayOnlyContainASingleClass",Justification="Generic and non-generic flavour of same class")]
    public abstract class EntityMap
    {
        private readonly IList<ClassMap> _classes;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMap"/> class.
        /// </summary>
        /// <param name="type">The mapped type.</param>
        protected EntityMap(Type type)
		{
			EntityType = type;
			MappedProperties = new List<PropertyMap>();
            _classes=new List<ClassMap>();
		}

		internal Type EntityType { get; set; }

		internal IList<PropertyMap> MappedProperties { get; private set; }

        /// <summary>
        /// Gets a builder for mapping the type
        /// </summary>
        protected ClassMap Class
        {
            get
            {
                var classMap=new ClassMap();
                _classes.Add(classMap);
                return classMap;
            }
        }

        internal EntityMapping CreateMapping(MappingContext mappingContext)
		{
            var classMappings=_classes.Select(cs => cs.GetMapping(mappingContext));
            var propertyMappings=MappedProperties.Select(mp=>mp.GetMapping(mappingContext));

            return new EntityMapping(classMappings,propertyMappings);
		}
	}
}
