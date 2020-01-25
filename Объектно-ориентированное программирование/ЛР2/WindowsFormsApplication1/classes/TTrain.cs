using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class TTrain : TTransport
    {
        public string color { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="weight"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="color"></param>
        public TTrain(string speed, string weight, string numberOfSeats, string color)
        {
            this.speed = speed;
            this.weight = weight;
            this.numberOfSeats = numberOfSeats;
            this.color = color;

        }

        /// <summary>
        /// Расширенный метод от TTransport
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override string GetObjectInformation(int index)
        {
            base.GetObjectInformation(index);
            return "train";
        }
    }
}
