using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentDocumentStores;

namespace DatabaseTool.Migrators;
internal class StudentDocumentMigrator(StudentDocumentDbContext dbContext) :DatabaseMigrator(dbContext)
{
}
