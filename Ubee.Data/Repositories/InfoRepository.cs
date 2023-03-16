using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubee.Data.Contexts;
using Ubee.Data.IRepositories;
using Ubee.Domain.Configurations;
using Ubee.Domain.Entities;

namespace Ubee.Data.Repositories
{
    public class InfoRepository : IInfoRepository

    {
        private readonly AppDbContext appDbContext = new AppDbContext(); 

        public async ValueTask<Info> InsertInfoAsync(Info info)
        {
            EntityEntry<Info> entity = await this.appDbContext.Infos.AddAsync(info);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async ValueTask<Info> UpdateInfoAsync(Info info)
        {
            EntityEntry<Info> entity = this.appDbContext.Infos.Update(info);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async ValueTask<bool> DeleteInfoAysnyc(long id)
        {
            Info entity =
            await this.appDbContext.Infos.FirstOrDefaultAsync(info => info.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Infos.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<Info> SelectInfoById(Predicate<Info> predicate) =>
            await this.appDbContext.Infos.Where(info => info.IsActive).FirstOrDefaultAsync(info => predicate(info));

        public IQueryable<Info> SelectAllInfos() =>
            this.appDbContext.Infos.Where(info => info.IsActive);
    }
}
