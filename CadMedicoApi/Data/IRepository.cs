
using System.Threading.Tasks;
using CadMedicoApi.Models;

namespace CadMedicoApi.Data
{
              //Interface não implementa Metodos, apenas assinatura
              public interface IRepository
              {
                void Add<T>(T entity) where T : class;
                void Update<T>(T entity) where T : class;
                void Delete<T>(T entity) where T : class;
                Task<bool> SaveChangesAsync();
               //Medico
                Task<MedicoModel[]> GetAllMedicoModelAsync(bool includeMedico);
                Task<MedicoModel[]> GetAllMedicoModelByEspecialidadeId(int EspecialidadeId, bool includeEspecialidade);
                Task<MedicoModel> GetMedicoModelById(int medicoId, bool includeCidade);

                //Cidade
                Task<CidadeModel[]> GetAllCidadeModelAsync(bool includeCidade);
                Task<CidadeModel> GetCidadeModelById(int cidadeId, bool includeMedico);

                //Usuario
                Task<UsuarioModel> GetUsuarioModelById(int UsuarioId, bool includeUsuario);
                Task<UsuarioModel[]> GetAllUsuarioModelAsync(bool includeUsuario);

              } 
}