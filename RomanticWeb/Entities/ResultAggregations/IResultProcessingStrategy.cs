﻿using System.Collections.Generic;

namespace RomanticWeb.Entities.ResultAggregations
{
    /// <summary>
    /// Defines a contract for processing results from reading rdf nodes
    /// </summary>
    public interface IResultProcessingStrategy
    {
        ProcessingOperation Operation { get; }

        /// <summary>
        /// Processes nodes and returns the transformed value
        /// </summary>
        object Process(IEnumerable<object> objects);
    }
}