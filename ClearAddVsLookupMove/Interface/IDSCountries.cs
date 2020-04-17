using System.Threading.Tasks;

namespace ClearAddVsLookupMove.Library.Interface
{
    public interface IDSCountries
    {
        Task<BaseResponse> GetCountriesAsync();
    }
}