namespace SadettinEcevitOdevHafta2_1.Models
{
    public interface IBike : IHuman
    {
        public int Id { get; set; }
        public string Course { get; set; }
    }
}
