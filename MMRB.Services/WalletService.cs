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
                };
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
                return query.ToArray();
            }
        }

        public WalletDetail GetWalletById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Wallets
                    .Single(e => e.WalletId == id && e.ChildId == _userId);
                return
                    new WalletDetail
                    {
                        WalletId = entity.WalletId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        BirthDay = entity.BirthDay
                    };
            }
        }

        public bool UpdateWallet(WalletEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Wallets
                        .Single(e => e.WalletId == model.WalletId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.BirthDay = model.BirthDay;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWallet(int walletId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                        .Wallets
                        .Single(e => e.WalletId == walletId);

                ctx.Wallets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
