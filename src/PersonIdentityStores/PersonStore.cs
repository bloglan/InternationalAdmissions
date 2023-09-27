using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PersonIdentity;

namespace PersonIdentityStores;

public class PersonStore : UserStore<Person, IdentityRole, PersonIdentityDbContext>
{
    public PersonStore(PersonIdentityDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }
}
