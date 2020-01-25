using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class TBus : TTransport
    {
        public string numberOfWheels { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="weight"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="numberOfWheels"></param>
        public TBus(string speed, string weight, string numberOfSeats, string numberOfWheels)
        {
            this.speed = speed;
            this.weight = weight;
            this.numberOfSeats = numberOfSeats;
            this.numberOfWheels = numberOfWheels;
        }
        /// <summary>
        /// Расширенный метод из класса TTransport
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override string GetObjectInformation(int index)
        {
            base.GetObjectInformation(index);
            return "bus";
        }
    }
}
