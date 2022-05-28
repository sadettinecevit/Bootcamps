using SadettinEcevitOdevHafta2_1.Attributes;

namespace SadettinEcevitOdevHafta2_1.Models
{
    [Table("şŞıİçÇöÖüÜĞğ")]
    public class Student : IBike
    {
        [Column(true)]
        public int Id { get; set; }
        [Column(true)]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Course { get; set; }
    }
}
