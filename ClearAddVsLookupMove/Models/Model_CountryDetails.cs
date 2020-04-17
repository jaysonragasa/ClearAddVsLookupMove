using GalaSoft.MvvmLight;

namespace ClearAddVsLookupMove.Library.Models
{
    public class Model_CountryDetails : ViewModelBase
    {
        public int id { get; set; }

        private string _CountryName = string.Empty;
        public string CountryName
        {
            get { return _CountryName; }
            set { Set(nameof(CountryName), ref _CountryName, value); }
        }

        private int _TotalPopulation = 0;
        public int TotalPopulation
        {
            get { return _TotalPopulation; }
            set { Set(nameof(TotalPopulation), ref _TotalPopulation, value); }
        }

        private int _TotalEnergyConsumption = 0;
        public int TotalEnergyConsumption
        {
            get { return _TotalEnergyConsumption; }
            set { Set(nameof(TotalEnergyConsumption), ref _TotalEnergyConsumption, value); }
        }
    }
}
