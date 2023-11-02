using System.ComponentModel.DataAnnotations;
namespace Release_WebApi.Models
{
    public class Release 
    {
        
        public Release(int Id, string descricao, DateTime data, decimal valor, string avulso, string status){
            this.Id = Id;
            this.descricao = descricao;
            this.data = data;
            this.valor = valor;
            this.avulso = avulso;
            this.status = status;
        }

        [Key]
        public int Id { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public decimal valor { get; set; }
        public string avulso { get; set; }
        public string status { get; set; }
    }

}