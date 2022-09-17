using CoordinatorService.Dto;

namespace CoordinatorService.Abstraction;

public interface IDataPublisher
{
    Guid PublishData(RequestDto requestDto);
}