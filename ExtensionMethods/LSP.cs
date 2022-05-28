using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    //Liskov Substitution Principle : Alt sınıf kullanarak üst sınıfları tanımlayabilmek. ILogger logger = new XmlLogger() gibi.

    public class LSP
    {
        public LSP()
        {
            ICar car = new ElectricityCar();
            car.Run();
            bool result = ((IElectricityCar)car).HasBattery;
        }
    }

    public interface ICar
    {
        void Run();
    }

    public class ElectricityCar : ICar, IElectricityCar
    {
        public ElectricityCar()
        {
            HasBattery = true;
        }
        public bool HasBattery { get; set; }
        //public bool HasBattery { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Run()
        {
            //throw new NotImplementedException();
        }
    }
    
    public class PetrolCar : ICar, IPetrolCar
    {
        public PetrolCar()
        {
            HasTank = true;
        }
        public bool HasTank { get; set; }
        //public bool HasTank { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Run()
        {
            //throw new NotImplementedException();
        }
    }

    //Interface Segregation Principle : Her ihtiyaç grubuna özel olarak interface oluşturmak
    public interface IPetrolCar 
    {
        public bool HasTank { get; set; }  
    }
    
    public interface IElectricityCar
    {
        public bool HasBattery { get; set; }  
    }
}
