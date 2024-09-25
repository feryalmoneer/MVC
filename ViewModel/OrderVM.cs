using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        [MaxLength(230)]
        public string OrderName { get; set; } = null!;
        [Range (120,450)]
        public string price { get; set; } = null!;
        public DateTime OrderDateCreated { get; set; }
    }
}
