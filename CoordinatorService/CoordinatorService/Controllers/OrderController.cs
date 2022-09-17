using CoordinatorService.Abstraction;
using CoordinatorService.Dto;
using CoordinatorService.Enum;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoordinatorService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IDataPublisher _dataPublisher;

    public OrderController(ILogger<OrderController> logger, IDataPublisher dataPublisher)
    {
        _logger = logger;
        _dataPublisher = dataPublisher;
    }

    [HttpPost(Name = "Request")]
    public async Task<IActionResult> CreateOrder(RequestDto requestDto)
    {
        return Ok(new {id = _dataPublisher.PublishData(requestDto)});
    }

    [HttpGet(Name = "Status")]
    public ResponseDto GetStatus(string id)
    {
        return new ResponseDto() {Status = "Testing", Id = Guid.Parse(id)};
    }
    
}