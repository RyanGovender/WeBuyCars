using System;
using System.Collections.Generic;
using System.Text;
using WeBuyCars.Models;

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

            var car = new Vehicle(_vehicleType, _specs, _millage, _paint, _serviceHistory, _booKValue, _year,_model);
            var CalculateCarCost = new VehicleLogicLayer(car);

            CalculateCarCost.DisplayVehicleReport(_make);
            Console.ReadKey();
        }

    
        public static void GetVehicleTypes()
        {
            VehicleTypeLogicLayer.DisplayVehicleTypes();
            _vehicleType = GetUserInput("\nEnter The code of the type of vehicle :", _minValue, VehicleTypeLogicLayer.vehicleTypesList.Count);
            ModelsLogicLayer.GetMakeBasedOnModel(_vehicleType);

        }

        public static void GetMakes()
        {
            _make = GetUserInput("\nEnter the code of the Make : ", _minValue, MakeLogicLayer.GetAllMakes().Count);
             ModelsLogicLayer.GetModels(_make,_vehicleType);

            string temp;
            do
            {
                DisplayConsole("\nEnter the code of the Model : ");
                temp = Console.ReadLine();
                if(temp.Equals(ModelsLogicLayer.NotSureValue))
                {
                    _model = 0;
                    break;
                }
            } while (!int.TryParse(temp, out _model) || _model < ModelsLogicLayer.MinId || _model > ModelsLogicLayer.MaxId);
           
        }

        public static void GetMillage()
        {
            _millage = GetUserInput("\nEnter The Millage of the vehicle : ",VehicleLogicLayer.MinMillage,VehicleLogicLayer.MaxMillage);
        }

        public static void GetSpecs()
        {
            DisplayDataLogicLayer.DisplaySpecsList();
            _specs = GetUserInput("\nEnter the Code of the Specs for the vehicle : ", _minValue, DataLayer.GetSpecsCostData().Count);
           
        }

        public static void GetPaint()
        {
            string temp;
            DisplayDataLogicLayer.DisplayPaintTypes(_vehicleType);
    
            do
            {
                DisplayConsole("\nEnter the Code for the paint used on the vehicle : ");
                temp = Console.ReadLine();
            } while (!int.TryParse(temp, out _paint) || _paint <= _minValue || _paint > DataLayer.GetPaintTypes().Count || PaintTypeCheck(temp)); 
        }

        public static void GetServiceHistory()
        {
            DisplayDataLogicLayer.DisplayServiceTypes();
            _serviceHistory = GetUserInput("\nEnter the Code for the Service History on the vehicle : ",_minValue,DataLayer.ServiceTypes().Count);
        }
        public static void GetYear()
        {
           _year = GetUserInput("\nEnter the Year of the vehicle: ",VehicleLogicLayer.minYear,DateTime.Now.Year);
        }

        public static void GetBookValue()
        {
            do
            {
                DisplayConsole("\nEnter the Book Value of the vehicle : ");

            } while (!double.TryParse(Console.ReadLine(), out _booKValue) || _booKValue <= _minValue || _booKValue > VehicleLogicLayer.MaxValue);
        }
        public static bool PaintTypeCheck(string temp)
        {
            if (int.TryParse(temp, out _paint) && VehicleLogicLayer.ChecKPaintRestrictions(_vehicleType, _paint) && _paint > _minValue && _paint < DataLayer.GetPaintTypes().Count)
            {
                DisplayConsole("\n The selected paint option is not available for this type of vehicle. ");
                return true;
            }
            return false;
        }

        public static int GetUserInput(string message,int minValue,int maxValue)
        {
            int returnValue;
            string data;
            do
            {
                DisplayConsole(message);
                data = Console.ReadLine();

            } while (!int.TryParse(data, out returnValue) || returnValue <= minValue || returnValue > maxValue );
            return returnValue;
        }

        public static bool ConfirmAvailableVehicle()
        {
            if (ModelsLogicLayer.VehicleTypeCount == _minValue)
            {
                DisplayConsole("\nNone of the selected vehicle are available.");
                return false;
            }
            return true;
        }

        private static void DisplayConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
