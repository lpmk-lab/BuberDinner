using ErrorOr;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRMS.Application.Authentication.Commands.Store
{
    public interface IStoreHandler
    {
        public ErrorOr<List<MasStoreView>> GetAll();
        public ErrorOr<MasStoreView> Get(string ID);
        public ErrorOr<MasStore> Save(StoreRecord record);
        public ErrorOr<bool> Delete(string ID, string requestID);
    }
}
