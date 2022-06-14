namespace SadettinEcevitOdevHafta2_2.Data
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }

}
