using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticHierarchyProcess.Classes
{
    public class Criterion
    {
        public string Name { get; set; }
        public static List<Criterion> CriteriaList { get; set; } = new List<Criterion>();
        
        public Criterion(string name)
        {
            Name = name;
        }
        public Criterion(string name, int rating)
        {
            Name = name;
        }
        /// <summary>
        /// Инициализация списка
        /// </summary>
        /// <returns></returns>
        public static List<Criterion> ListInitialization()
        {
            CriteriaList.Add(new Criterion("Цена"));
            CriteriaList.Add(new Criterion("Комнаты"));
            CriteriaList.Add(new Criterion("Размер"));
            CriteriaList.Add(new Criterion("Ремонт"));
            CriteriaList.Add(new Criterion("Балкон"));
            CriteriaList.Add(new Criterion("Остановка"));
            CriteriaList.Add(new Criterion("Магазин"));
            CriteriaList.Add(new Criterion("Природа"));
            return CriteriaList;
        }
    }
}
