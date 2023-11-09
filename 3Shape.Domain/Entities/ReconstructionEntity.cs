using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
    public Dictionary<int, string> Steps {get; private set; } = new Dictionary<int, string>();

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


    public void AddScan(string scan)
    {
        // Remove overlap, assuming no weird deviation
        var newScanPart = NonOverlap(Image, scan);

        // Add the scan to the reconstruction
        Image += newScanPart;

        // Then increment steps 
        // if the deviation is allowed, it should probably be noted
        // Increment steps first
        Steps.Add(Steps.Count, scan);

        // We probably need to check for deviation - 
        // Can you get a scan thats 1abcd and then another thats overlapping
        // but with ed2...? (c -> e)
    }

    public void Trim(int stepCount)
    {
        // walk back steps here
    }

    // From https://stackoverflow.com/a/70315812
    // Decided not to implement this as its not a trivial problem (for me)
    private string NonOverlap(string s1, string s2)
    {
        var re = string.Join("?", s1.ToCharArray()) + "?";
        var m = Regex.Match(s2, re);
        int s = m.Index + m.Length;
        return s2.Substring(s);
    }
}