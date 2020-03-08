using DesafioMOBRJ2.Helpers;
using DesafioMOBRJ2.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DesafioMOBRJ2.ViewModels
{
    public class ListaEstadosSalvarBDViewModel : ViewModelBase
    {
        DataBaseHelper _dataBaseHelper;
        public ObservableCollection<States.Fields> Lista { get; set; }
        public ObservableCollection<States.Record> ListaRecord { get; set; }

        private string _textoBotao;

        public string TextoBotao
        {
            get { return _textoBotao; }
            set
            {
                this.SetProperty(ref _textoBotao, value);
            }

        }

        public ListaEstadosSalvarBDViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Lista = new ObservableCollection<States.Fields>();
            ListaRecord = new ObservableCollection<States.Record>();
            this.Title = "";
            _dataBaseHelper = new DataBaseHelper();
            Iniciar();
        }

        private async Task GetListaEstados()
        {
            Lista.Clear();
            var t = await _dataBaseHelper.AcessaApi(); ; 
            var listaLocal = GetListaEstadosLocal();
            
            foreach (var i in listaLocal)
            {
                foreach (var attachment in i.fields.Attachments)
                {
                    Lista.Add(new States.Fields
                    {
                        Capital = i.fields.Capital,
                        Estado = i.fields.Estado,
                        Regiao = i.fields.Regiao,
                        Sigla = i.fields.Sigla,
                        //Icon = attachment.thumbnails.full.url
                    });

                }
            }
        }

        private List<States.Record> GetListaEstadosLocal()
        {
            return _dataBaseHelper.GetListaHelper();
        }

        private void Iniciar()
        {
            GetListaEstadosLocal();
            Botao();
            GetListaEstados();
            
        }

        private DelegateCommand _carregarBancoLocalCommand;

        public DelegateCommand CarregarBancoLocalCommand => _carregarBancoLocalCommand ?? (_carregarBancoLocalCommand = new DelegateCommand(async () => await BancoLocal()));

        private async Task BancoLocal()
        {

            if (GetListaEstadosLocal().Count == 0)
            {
                var resp1 = await PageDialogService.DisplayAlertAsync("Alerta", "Salvar e exibir a lista de Estados?", "Sim", "Não");
                if (resp1 == true)
                {
                    _dataBaseHelper.SalvarBDLocalHelper();
                    Iniciar();
                    return;
                }
            }

            var resp2 = await PageDialogService.DisplayAlertAsync("Alerta", "Excluir a lista de Estados?", "Sim", "Não");
            if (resp2 == true)
            {
                _dataBaseHelper.DeletarListaHelper();
                Lista.Clear();
                Iniciar();
            }
        }

        private void Botao()
        {
            if (GetListaEstadosLocal().Count != 0)
            {
                this.Title = "Lista de Estados";
                TextoBotao = "Excluir Lista";
            }

            else
            {
                this.Title = "Lista de Estados Vazia";
                TextoBotao = "Exibir Lista";
            }

        }

    }
}
