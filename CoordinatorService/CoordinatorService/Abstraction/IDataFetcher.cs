using CoordinatorService.Dto;

namespace CoordinatorService.Abstraction;

public interface IDataFetcher
{
    ResponseDto? FetchData(string id);
}