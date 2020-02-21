using Entities.Helper;
using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Reflection;
using System.Dynamic;

namespace Entities.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private ISortHelper<Owner> _sortHelper;
        private IDataShaper<Owner> _dataShaper;
        public OwnerRepository(RepositoryContext repositoryContext, ISortHelper<Owner> sortHelper, IDataShaper<Owner> dataShaper)
            : base(repositoryContext)
        {
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }
        public PagedList<ExpandoObject> GetAllOwners(OwnerParameters ownerParameters) //Lọc dữ liệu
        {
            //Chỉ đường đi của bộ Lọc
            var owners = FindByCondition(o => o.DateOfBirth.Year >= ownerParameters.MinYearOfBirth &&
                                o.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth);
            SearchByName(ref owners, ownerParameters.Name);

            _sortHelper.ApplySort(owners, ownerParameters.OrderBy);
            var shapedOwners = _dataShaper.ShapeData(owners, ownerParameters.Fields);

            return PagedList<ExpandoObject>.ToPagedList(shapedOwners,
               ownerParameters.PageNumber,
               ownerParameters.PageSize);
        }
        private void SearchByName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;

            owners = owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }



        public ExpandoObject GetOwnerById(Guid ownerId, string fields)
        {
            var owner = FindByCondition(owners => owners.OwnerId.Equals(ownerId))
                .DefaultIfEmpty(new Owner())
                .FirstOrDefault();

            return _dataShaper.ShapeData(owner, fields);
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
                .DefaultIfEmpty(new Owner())
                .FirstOrDefault();
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }
        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

    }
}
