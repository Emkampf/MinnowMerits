using MMRB.Data;
using MMRB.Models;
using MMRB.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity = new Transaction()
            {
                TransactionId = model.TransactionId,
/*                TypeTransaction = (TransactionType)model.TypeTransaction,*/
                CreatedUtc = DateTimeOffset.UtcNow,
                EventId = model.EventId,
                WalletId = model.WalletId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var eventsList =
                    ctx
                    .Events
                    .Select(
                        e =>
                        new EventListItem
                        {
                            EventId = e.EventId,
                            Title = e.Title,
                            Description = e.Description,
                            Price = e.Price,

                        });
                //var events = eventsList.ToArray();
                
                var query =
                    ctx
                    .Transactions
                    .Select(
                        e =>
                        new TransactionListItem
                        {
                            TransactionId = e.TransactionId,
/*                            TypeTransaction = (TransactionType)e.TypeTransaction,*/
                            CreatedUtc = e.CreatedUtc,
                            EventId = e.EventId == null ? -1 : (int)e.EventId,
                            WalletId = e.WalletId == null ? -1 : (int)e.WalletId
                        }); 
                var transactions = query.ToArray();
                foreach (TransactionListItem tran in transactions) {
                    tran.EventDescription = eventsList.Where(x => x.EventId == tran.EventId).Select(x => x.Description).FirstOrDefault();
                }
                return transactions;
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Transactions
                    .Single(e => e.TransactionId == id);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
/*                        TypeTransaction = (TransactionType)entity.TypeTransaction,*/
                        CreatedUtc = entity.CreatedUtc,
                        EventId = entity.EventId == null ? -1 : (int)entity.EventId,
                        WalletId = entity.WalletId == null ? -1 : (int)entity.WalletId,
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == model.TransactionId);

/*                entity.TypeTransaction = (TransactionType)model.TypeTransaction;*/
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                        .Transactions
                        .Single(e => e.TransactionId == transactionId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
