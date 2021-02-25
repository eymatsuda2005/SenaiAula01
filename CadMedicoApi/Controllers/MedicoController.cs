using Microsoft.AspNetCore.Mvc;
using CadMedicoApi.Data;
using System;
using System.Threading.Tasks;
using CadMedicoApi.Models;

namespace CadMedicoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
      
       private readonly IRepository _repo;

       public MedicoController(IRepository repo){
           _repo = repo;
       }
       [HttpGet]
       public async Task<IActionResult> Get(){
           try
           {
              var result = await _repo.GetAllMedicoModelAsync(true);
              return Ok(result);
           }
           catch (Exception ex)
           { 
               return BadRequest($"Erro: {ex.Message}");
           }
       }

       [HttpGet("{MedicoId}")]
       public async Task <IActionResult> getByMedicoId(int MedicoId){
           try
           {
               var result = await _repo.GetMedicoModelById(MedicoId, true);
               return Ok(result);
           }
           catch (Exception ex)
           {
               return BadRequest($"Erro: {ex.Message}");
           }
       }
       [HttpGet("especialidade/{especialidadeId}")]
       public async Task<IActionResult> GetByEspecialidade(int especialidadeId){
           try
           {
               var result = await _repo.GetAllMedicoModelByEspecialidadeId(especialidadeId, true);
               return Ok(result);
           }
           catch (Exception ex)
           { 
               return BadRequest($"Erro: {ex.Message}");
           }
       }

        [HttpPost]
        public async Task<IActionResult> post (MedicoModel model){
        try
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Ok (model);
            }
        }
        catch (Exception ex)
        {

           return BadRequest($"Erro: {ex.Message}");    
        
        }
           return BadRequest();
    }
    [HttpPut ("{medicoId}")]
    public async Task<IActionResult> put(int medicoId, MedicoModel model){
    try
    {
        var medico = await _repo.GetMedicoModelById(medicoId, false);
        if (medico == null ){
            return NotFound();
        }
        _repo.Update(model);
        if (await _repo.SaveChangesAsync()){
            return Ok ("Alteração Realizada com Sucesso");
        }
    }
    catch (Exception ex)
    {
         return BadRequest($"Erro: {ex.Message}");
    }

      return BadRequest();
    }

    [HttpDelete("{medicoId}")]
    public async Task<IActionResult> delete(int medicoId){
    try
    {
        var medico = await _repo.GetMedicoModelById(medicoId,false);
        if (medico == null) return NotFound();
        _repo.Delete(medico);
        if (await _repo.SaveChangesAsync()){
           return Ok(new {message="Medico Deletado"});
        }
        
    }
    catch (Exception ex)
    {
         return BadRequest($"Erro: {ex.Message}");
    }
         return BadRequest();
}
}
}
