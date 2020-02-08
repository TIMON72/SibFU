using AnalyticHierarchyProcess.Classes;
using AnalyticHierarchyProcess.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyticHierarchyProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int stepNum = 0;
        readonly Step0 step0 = new Step0();
        readonly Step1 step1 = new Step1();
        readonly Step2 step2 = new Step2();
        readonly Step3 step3 = new Step3();
        /// <summary>
        /// Конструкторы
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Step.Content = step0;
            B_PreviousStep.Visibility = Visibility.Hidden;

        }
        /// <summary>
        /// Событие нажатия кнопки "Далее"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_NextStep_Click(object sender, RoutedEventArgs e)
        {
            stepNum++;
            if (stepNum == 1)
            {
                Step.Content = step1;
                B_PreviousStep.Visibility = Visibility.Visible;
            }
            else if (stepNum == 2)
            {
                Step.Content = step2;
                B_PreviousStep.Visibility = Visibility.Visible;
            }
            else if (stepNum == 3)
            {
                Step.Content = step3;
                B_PreviousStep.Visibility = Visibility.Hidden;
                B_NextStep.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Событие нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_PreviousStep_Click(object sender, RoutedEventArgs e)
        {
            stepNum--;
            if (stepNum == 0)
            {
                Step.Content = step0;
                B_PreviousStep.Visibility = Visibility.Hidden;
                B_NextStep.Visibility = Visibility.Visible;
            }
            else if (stepNum == 1)
            {
                Step.Content = step1;
                B_NextStep.Visibility = Visibility.Visible;
            }
            else if (stepNum == 2)
            {
                Step.Content = step2;
                B_NextStep.Visibility = Visibility.Visible;
            }
        }
    }
}
