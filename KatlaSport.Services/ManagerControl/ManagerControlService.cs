namespace KatlaSport.Services.ManagerControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.ManagerCatalogue;
    using DbManager = KatlaSport.DataAccess.ManagerCatalogue.Manager;

    public class ManagerControlService : IManagerService
    {
        private readonly IManagerContext _context;

        public ManagerControlService(IManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Manager>> GetManagersAsync(int start, int amount)
        {
            var dbManagers = await _context.Managers.OrderBy(p => p.Id).Skip(start).Take(amount).ToArrayAsync();
            var managers = dbManagers.Select(p => Mapper.Map<Manager>(p)).ToList();

            return managers;
        }

        public async Task<Manager> GetManagerAsync(int managerId)
        {
            var dbManagers = await _context.Managers.Where(p => p.Id == managerId).ToArrayAsync();

            if (dbManagers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbManager, Manager>(dbManagers[0]);
        }

        public async Task<Manager> CreateManagerAsync(UpdateManagerRequest createRequest)
        {
            var dbManager = Mapper.Map<UpdateManagerRequest, DbManager>(createRequest);
            _context.Managers.Add(dbManager);
            await _context.SaveChangesAsync();

            return Mapper.Map<Manager>(dbManager);
        }

        public async Task<Manager> UpdateManagerAsync(int managerId, UpdateManagerRequest updateRequest)
        {
            var dbManagers = await _context.Managers.Where(p => p.Id == managerId).ToArrayAsync();
            if (dbManagers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbManager = dbManagers[0];

            Mapper.Map(updateRequest, dbManager);

            await _context.SaveChangesAsync();

            return Mapper.Map<Manager>(dbManager);
        }

        public async Task DeleteManagerAsync(int managerId)
        {
            var managers = await _context.Managers.Where(p => p.Id == managerId).ToArrayAsync();
            if (managers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var manager = managers[0];
            if (manager.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatusAsync(int managerId, bool deletedStatus)
        {
            var managers = await _context.Managers.Where(p => managerId == p.Id).ToArrayAsync();

            if (managers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbManager = managers[0];
            if (dbManager.IsDeleted != deletedStatus)
            {
                dbManager.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }
    }
}
