using CoordinatorService.Dto;

namespace CoordinatorService.Implementation;

public interface IDataPublisher
{
    Guid PublishData(RequestDto requestDto);
}