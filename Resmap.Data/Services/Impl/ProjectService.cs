using Microsoft.EntityFrameworkCore;
using Resmap.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resmap.Data.Services
{
    public class ProjectService : Repository<Project>, IProjectService
    {
        public ProjectService(ApplicationDbContext context)
           : base(context)
        {
        }              
    }
}
