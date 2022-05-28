namespace SadettinEcevitOdevHafta2_1.SOLID
{
    public class Motorcycle : IBicycle
    {
        public bool FrontWheels { get; set; }
        public bool BackTekerlek { get; set; }
        public bool SteeringWheel { get; set; }
        public bool Brake { get; set; }

        public bool Bike()
        {
            return true;
        }
    }

}
