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
    private readonly IDataFetcher _dataFetcher;

    public OrderController(ILogger<OrderController> logger, IDataPublisher dataPublisher, IDataFetcher dataFetcher)
    {
        _logger = logger;
        _dataPublisher = dataPublisher;
        _dataFetcher = dataFetcher;
    }

    [HttpPost(Name = "Request")]
    public async Task<IActionResult> CreateOrder(RequestDto requestDto)
    {
        return Ok(new {id = _dataPublisher.PublishData(requestDto)});
    }

    [Route("Status")]
    [HttpGet]
    public ResponseDto GetStatus(string id)
    {
        return _dataFetcher.FetchData(id)!;
    }
    
}