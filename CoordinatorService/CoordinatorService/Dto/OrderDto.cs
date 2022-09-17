using CoordinatorService.Enum;

namespace CoordinatorService.Dto;

public class OrderDto
{
    public Guid Id { get; set; }
    public string? Status { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}