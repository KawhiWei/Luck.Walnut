using Toyar.Dto.ToyarApplications;

namespace Toyar.Query.ToyarApplicationQuery;

public interface IToyarApplicationQuery
{
    Task<ToyarApplicationOutputDto> QueryToyarApplicationByAppId(string appId);
}