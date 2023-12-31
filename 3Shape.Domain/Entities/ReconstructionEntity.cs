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
    // So you could simply do entity.Stepback(N) -> would minus the last N (in order)
    // additions to the image
    // this might be a very complex or over engineered solution and might require some thread protection
    //step 0
    //"1oene"
    //step 0+1
    //"1oene2en"
    public Dictionary<int, string> Steps {get; private set; } = new Dictionary<int, string>();

    public ReconstructionEntity(Guid id, string initialScan)
    {
        // Validation

        Id = id;
        Image = initialScan;
        Steps.Add(0, initialScan);
    }

    // "1oene2enoe3neoo4aei5iia"
    public string GetToothScan(int toothId)
    {
        int endIndex = toothId + 1;

        // Not tested, but I think this will be off by 1 (the -1) when the first tooth (and last?) is queried
        return Image.Substring(
            Image.IndexOf(toothId.ToString()) - 1, 
            Image.IndexOf(endIndex.ToString()));
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
        //1abc
        //c2de
        //f3...
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