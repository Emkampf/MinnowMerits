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
                TypeTransaction = (TransactionType)model.TypeTransaction,
                CreatedUtc = DateTimeOffset.Now

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
                var query =
                    ctx
                    .Transactions
                    .Select(
                        e =>
                        new TransactionListItem
                        {
                            TransactionId = e.TransactionId,
                            TypeTransaction = (TransactionType)e.TypeTransaction,
                            CreatedUtc = e.CreatedUtc

                        });
                return query.ToArray();

            }
        }
    }
}
