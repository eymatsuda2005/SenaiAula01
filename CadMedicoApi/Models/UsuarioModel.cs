namespace CadMedicoApi.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() { }

            public UsuarioModel(int id, string nome, string login, string senha, int PrivilegioId)
            {
                this.Id = id;
                this.Nome = nome;
                this.Login = login;
                this.Senha = senha;
                this.PrivilegioId = PrivilegioId;

            }
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public int PrivilegioId { get; set; }
            public UsuarioModel Usuarios { get; set; }
        }


    }
