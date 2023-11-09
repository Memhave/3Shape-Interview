using System;
using System.Collections.Generic;
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
        {
            Id = Guid.NewGuid(), // this should clearly be handled in the database part, but alas
            Image = dto.InitialScan,
            Steps = new Dictionary<int, string>
            {
                { 0, dto.InitialScan }
            }
        };

        await _repo.Insert(entity);
        await _unit.SaveChangesAsync();

        return new ReconstructionDto(entity.Id, entity.Image, entity.Steps);
    }

    public Task<string> GetReconstruction(Guid reconstructionId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetReconstruction(Guid reconstructionId, int toothId)
    {
        throw new NotImplementedException();
    }

    public Task<string> Trim(Guid reconstructionId, int steps)
    {
        throw new NotImplementedException();
    }
}