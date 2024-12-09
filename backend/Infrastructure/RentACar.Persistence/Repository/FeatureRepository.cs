using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(RentACarContext context) : base(context)
        {
        }

      
    }
}
