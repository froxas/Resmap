using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Resmap.API.Helpers
{
    public enum Comparison
    {
        Equals,
        Contains,
        StartsWith,
        EndsWith
    }

    public class ExpressionFilter
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public Comparison Comparison { get; set; }
    }         
}
