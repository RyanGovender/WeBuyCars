using System;
using System.Collections.Generic;
using System.Text;

namespace WeBuyCars.LogicalLayer
{
   public class UserInterfaceLogicalLayer
    {
        private static int _millage = 0;
        private static int _specs = 0;
        private static int _minValue = 0;
        private static int _paint = 0;
        private static int _serviceHistory = 0;
        private static int _year = 0;
        private static double _booKValue = 0;
        private static int _vehicleType = 0;
        private static int _make = 0;
        private static int _model = 0;

        public static void RunProgram()
        {
           
            do
            {
                GetVehicleTypes();

            } while (!ConfirmAvailableVehicle());

            GetMakes();
            GetBookValue();
            GetYear();
            GetMillage();
            GetSpecs();
            GetPaint();
            GetServiceHistory();

            var car = new VehicleLogicLayer(_vehicleType, _specs, _millage, _paint, _serviceHistory, _booKValue, _year);

            DisplayConsole("\nFinal Cost :" + car.CalculateTotalCost());
            Console.ReadKey();
        }

        public static bool ConfirmAvailableVehicle()
        {
            if(ModelsLogicLayer.VehicleTypeCount == _minValue)
            {
                DisplayConsole("None of the selected vehicle are available.");
                return false;
            }
            return true;
        }


        public static void GetVehicleTypes()
        {
            VehicleTypeLogicLayer.DisplayVehicleTypes();
            do
            {
                DisplayConsole("Enter The code of the type of vehicle :");
            } while (!int.TryParse(Console.ReadLine(), out _vehicleType) || _vehicleType < _minValue || _vehicleType > VehicleTypeLogicLayer.vehicleTypesList.Count);
            ModelsLogicLayer.GetMakeBasedOnModel(_vehicleType);

        }

        public static void GetMakes()
        {
            do
            {
                DisplayConsole("Enter the code of the Make : ");
                
            } while (!int.TryParse(Console.ReadLine(), out _make) || _make < _minValue ||_make > MakeLogicLayer.GetAllMakes().Count);
             ModelsLogicLayer.GetModels(_make,_vehicleType);

            string temp;
            do
            {
                DisplayConsole("Enter the code of the Model : ");
                temp = Console.ReadLine();
                if(temp.Equals(ModelsLogicLayer.NotSureValue))
                {
                    break;
                }
            } while (!int.TryParse(temp, out _model) || _model < ModelsLogicLayer.MinId || _model > ModelsLogicLayer.MaxId);
           
        }

        public static void GetMillage()
        {
            do
            {
                DisplayConsole("Enter The Millage of the vehicle : ");

            } while (!int.TryParse(Console.ReadLine(), out _millage) || _millage > VehicleLogicLayer.MaxMillage || _millage < VehicleLogicLayer.MinMillage);
        }

        public static void GetSpecs()
        {
            DisplayDataLogicLayer.DisplaySpecsList();
            do
            {
                DisplayConsole("\nEnter the Code of the Specs for the vehicle : ");

            } while (!int.TryParse(Console.ReadLine(), out _specs) || _specs < _minValue || _specs > DataLayer.GetSpecsCostData().Count); // add max 
        }

        public static void GetPaint()
        {
            DisplayDataLogicLayer.DisplayPaintTypes(_vehicleType);
            do
            {
                DisplayConsole("\nEnter the Code for the paint used on the vehicle : ");

            } while (!int.TryParse(Console.ReadLine(), out _paint) || _paint < _minValue || _paint > DataLayer.GetPaintTypes().Count); // add max
        }

        public static void GetServiceHistory()
        {
            DisplayDataLogicLayer.DisplayServiceTypes();
            do
            {
                DisplayConsole("\nEnter the Code for the Service History on the vehicle : ");

            } while (!int.TryParse(Console.ReadLine(), out _serviceHistory) || _serviceHistory < _minValue || _serviceHistory > DataLayer.ServiceTypes().Count);
        }
        public static void GetYear()
        {
            do
            {
                DisplayConsole("\nEnter the Year of the vehicle : ");

            } while (!int.TryParse(Console.ReadLine(), out _year) || _year < VehicleLogicLayer.minYear || _year > DateTime.Now.Year);
        }

        public static void GetBookValue()
        {
            do
            {
                DisplayConsole("\nEnter the Book Value of the vehicle : ");

            } while (!double.TryParse(Console.ReadLine(), out _booKValue) || _booKValue < _minValue || _booKValue > VehicleLogicLayer.MaxValue);
        }

        private static void DisplayConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
