using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Account> AccountsByOwner(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Owner GetAccountById(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
