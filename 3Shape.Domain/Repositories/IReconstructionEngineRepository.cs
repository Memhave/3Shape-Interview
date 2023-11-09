using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _3Shape.Domain.Entities;

namespace _3Shape.Domain.Repositories;

public interface IReconstructionEngineRepository
{
    public Task<IEnumerable<ReconstructionEntity>> GetAll();
    public Task<ReconstructionEntity> Get(Guid id);
    public Task Insert(ReconstructionEntity entity);
    public Task Remove(ReconstructionEntity entity);
}