﻿using System;

namespace RomanticWeb
{
    using RomanticWeb.Mapping.Model;

    public abstract class TripleSourceFactoryBase:ITripleSourceFactory
	{
		public ITripleSource CreateTriplesSourceForOntology()
		{
			return CreateSourceForUnionGraph();
		}

		public ITripleSource CreateTriplesSourceForEntity<TEntity>(IMapping mappingFor) where TEntity : class
		{
			return CreateSourceForUnionGraph();
		}

		public ITripleSource CreateTripleSourceForProperty(EntityId entityId,IPropertyMapping property)
		{
			if (property.GraphSelector!=null)
			{
				var namedGraphUri=property.GraphSelector.SelectGraph(entityId);
				return CreateSourceForNamedGraph(namedGraphUri);
			}

			if (property.UsesUnionGraph)
			{
				return CreateSourceForUnionGraph();
			}

			return CreateSourceForDefaultGraph();
		}

		protected abstract ITripleSource CreateSourceForDefaultGraph();

		protected abstract ITripleSource CreateSourceForNamedGraph(Uri namedGraph);

		protected abstract ITripleSource CreateSourceForUnionGraph();
	}
}