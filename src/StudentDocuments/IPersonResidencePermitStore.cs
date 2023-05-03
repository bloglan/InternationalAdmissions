using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisaManagement;
public interface IPersonResidencePermitStore
{
    IQueryable<PersonResidencePermit> PersonResidencePermits { get; }

    ValueTask<PersonResidencePermit?> FindByIdAsync(int id);

    Task CreateAsync(PersonResidencePermit record);

    Task UpdateAsync(PersonResidencePermit record);

    Task DeleteAsync(PersonResidencePermit record);
}
