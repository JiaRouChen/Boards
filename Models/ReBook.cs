using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_CodeFirst.Models
{
    public class ReBook
    {
        [Key]
        public long RId { get; set; } //long資料型態64位元

        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "回覆內容")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "必填")]
        [StringLength(10, ErrorMessage = "主旨最多20個字")]
        [Display(Name = "回覆人")]
        public string Author { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
        [Display(Name = "回覆時間")]
        public DateTime TimeStamp { get; set; }

        //1.1.5 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
        //這是來自Book的外來鍵(一對多)，外來鍵會在多的資料表
        [ForeignKey("Book")]
        public long GId { get; set; }
        public virtual Book? Book { get; set; } // virtual是在建立給資料庫看，可寫可不寫
    }
}
