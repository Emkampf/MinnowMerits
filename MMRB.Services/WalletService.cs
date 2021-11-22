using MMRB.Data;
using MMRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Services
{
   public class WalletService
    {
        private readonly Guid _userId;

        public WalletService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWallet(WalletCreate model)
        {
            var entity = 
                new Wallet()
                {
                    ChildId = _userId,
                    WalletId = model.WalletId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.BirthDay
                });
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wallets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WalletListItem> GetWallets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Wallets
                    .Where(e => e.ChildId == _userId)
                    .Select(
                        e =>
                        new WalletListItem
                        {
                            WalletId = e.WalletId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            BirthDay = e.BirthDay
                        });
            }
        }
    }
}
