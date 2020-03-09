using DesafioMOBRJ2.Helpers;
using DesafioMOBRJ2.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMOBRJ2.ViewModels
{
    class ListaEstadosSimplesPageViewModel : ViewModelBase
    {
        private ObservableCollection<States.Fields> _listaBusca = new ObservableCollection<States.Fields>();
        private ObservableCollection<States.Fields> _listaEstados;
        DataBaseHelper _dataBaseHelper;
        private INavigationService _navigationService;
        private string _stringBusca;

        public ObservableCollection<States.Fields> ListaEstados
        {
            get { return _listaEstados; }
            set { this.SetProperty(ref _listaEstados, value); }
        }

        public string StringBusca
        {
            get { return _stringBusca; }
            set
            {
                this.SetProperty(ref _stringBusca, value);
                BuscaEstadoCapital();
            }

        }

        public ListaEstadosSimplesPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ListaEstados = new ObservableCollection<States.Fields>();
            this.Title = "Estados";
            _dataBaseHelper = new DataBaseHelper();
            IniciaLista();
            _navigationService = navigationService;
            ListaEstadosAgrupadaPageCommand = new DelegateCommand(NavegarListaEstadosAgrupadaPage);
        }

        public DelegateCommand ListaEstadosAgrupadaPageCommand { get; private set; }

        private void NavegarListaEstadosAgrupadaPage()
        {
            _navigationService.NavigateAsync("ListaEstadosAgrupadaPage");
        }

        private async Task IniciaLista()
        {
           var records = await _dataBaseHelper.AcessaApi();

            foreach (var i in records)
            {
                foreach (var attachment in i.fields.Attachments)
                {
                    ListaEstados.Add(new States.Fields
                    {
                        Capital = i.fields.Capital,
                        Estado = i.fields.Estado,
                        Regiao = i.fields.Regiao,
                        Sigla = i.fields.Sigla,
                        Icon = attachment.thumbnails.full.url
                    });
                    _listaBusca = ListaEstados;
                }
            }
        }

        private void BuscaEstadoCapital()
        {
            if (string.IsNullOrEmpty(StringBusca))
            {
                ListaEstados = new ObservableCollection<States.Fields>(_listaBusca);
            }
            else
            {
                ListaEstados = new ObservableCollection<States.Fields>
                     (_listaBusca.Where(l => l.Estado.ToLower().Contains(StringBusca.ToLower()) ||
                      l.Capital.ToString().ToLower().Contains(StringBusca.ToLower())));
            }
        }
    }
}
