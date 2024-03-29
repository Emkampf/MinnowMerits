﻿using MMRB.Data;
using MMRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Services
{
    public class WriteUpService
    {
        public bool CreateWriteUp(WriteUpCreate model)
        {
            var entity = new WriteUp()
            {
                WriteUpId = model.WriteUpId,
                WriteUps = model.WriteUps,
                WalletId = model.WalletId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WriteUps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WriteUpListItem> GetWriteUp()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .WriteUps
                    .Select(
                        e =>
                        new WriteUpListItem
                        {
                            WriteUpId = e.WriteUpId,
                            WriteUps = e.WriteUps,
                        });
                return query.ToArray();

            }
        }

        public WriteUpDetail GetWriteUpById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .WriteUps
                    .Single(e => e.WriteUpId == id);
                return
                    new WriteUpDetail
                    {
                        WriteUpId = entity.WriteUpId,
                        WriteUps = entity.WriteUps

                    };
            }
        }

        public bool UpdateWriteUp(WriteUpEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WriteUps
                        .Single(e => e.WriteUpId == model.WriteUpId);

                entity.WriteUps = model.WriteUps;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWriteUp(int writeUpId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                        .WriteUps
                        .Single(e => e.WriteUpId == writeUpId);

                ctx.WriteUps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
