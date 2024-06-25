using System.ComponentModel.DataAnnotations;

namespace crud_mvc.Models
{
    public class item_model
    {
        [Key]
        public int Id_item { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
