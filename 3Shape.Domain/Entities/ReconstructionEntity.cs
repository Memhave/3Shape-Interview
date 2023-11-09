using System;
using System.Collections.Generic;

namespace _3Shape.Domain.Entities;

public class ReconstructionEntity
{
    public Guid Id { get; private set; }
    public string Image { get; private set; }
    // This record could be another entity, but to keep it simple
    // Idea is to be able to step "backwards" easily, without doing expensive
    // string manipulation or complex operations
    // So you could simply do entity.Stepback(N) -> would minus the last two (in order)
    // additions to the image
    // this might be a very complex or over engineered solution and might require some thread protection
    public Dictionary<int, string> Steps {get; private set; }

    public ReconstructionEntity(Guid id, string initialScan)
    {
        // Validation

        Id = id;
        Image = initialScan;
        Steps.Add(0, initialScan);
    }

    public string GetToothScan(int toothId)
    {
        // scan the image for the part and return it
        return "";
    }

    public void AddStep(string scan)
    {
        // Attach it to the image (align with overlap)
        // We probably need to check for deviation - 
        // Can you get a scan thats 1abcd and then another thats overlapping
        // but with ed2...? (c -> e)

        // Then increment steps 
        Steps.Add(Steps.Count, scan);
        // if the deviation is allowed, it should probably be noted
    }

    public void Trim(int stepCount)
    {
        // walk back steps here
    }

}