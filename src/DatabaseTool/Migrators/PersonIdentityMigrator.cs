using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonIdentityStores;

namespace DatabaseTool.Migrators;
internal class PersonIdentityMigrator(PersonIdentityDbContext dbContext) :DatabaseMigrator(dbContext)
{
}
