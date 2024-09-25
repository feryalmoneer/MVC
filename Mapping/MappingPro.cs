using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModel;

namespace Demo.PL.Mapping
{
    public class MappingPro : Profile

       
    {
        public MappingPro()
        {
            CreateMap<OrderVM, Order>();
            CreateMap<Order, OrderVM>();
        }
    }
}
