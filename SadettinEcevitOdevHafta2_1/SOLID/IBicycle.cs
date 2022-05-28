namespace SadettinEcevitOdevHafta2_1.SOLID
{
    public interface IBicycle
    {
        public bool FrontWheels { get; set; }
        public bool BackTekerlek { get; set; }
        public bool SteeringWheel { get; set; }
        public bool Brake { get; set; }
        bool Bike();
    }
}
