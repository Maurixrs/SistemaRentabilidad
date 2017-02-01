using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SistemaRentabilidad.Models;
using SistemaRentabilidad.ViewModels;

namespace SistemaRentabilidad.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Worksheet, WsVM>();
            Mapper.CreateMap<WsVM, Worksheet>();
            

        }
    }
}