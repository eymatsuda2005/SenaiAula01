using System.Threading.Tasks;
using CadMedicoApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CadMedicoApi.Data
{
              public class Repository : IRepository
              {
               private readonly DataContext _context;
               public Repository(DataContext context)
                {
                    _context = context;
                }
               public void Add<T>(T entity) where T : class
                {
                     _context.Add(entity);
                }
               public void Delete<T>(T entity) where T : class
                {
                     _context.Remove(entity);
                }
               public async Task<bool> SaveChangesAsync()
                {
                    return (await _context.SaveChangesAsync()) > 0;
                }  

              public void Update<T>(T entity) where T : class
                {
                    _context.Update(entity);
                }
               public async Task<MedicoModel[]> GetAllMedicoModelAsync(bool includeMedico = false)
                {

                    IQueryable<MedicoModel> query = _context.Medicos;
                        if (includeMedico)
                            {
                                query = query.Include(mc => mc.MedicoCidade)
                                             .ThenInclude(c => c.Cidade)
                                             .Include(me => me.MedicoEspecialidade)
                                             .ThenInclude(e => e.Especialidade);
                            }
                                query = query.AsNoTracking().OrderBy(m => m.Id);
                                return await query.ToArrayAsync();
                            }

              public async Task<MedicoModel[]> GetAllMedicoModelByEspecialidadeId(int EspecialidadeId, bool includeEspecialidade)
                {
                    IQueryable<MedicoModel> query = _context.Medicos;
                        if (includeEspecialidade)
                            {
                                query = query.Include(me => me.MedicoEspecialidade)
                                             .ThenInclude(e => e.Especialidade);
                            }
                                query = query.AsNoTracking()
                                             .OrderBy(medico => medico.Id)
                                             .Where(medico => medico.MedicoEspecialidade.Any(me =>
                                              me.EspecialidadeId == EspecialidadeId));
                                              return await query.ToArrayAsync();
                            }
               public async Task<MedicoModel> GetMedicoModelById(int medicoId, bool includeCidade)
                {
                    IQueryable<MedicoModel> query = _context.Medicos;
                        if (includeCidade)
                            {
                                               query = query.AsNoTracking()
                                              .Include(c => c.MedicoCidade)
                                              .ThenInclude(mc => mc.Cidade)
                                              .Include(me => me.MedicoEspecialidade)
                                              .ThenInclude(e => e.Especialidade);
                            }
                                               query = query.AsNoTracking()
                                               .OrderBy(medico => medico.Id)
                                               .Where(medico => medico.Id == medicoId);
                                                return await query.FirstOrDefaultAsync();
                            }

                public async Task<CidadeModel[]> GetAllCidadeModelAsync(bool includeCidade = false)
                {
                   
                        IQueryable<CidadeModel> query = _context.Cidades;
                        if (includeCidade)
                            {
                                query = query.Include(mc => mc.MedicoCidade)
                                             .ThenInclude(m => m.Medico)
                                             .ThenInclude(me => me.MedicoEspecialidade)
                                             .ThenInclude(e=> e.Especialidade);
                                      
                            }
                                query = query.AsNoTracking().OrderBy(c => c.Id);
                                return await query.ToArrayAsync();
            
                }

        public async Task<CidadeModel> GetCidadeModelById(int cidadeId, bool includeMedico)
        {
             IQueryable<CidadeModel> query = _context.Cidades;

            if(includeMedico){
                query = query.Include(mc => mc.MedicoCidade)
                             .ThenInclude(m => m.Medico)
                             .ThenInclude(me => me.MedicoEspecialidade)
                             .ThenInclude(e => e.Especialidade);
            }

            query = query.AsNoTracking()
                          .OrderBy(c => c.Id)
                          .Where(c => c.Id == cidadeId);

            return await query.FirstOrDefaultAsync();
        }

        public Task<UsuarioModel> GetUsuarioModelById(int UsuarioId, bool includeUsuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<UsuarioModel[]> GetAllUsuarioModelAsync(bool includeUsuario)
        {
            throw new System.NotImplementedException();
        }
    }

}
