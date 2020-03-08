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
    public class ListaEstadosAgrupadaPageViewModel : ViewModelBase
    {
        public ObservableCollection<States.Regiao> _listaAgrupada;
        DataBaseHelper _dataBaseHelper;
        private INavigationService _navigationService;

        public ObservableCollection<States.Regiao> ListaAgrupada
        {
            get { return _listaAgrupada; }
            set { this.SetProperty(ref _listaAgrupada, value); }
        }

        public ListaEstadosAgrupadaPageViewModel(INavigationService navigationService, IPageDialogService pageDiologService) : base(navigationService, pageDiologService)
        {
            ListaAgrupada = new ObservableCollection<States.Regiao>();
            this.Title = "Estados por Região";
            _dataBaseHelper = new DataBaseHelper();
            IniciaListaAgrupada();
            _navigationService = navigationService;
            ListaEstadosSalvarBDCommand = new DelegateCommand(NavegarListaEstadosSalvarBD);
        }

        public DelegateCommand ListaEstadosSalvarBDCommand { get; private set; }

        private void NavegarListaEstadosSalvarBD()
        {
            _navigationService.NavigateAsync("ListaEstadosSalvarBD");
        }

        private async Task IniciaListaAgrupada()
        {
            var estados = await _dataBaseHelper.AcessaApi(); // Chamada da API

            var nordeste = new States.Regiao() { GrupoRegiao = "Nordeste"};
            
            foreach (var estado in estados.Where(x => x.fields.Regiao.Contains("Nordeste")).ToList())
            {
                foreach (var attachment in estado.fields.Attachments)
                {
                    nordeste.Add(new States.Fields
                    {
                        Capital = estado.fields.Capital,
                        Estado = estado.fields.Estado,
                        Regiao = estado.fields.Regiao,
                        Sigla = estado.fields.Sigla,
                        Icon = attachment.thumbnails.large.url
                    });
                }
            }
            ListaAgrupada.Add(nordeste);


            var centroeste = new States.Regiao() { GrupoRegiao = "Centro-Oeste"};

            foreach (var estado in estados.Where(x => x.fields.Regiao.Contains("Centro-Oeste")).ToList())
            {
                foreach (var attachment in estado.fields.Attachments)
                {
                    centroeste.Add(new States.Fields
                    {
                        Capital = estado.fields.Capital,
                        Estado = estado.fields.Estado,
                        Regiao = estado.fields.Regiao,
                        Sigla = estado.fields.Sigla,
                        Icon = attachment.thumbnails.large.url
                    });
                }
            }
            ListaAgrupada.Add(centroeste);

            var sudeste = new States.Regiao() { GrupoRegiao = "Sudeste"};

            foreach (var estado in estados.Where(x => x.fields.Regiao.Contains("Sudeste")).ToList())
            {
                foreach (var attachment in estado.fields.Attachments)
                {
                    sudeste.Add(new States.Fields
                    {
                        Capital = estado.fields.Capital,
                        Estado = estado.fields.Estado,
                        Regiao = estado.fields.Regiao,
                        Sigla = estado.fields.Sigla,
                        Icon = attachment.thumbnails.large.url
                    });
                }
            }
            ListaAgrupada.Add(sudeste);

            var norte = new States.Regiao() { GrupoRegiao = "Norte"};

            foreach (var estado in estados.Where(x => x.fields.Regiao.Contains("Norte")).ToList())
            {
                foreach (var attachment in estado.fields.Attachments)
                {
                    norte.Add(new States.Fields
                    {
                        Capital = estado.fields.Capital,
                        Estado = estado.fields.Estado,
                        Regiao = estado.fields.Regiao,
                        Sigla = estado.fields.Sigla,
                        Icon = attachment.thumbnails.large.url
                    });
                }
            }
            ListaAgrupada.Add(norte);

            var sul = new States.Regiao() { GrupoRegiao = "Sul"};

            foreach (var estado in estados.Where(x => x.fields.Regiao.Contains("Sul")).ToList())
            {
                foreach (var attachment in estado.fields.Attachments)
                {
                    sul.Add(new States.Fields
                    {
                        Capital = estado.fields.Capital,
                        Estado = estado.fields.Estado,
                        Regiao = estado.fields.Regiao,
                        Sigla = estado.fields.Sigla,
                        Icon = attachment.thumbnails.large.url
                    });
                }
            }
            ListaAgrupada.Add(sul);
        }
    }
}
