namespace SadettinEcevitOdevHafta2_2.Data
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Class> Classes { get; set; }
    }
}
