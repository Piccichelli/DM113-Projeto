using System.Runtime.Serialization;

namespace DM113_AtendimentoMedico.Model
{
    [DataContract]
    public class ClienteModel
    {
        [DataMember]
        public required string Nome { get; set; }
        [DataMember]
        public required string Telefone { get; set; }
        [DataMember]
        public string? Email { get; set; }
        public ClienteModel() { }
        public ClienteModel(string nome, string telefone, string? email) 
        { 
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
