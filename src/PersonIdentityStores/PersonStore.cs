using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PersonIdentity;

namespace PersonIdentityStores;

public class PersonStore(PersonIdentityDbContext context, IdentityErrorDescriber? describer = null) : UserStore<Person, IdentityRole, PersonIdentityDbContext>(context, describer);
