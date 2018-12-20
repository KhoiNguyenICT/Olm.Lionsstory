using AutoMapper;
using Microsoft.AspNetCore.Http;
using Olm.Model.Entities;
using Olm.Web.Models;

namespace Olm.Web.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ContactViewModel, Contact>();
        }
    }
}
