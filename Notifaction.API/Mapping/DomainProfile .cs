using AutoMapper;
using Notifaction.API.DTO;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifaction.API.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Order, orderDTO>()
            .ForMember(dest => dest.patientId, opts => opts.MapFrom(src => src.patient.Id))
            .ReverseMap();

            CreateMap<orderDTO, Order>()
            .ForMember(dest => dest.patient, opts => opts.Ignore())
            .ReverseMap();



        }
    }
}
