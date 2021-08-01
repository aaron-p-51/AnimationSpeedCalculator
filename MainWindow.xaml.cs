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

namespace Animation_Speed_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize and populate MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetDirectionsText();
        }


        /// <summary>
        /// Set the text for steps to use application
        /// </summary>
        private void SetDirectionsText()
        {
            TXT_Step1.Text = "1: Select right or left foot where you can see foot placed and removed\nfrom ground in animation.";
            TXT_Step2.Text = "2: Set/Verify working with world coordinates.";
            TXT_Step3.Text = "3: Find time where foot from step 1 is placed on ground,\nenter time and location for the axis the foot is moving.";
            TXT_Step4.Text = "4: Find timer where foot from step 2 is removed from the ground,\nenter time and location for the axis the foot is moving.";
            TXT_Step5.Text = "5: Click Calculate to see result.";
        }


        /// <summary>
        /// Clear all of the user entry fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_PlacedOnGroundTime.Clear();
            TB_PlacedOnGroundLocation.Clear();

            TB_RemovedOnGroundTime.Clear();
            TB_RemovedOnGroundLocation.Clear();

            LBL_Result.Content = string.Empty;
        }


        /// <summary>
        /// Calculate animation speed based on user entered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Calculate_Click(object sender, RoutedEventArgs e)
        {
            LBL_Result.Content = string.Empty;

            // verify all text fields contain numbers (floats)
            float DistanceStart, DistanceEnd, TimeStart, TimeEnd, Result;
            if (!float.TryParse(TB_PlacedOnGroundTime.Text, out TimeStart))
            {
                MessageBox.Show("Time Start is not a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!float.TryParse(TB_RemovedOnGroundTime.Text, out TimeEnd))
            {
                MessageBox.Show("Time End is not a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!float.TryParse(TB_PlacedOnGroundLocation.Text, out DistanceStart))
            {
                MessageBox.Show("Distance Start is not a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (!float.TryParse(TB_RemovedOnGroundLocation.Text, out DistanceEnd))
            {
                MessageBox.Show("Distance End is not a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
 
            Result = Math.Abs((DistanceEnd - DistanceStart) / (TimeEnd - TimeStart));
            LBL_Result.Content = Result.ToString();
           
        }        
    }
}
