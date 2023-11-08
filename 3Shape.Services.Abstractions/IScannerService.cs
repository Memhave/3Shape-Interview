using System;
using System.Threading.Tasks;
using _3Shape.Contracts;

namespace _3Shape.Services.Abstractions;

public interface IScannerService
{
    public Task<Guid> CreateImage(CreateTeethSetDto dto);
}