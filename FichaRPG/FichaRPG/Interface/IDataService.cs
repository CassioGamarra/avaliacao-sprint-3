using FichaRPG.RootClass;
using System;
using System.Threading.Tasks; 

namespace FichaRPG.Interface
{
    public interface IDataService
    {
        Task<ClassesRoot> ObterClassesAsync();
        Task<IdsRoot> ObterIdsFiltradosAsync();
        Task<AtributosRoot> ObterAtributosDeClasseAsync();
    }
}
