using ClearAddVsLookupMove.Library.Interface;

namespace ClearAddVsLookupMove.Library.DataSource.Providers.StringProvider
{
    public class StringDataFactory : IDataFactory
    {
        public StringDataFactory()
        {
            _countries = new DSCountries();
        }

        IDSCountries _countries = null;
        public IDSCountries Countries
        {
            get { return _countries; }
        }
    }
}
