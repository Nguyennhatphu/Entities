using Entities.Helper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {

        PagedList<ExpandoObject> GetAllOwners(OwnerParameters ownerParameters);
        ExpandoObject GetOwnerById(Guid ownerId, string fields);
        Owner GetOwnerById(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }

}
