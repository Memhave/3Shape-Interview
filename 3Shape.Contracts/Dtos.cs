using System;
using System.Collections.Generic;

namespace _3Shape.Contracts;

public record CreateReconstructionDto(
    string InitialScan);

public record AddStepDto(
    string Scan);

public record ReconstructionDto(
    Guid Id,
    string Image,
    Dictionary<int, string> Steps);