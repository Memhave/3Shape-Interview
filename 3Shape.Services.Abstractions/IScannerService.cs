using System;
using System.Threading.Tasks;
using _3Shape.Contracts;

namespace _3Shape.Services.Abstractions;

public interface IScannerService
{
    public Task<Guid> CreateReconstruction(CreateReconstructionDto dto);
    public Task<string> GetReconstruction(Guid reconstructionId);
    public Task<string> GetReconstruction(Guid reconstructionId, int toothId);
    public Task<string> Trim(Guid reconstructionId, int steps);
}