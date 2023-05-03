using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisaManagement;
public class ResidencePermitManager
{
    readonly IPersonResidencePermitStore personResidencePermitStore;

    public ResidencePermitManager(IPersonResidencePermitStore personResidencePermitStore)
    {
        this.personResidencePermitStore = personResidencePermitStore;
    }

    public IQueryable<PersonResidencePermit> Permits => this.personResidencePermitStore.PersonResidencePermits;

    public ValueTask<PersonResidencePermit?> FindByIdAsync(int id)
    {
        return this.personResidencePermitStore.FindByIdAsync(id);
    }
}
