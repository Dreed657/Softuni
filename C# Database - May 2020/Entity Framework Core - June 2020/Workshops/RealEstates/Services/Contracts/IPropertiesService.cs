﻿using Models;
using Services.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPropertiesService
    {
        Task<RealEstateProperty> Create(PropertyCreateDto models);

        bool Delete(int Id);

        bool Update(int Id);

        Task UpdateTags(int propertyId);

        public Task<IEnumerable<PropertyViewModel>> GetAll(int count);

        Task<IEnumerable<PropertyViewModel>> Search(int minYear, int maxYear, int minSize, int maxSize);

        Task<IEnumerable<PropertyViewModel>> SearchByPrice(int minPrice, int maxPrice);
    }
}
