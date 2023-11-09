using System;
using System.Collections.Generic;

namespace _3Shape.Domain.Entities;

public class ReconstructionEntity
{
    public Guid Id { get; init; }
    public string Image { get; init; }
    // This record could be another entity, but to keep it simple
    // Idea is to be able to step "backwards" easily, without doing expensive
    // string manipulation or complex operations
    // So you could simply do entity.Stepback(N) -> would minus the last two (in order)
    // additions to the image
    // this might be a very complex or over engineered solution and might require some thread protection
    public Dictionary<int, string> Steps {get; init; }

    // Validation could be done through a constructor here, or a dedicated method

    public string GetToothScan(int toothId)
    {
        // scan the image for the part and return it
        return "";
    }

    public string AddStep(string part)
    {
        // Attach it to the image (align with overlap)
        // We probably need to check for deviation - 
        // Can you get a scan thats 1abcd and then another thats overlapping
        // but with ed2...? (c -> e)

        // Then increment steps 
        // if the deviation is allowed, it should probably be noted
        return "";
    }
}