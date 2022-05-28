namespace SadettinEcevitOdevHafta2_1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public bool Required { get; }

        public ColumnAttribute(bool required)
        {
            Required = required;
        }
    }
}

