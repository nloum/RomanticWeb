﻿using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;
using RomanticWeb.Updates;

namespace RomanticWeb.Linq
{
    /// <summary>Provides an LINQ compatible access to the triple store.</summary>
    /// <typeparam name="T">Type of entities to be queried.</typeparam>
    public class EntityQueryable<T> : QueryableBase<T>
    {
        /// <summary>Creates an instance of the queryable entity factory.</summary>
        /// <param name="entityContext">Entity context to be used by this provider.</param>
        /// <param name="entitySource">Entity source.</param>
        /// <param name="changeTracker">Change tracker</param>
        public EntityQueryable(IEntityContext entityContext, IEntitySource entitySource, IStoreChangeTracker changeTracker)
            : base(QueryParser.CreateDefault(), new EntityQueryExecutor(entityContext, entitySource, changeTracker))
        {
        }

        /// <summary>Creates an instance of the queryable entity source.</summary>
        /// <param name="provider">Query provider to be used by this queryable instance.</param>
        /// <param name="expression">Expression to be parsed.</param>
        public EntityQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }
    }
}