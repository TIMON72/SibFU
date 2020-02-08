using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticHierarchyProcess.Classes
{
    public class Alternative
    {
        public string Name { get; set; }
        public static List<Alternative> AlternativesList { get; set; } = new List<Alternative>();

        public Alternative(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Инициализация списка
        /// </summary>
        /// <returns></returns>
        public static List<Alternative> ListInitialization()
        {
            AlternativesList.Add(new Alternative("Квартира 1"));
            AlternativesList.Add(new Alternative("Квартира 2"));
            AlternativesList.Add(new Alternative("Квартира 3"));
            return AlternativesList;
        }
    }
}
