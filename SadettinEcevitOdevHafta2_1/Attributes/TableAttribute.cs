namespace SadettinEcevitOdevHafta2_1.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Deger { get; set; }  
        public TableAttribute(string deger)
        {
            Deger = deger;
        }
    }
}
