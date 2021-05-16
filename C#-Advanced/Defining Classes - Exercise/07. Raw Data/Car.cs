using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Car
    {
        
        private string model;
        public Engine engine;
        public List<Tire> tire;
        public Cargo cargo;
        public Car(string model,Engine engine,Cargo cargo,List<Tire> tire)
            
        {
            this.Model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tire = tire;
        }
        public string Model 
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
    }
}
