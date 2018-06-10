﻿using System;

namespace Resmap.Domain
{
    public class Relation : BaseEntity
    {
        public string RelationId { get; set; }
        public string Title { get; set; }
                
        public Address Address { get; set; }
        public Note Note { get; set; }
        public RelationType RelationType { get; set; }
    }
}
