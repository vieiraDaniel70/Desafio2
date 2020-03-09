using DesafioMOBRJ2.DataBase;
using DesafioMOBRJ2.Models;
using DesafioMOBRJ2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMOBRJ2.Helpers
{
    public class DataBaseHelper
    {
            ApiReadingService _apiReadingServiceService;
            RepositoryListaEstados<States.Record> _repositoryListaEstados;
            public static List<States.Record> Lista { get; set; }

            public DataBaseHelper()
            {
            _apiReadingServiceService = new ApiReadingService();
            _repositoryListaEstados = new RepositoryListaEstados<States.Record>();
            Lista = new List<States.Record>();
            }

            public async Task<List<States.Record>> AcessaApi()
            {
                States r = await _apiReadingServiceService.GetApi();
                foreach (var i in r.records)
                {
                Lista.Add(i);
                }

                return Lista; 
            }

            public void SalvarBDLocalHelper()
            {
                foreach (var i in Lista)
                {
                _repositoryListaEstados.Insert(i);
                }
            }

            public List<States.Record> GetListaHelper()
            {
                return _repositoryListaEstados.GetAll();
            }

            public void DeletarListaHelper()
            {
                var listaLocal = GetListaHelper();

                if (listaLocal.Count > 0)
                {
                    foreach (var i in listaLocal)
                    {
                    _repositoryListaEstados.Remove(i.id);
                    }
                }
            }
    }
}