using Entities.Helper;
using Entities.Models;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;
        private ISortHelper<Owner> _ownerSortHelper;
        private IDataShaper<Owner> _ownerDataShaper;
        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext, _ownerSortHelper, _ownerDataShaper);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext,
            ISortHelper<Owner> ownerSortHelper,
            IDataShaper<Owner> ownerDataShaper)

        {
            _repoContext = repositoryContext;
            _ownerSortHelper = ownerSortHelper;
            _ownerDataShaper = ownerDataShaper;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
