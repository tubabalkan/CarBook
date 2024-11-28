using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastCarPricingQueryHandler
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetLastCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public List<GetLastCarPricingQueryResult> Handle()
        {
            var values = _carPricingRepository.GetCarsPricingsWithCars();
            return values.Select(x => new GetLastCarPricingQueryResult
            {
                Model = x.Car.Model,
                CoverImgUrl = x.Car.CoverImgUrl,
                BrandName = x.Car.Brand.Name,
                PricingAmount=x.Amount,
              //  PricingName=x.Pricing.Name,


               
               
            }).ToList();
        }
        }
}
