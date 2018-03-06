using AutoMapper;
using Domain.Driver;
using Hypercent.Wings.Common.Models;

namespace Hypercent.Wings.Service.App_Start
{
    /// <summary>
    /// Auto Mapper Config class.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Register all the auto mapping.
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Driver, DriverModel>().ReverseMap();
            });
        }
    }
}