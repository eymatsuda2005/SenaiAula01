using Microsoft.AspNetCore.Mvc;
using CadMedicoApi.Data;
using System;
using System.Threading.Tasks;
using CadMedicoApi.Models;

namespace CadMedicoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CidadeController : ControllerBase
    {
        
       private readonly IRepository _repo;
       public CidadeController(IRepository repo){
           _repo = repo;
       }
       [HttpGet]
       public async Task<IActionResult> Get (){

  try
       {
           var result = await  _repo.GetAllCidadeModelAsync(true);
           return Ok(result);
       }
       catch (Exception ex)
       {
            return BadRequest($"Erro: {ex.Message}");
       }
     
        
    }
}
}