using System;
using System.Globalization;
using System.Windows;

namespace SendHelp.Models
{
    public class Projectile
    {
        public double Angle { get; set; }
        public double Velocity { get; set; }

        public double CalculateDistance()
        {
            const double g = 9.81; // Erdbeschleunigung
            double angleRadians = Angle * Math.PI / 180;
            double distance = Math.Pow(Velocity, 2) * Math.Sin(2 * angleRadians) / g;
            MessageBox.Show(Convert.ToString(distance, CultureInfo.InvariantCulture));
            return distance;
        }
    }
}