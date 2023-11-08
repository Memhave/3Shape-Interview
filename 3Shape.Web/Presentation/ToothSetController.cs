using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3Shape.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authorization;
using _3Shape.Contracts;

namespace _3Shape.Web.Controllers;

//[Authorize]d
[ApiController]
[Route("api/scans/teethset")]
public class ToothSetController : ControllerBase
{
    private readonly IScannerService _scanner;

    public ToothSetController(IScannerService scanner)
    {
        _scanner = scanner;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Guid>> CreateImage(
        CreateTeethSetDto dto)
    {
        return await _scanner.CreateImage(dto);
    }

    


}
