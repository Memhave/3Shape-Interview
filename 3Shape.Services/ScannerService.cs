using System;
using System.Threading.Tasks;
using _3Shape.Contracts;
using _3Shape.Domain.Entities;
using _3Shape.Domain.Repositories;
using _3Shape.Services.Abstractions;

namespace _3Shape.Services;

// This is where I would put guards etc. Most of the business stuff should exist
// in the entity itself, it lets things be more naturally organised
internal sealed class ScannerService : IScannerService
{
    private IReconstructionEngineRepository _repo;
    private IUnitOfWork _unit;

    internal ScannerService(IReconstructionEngineRepository repo, IUnitOfWork unit)
    {
        _repo = repo;
        _unit = unit;
    }

    public async Task<ReconstructionDto> CreateReconstruction(CreateReconstructionDto dto)
    {
        // Guards...
        // (Optional validation)
        var entity = new ReconstructionEntity
        (
            Guid.NewGuid(), // this should clearly be handled in the database part, but alas
            dto.InitialScan
        );

        await _repo.Insert(entity);
        await _unit.SaveChangesAsync();

        return new ReconstructionDto(entity.Id, entity.Image, entity.Steps);
    }

    public async Task<ReconstructionDto> AddScan(Guid reconstructionId, AddStepDto dto)
    {
        var entity = await _repo.Get(reconstructionId);

        // normally, I've only seen different responses done via throwing, so..
        // throw NotFoundException
        // Don't really think its the best, but its very easy to do

        entity.AddScan(dto.Scan);

        return new ReconstructionDto(entity.Id, entity.Image, entity.Steps);
    }

    public async Task<ReconstructionDto> GetReconstruction(Guid reconstructionId)
    {
        var entity = await _repo.Get(reconstructionId);

        // Handle not found

        return new ReconstructionDto(entity.Id, entity.Image, entity.Steps);
    }

    public async Task<string> GetReconstructionTooth(Guid reconstructionId, int toothId)
    {
        var entity = await _repo.Get(reconstructionId);

        // Handle not found
    
        return entity.GetToothScan(toothId);
    }

    public async Task<ReconstructionDto> Trim(Guid reconstructionId, int stepCount)
    {
        var entity = await _repo.Get(reconstructionId);

        // Handle not found
        
        entity.Trim(stepCount);

        return new ReconstructionDto(entity.Id, entity.Image, entity.Steps);
    }
}