namespace SadettinEcevitOdevHafta2_2.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public School School { get; set; }
        public Class Class { get; set; }
    }



}
