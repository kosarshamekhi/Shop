using Shop.Model.Units;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model.Products;

public class Product
{
    public int Id { get; set; }
    [DisplayName("عنوان محصول")]
    [Required(ErrorMessage = "عنوان محصول اجباریست")]
    public string Name { get; set; }
    [DisplayName("تعداد محصول")]
    [Required(ErrorMessage = "تعداد محصول اجباریست")]
    public int Quantity { get; set; }

    [DisplayName("واحد شمارش محصول")]
    [Required(ErrorMessage = "واحد شمارش اجباریست")]
    public string Unit { get; set; }
    //public Unit Unit { get; set; }
    //public int UnitId { get; set; }
}
