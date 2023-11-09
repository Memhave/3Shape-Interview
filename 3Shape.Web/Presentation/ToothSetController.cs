using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3Shape.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authorization;
using _3Shape.Contracts;
using System.ComponentModel.DataAnnotations;

namespace _3Shape.Web.Controllers;

//[Authorize]
[ApiController]
[Route("api/scans/teethset")]
public class ToothSetController : ControllerBase
{
    private readonly IScannerService _scanner;

    public ToothSetController(IScannerService scanner) => _scanner = scanner;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ReconstructionDto>> CreateReconstruction(
        [Required][FromBody] CreateReconstructionDto dto)
    {
        return await _scanner.CreateReconstruction(dto);
    }

    [HttpGet("{reconstructionId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> GetReconstruction(
        [Required][FromRoute] Guid reconstructionId)
    {
        return await _scanner.GetReconstruction(reconstructionId);
    }

    [HttpGet("{reconstructionId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> GetReconstruction(
        [Required][FromRoute] Guid reconstructionId,
        [Required][FromQuery] int toothId)
    {
        return await _scanner.GetReconstruction(reconstructionId, toothId);
    }

    [HttpPatch("{reconstructionId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Trim(
        [Required][FromRoute] Guid reconstructionId, 
        [Required][FromQuery] int steps)
    {
        return await _scanner.Trim(reconstructionId, steps);
    }
}
