using Prism;
using Prism.Ioc;
using DesafioMOBRJ2.ViewModels;
using DesafioMOBRJ2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DesafioMOBRJ2
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/ListaEstadosSimplesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListaEstadosSimplesPage, ListaEstadosSimplesPageViewModel>();
            containerRegistry.RegisterForNavigation<ListaEstadosAgrupadaPage, ListaEstadosAgrupadaPageViewModel>();
            containerRegistry.RegisterForNavigation<ListaEstadosSalvarBD, ListaEstadosSalvarBDViewModel>();
        }
    }
}
