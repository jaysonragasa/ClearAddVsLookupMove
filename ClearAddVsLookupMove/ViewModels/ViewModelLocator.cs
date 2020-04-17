using ClearAddVsLookupMove.Library.DataSource.Providers.StringProvider;
using ClearAddVsLookupMove.Library.Interface;
using GalaSoft.MvvmLight.Ioc;

namespace ClearAddVsLookupMove.Library.ViewModels
{
    public class ViewModelLocator
    {
        IDataFactory DataFactory { get; set; } = null;

        public ViewModelLocator()
        {
            // default factory
            this.DataFactory = new StringDataFactory();

            SimpleIoc.Default.Register<ViewModel_Main>(() => new ViewModel_Main(this.DataFactory));
        }

        public ViewModel_Main Main
        {
            get { return SimpleIoc.Default.GetInstance<ViewModel_Main>(); }
        }
    }
}
