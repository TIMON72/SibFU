using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class TPlane : TTransport
    {
        public string typeOfFuel { get; set; }
        public string numberOfWheels { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="weight"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="typeOfFuel"></param>
        public TPlane(string speed, string weight, string numberOfSeats, string typeOfFuel)
        {
            this.speed = speed;
            this.weight = weight;
            this.numberOfSeats = numberOfSeats;
            this.typeOfFuel = typeOfFuel;
        }
        /// <summary>
        /// Расширенный метод от TTransport
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override string GetObjectInformation(int index)
        {
            base.GetObjectInformation(index);
            return "plane";
        }
    }
}