﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureServices
    {
        private readonly IMongoCollection<Feature> _FeatureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _FeatureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _FeatureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _FeatureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdFeatureDto>(values));
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _FeatureCollection.Find(x => true).ToListAsync();
            return (_mapper.Map<List<ResultFeatureDto>>(values));

        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            await _FeatureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
        }
    }
}
