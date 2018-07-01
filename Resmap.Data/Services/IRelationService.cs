using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface IRelationService : IRepository<Relation>
    {
        /// <summary>
        /// Returns relation by id with all properties included
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Relation GetByIdAllIncluded(Guid id);

        /// <summary>
        /// Returns all relations with all properties included
        /// </summary>
        /// <returns></returns>
        IEnumerable<Relation> GetRelationsAllIncluded();

        IEnumerable<Relation> AllRelationsALlIncluded();

        IEnumerable<Relation> GetAllWithTags();

    }
}
