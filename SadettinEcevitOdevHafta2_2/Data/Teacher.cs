namespace SadettinEcevitOdevHafta2_2.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Lesson Lesson { get; set; }
    }



}
