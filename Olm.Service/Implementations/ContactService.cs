using Olm.Model;
using Olm.Model.Entities;
using Olm.Service.Interfaces;

namespace Olm.Service.Implementations
{
    public class ContactService: BaseService<Contact>, IContactService
    {
        public ContactService(AppDbContext context) : base(context)
        {
        }
    }
}