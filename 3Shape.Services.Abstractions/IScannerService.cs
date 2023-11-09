using System;
using System.Threading.Tasks;
using _3Shape.Contracts;

namespace _3Shape.Services.Abstractions;

public interface IScannerService
{
    public Task<ReconstructionDto> AddScan(Guid reconstructionId, AddStepDto dto);
    public Task<ReconstructionDto> CreateReconstruction(CreateReconstructionDto dto);
    public Task<ReconstructionDto> GetReconstruction(Guid reconstructionId);
    public Task<string> GetReconstructionTooth(Guid reconstructionId, int toothId);
    public Task<ReconstructionDto> Trim(Guid reconstructionId, int steps);
}