using ClearAddVsLookupMove.Library.DataSource.DTO_Models;
using ClearAddVsLookupMove.Library.Interface;
using ClearAddVsLookupMove.Library.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClearAddVsLookupMove.Library.ViewModels
{
    public class ViewModel_Main : ViewModelBase
    {
        #region events

        #endregion

        #region vars
        IDataFactory _dataFactory = null;
        List<DTO_Model_CountryDetails> _countries = new List<DTO_Model_CountryDetails>();
        Stopwatch stopwatch = new Stopwatch();
        #endregion

        #region properties
        public ObservableCollection<Model_CountryDetails> Countries { get; set; } = new ObservableCollection<Model_CountryDetails>();

        private long _Duration = 0;
        public long Duration
        {
            get { return _Duration; }
            set { Set(nameof(Duration), ref _Duration, value); }
        }

        private bool _UseLazy = false;
        public bool UseLazy
        {
            get { return _UseLazy; }
            set { Set(nameof(UseLazy), ref _UseLazy, value); }
        }

        private int _TotalItems = 0;
        public int TotalItems
        {
            get { return _TotalItems; }
            set { Set(nameof(TotalItems), ref _TotalItems, value); }
        }

        #endregion

        #region commands
        public ICommand Command_SortByCountry { get; set; }
        public ICommand Command_SortByPopulation { get; set; }
        public ICommand Command_SortByTotalEnergyConsumption { get; set; }
        #endregion

        #region ctors
        public ViewModel_Main(IDataFactory dataFactory)
        {
            this._dataFactory = dataFactory;

            InitCommands();

            // used only in UWP & WPF
            // or anything that supports design time updates
            if (base.IsInDesignMode)
            {
                DesignData();
            }
            else
            {
                RuntimeData();
            }
        }
        #endregion

        #region command methods
        void Command_SortByCountry_Click()
        {
            this.SortByCountry();
        }

        void Command_SortByPopulation_Click()
        {
            this.SortByPopulation();
        }

        void Command_SortByTotalEnergyConsumption_Click()
        {
            this.SortByTotalEneryConsumption();
        }
        #endregion

        #region methods
        void InitCommands()
        {
            if (Command_SortByCountry == null) Command_SortByCountry = new RelayCommand(Command_SortByCountry_Click);
            if (Command_SortByPopulation == null) Command_SortByPopulation = new RelayCommand(Command_SortByPopulation_Click);
            if (Command_SortByTotalEnergyConsumption == null) Command_SortByTotalEnergyConsumption = new RelayCommand(Command_SortByTotalEnergyConsumption_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {
            var response = await this._dataFactory.Countries.GetCountriesAsync();

            if(response.Status)
            {
                var countries = (List<DTO_Model_CountryDetails>)response.Response;

                // keep a local copy of the response 
                // so we can use it for sorting
                this._countries = countries;

                // update our list;
                RefreshList(this._countries);

                this.TotalItems = this._countries.Count;
            }
        }

        void UpdateListFromSource(List<DTO_Model_CountryDetails> countries)
        {
            if (this.Countries.Count == 0)
            {
                this.Countries.Clear();
            }

            // update our lists without clearing our collection
            for (int i = 0; i < countries.Count; i++)
            {
                var countryw = this.Countries.Where(x => x.CountryName == countries[i].countryname).SingleOrDefault();

                if (countryw != null)
                {
                    int oldIndex = this.Countries.IndexOf(countryw);
                    this.Countries.Move(oldIndex, i);
                }
                else
                {
                    this.Countries.Insert(i, new Model_CountryDetails()
                    {
                        CountryName = countries[i].countryname,
                        TotalPopulation = countries[i].population,
                        TotalEnergyConsumption = countries[i].total_energy_consumption
                    });
                }
            }
        }

        void LazyUpdateListFromSource(List<DTO_Model_CountryDetails> countries)
        {
            this.Countries.Clear();
            for(int i = 0; i < countries.Count; i++)
            {
                this.Countries.Add(new Model_CountryDetails()
                {
                    id = countries[i].id,
                    CountryName = countries[i].countryname,
                    TotalPopulation = countries[i].population,
                    TotalEnergyConsumption = countries[i].total_energy_consumption
                });
            }
        }

        void RefreshList(List<DTO_Model_CountryDetails> source)
        {
            stopwatch.Restart();
            stopwatch.Start();

            if(this.UseLazy)
            {
                LazyUpdateListFromSource(source);
            }
            else
            {
                UpdateListFromSource(source);
            }

            stopwatch.Stop();

            this.Duration = stopwatch.ElapsedMilliseconds;
        }

        void SortByCountry()
        {
            this._countries = this._countries.OrderBy(x => x.countryname).ToList();
            RefreshList(this._countries);
        }

        void SortByPopulation()
        {
            this._countries = this._countries.OrderBy(x => x.population).ToList();
            RefreshList(this._countries);
        }

        void SortByTotalEneryConsumption()
        {
            this._countries = this._countries.OrderBy(x => x.total_energy_consumption).ToList();
            RefreshList(this._countries);
        }
        #endregion
    }
}
