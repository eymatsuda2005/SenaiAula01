namespace CadMedicoApi.Models
{
   public class PrivilegioModel{
public PrivilegioModel()
{
    
}
   public PrivilegioModel(int Id, string Nome)
   {
       this.Id = Id;
       this.Nome= Nome;
   }

   public int Id { get; set; }
   public string Nome { get; set; }

   }

}