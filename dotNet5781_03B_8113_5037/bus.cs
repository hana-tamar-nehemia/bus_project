using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace dotNet5781_03B_8113_5037
{
    public class Bus : INotifyPropertyChanged
    {
        private string licens_plate;

        public string Licens_plate
        {
            get { return licens_plate; }
            set
            {
                licens_plate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Licens_plate"));
                }

            }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }
        private float km;

        public float Km
        {
            get { return km; }
            set
            {
                km = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Km"));
                }
            }
        }
        private DateTime date_treatment;

        public DateTime Date_treatment
        {
            get { return date_treatment; }
            set
            {
                date_treatment = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Date_treatment"));
                }
            }
        }
        private int km_between_treatment;

        public int Km_between_treatment
        {
            get { return km_between_treatment; }
            set
            {
                km_between_treatment = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Km_between_treatment"));
                }
            }
        }
        public enum Status { ready = 0, on_road, at_the_gas_station, in_treatment }

        private int myVar;

        public event PropertyChangedEventHandler PropertyChanged;

        public Status MyStatus
        {
            get { return (Status)myVar; }
            set
            {
                myVar = (int)value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyStatus"));
                }

            }
        }


        public Bus()
        { }
        public Bus(DateTime _date, string _Licens_plat)
        {
            Km_between_treatment = 0;
            Km = 0;
            Licens_plate = _Licens_plat;
            Date = _date;
            Date_treatment = _date;
            MyStatus = 0;// לבנתיים
        }

        public override string ToString()
        {
            string str = "";
            if (MyStatus == (Status)0)
                str = "is ready";
            if (MyStatus == (Status)1)
                str = "on the road";
            if (MyStatus == (Status)2)
                str = "at the gas station";
            if (MyStatus == (Status)3)
                str = "in_treatment";
            string dorest_to_string = $"Licens plate {Licens_plate}\n\n the bus {str}\n\n date of activity {Date}\n\n km from the last refueling {Km}" +
                $"\n\n last treatment {Date_treatment}\n\n km from the last treatment {Km_between_treatment}\n\n ";
            return dorest_to_string;

        }
        public bool lincegood(string a)
        {
            int a2 = int.Parse(a);
            return (a2 <= 9999999 && a2 > 9999999);

        }
        public bool kmgood(string a)
        {
            int a2 = int.Parse(a);
            return (a2 <= 1200);

        }
        public bool kmtreatgood(string a)
        {
            int a2 = int.Parse(a);
            return (a2 <= 20000);

        }
        public static bool check_the_year_fit_the_digit_number(int Licens, DateTime date)
        {
            if (date.Year < 2018 && Licens <= 9999999 || date.Year > 2018 && Licens > 9999999)
                return true;
            else
                return false;
        }
        //public static int look_if_the_bus_exsist_or_fine(int k_m, string Licens, List<Bus> a)//
        //{
        //    foreach (Bus i in a)
        //    {
        //        if (i.Licens_plate == Licens)///look the right Licens_plate
        //        {
        //            DateTime date1 = DateTime.Now;
        //            TimeSpan N = date1 - i.date_treatment;
        //            if (N.Days < 356)
        //            {
        //                if (i.km + k_m < 1200 && i.km_between_treatment + k_m < 20000)//if the bus didnt do more then 1200 km
        //                {
        //                    i.km = i.km + k_m;
        //                    i.km_between_treatment += k_m;
        //                    //Console.WriteLine("done, the bus is ready to drive");
        //                    return 1;
        //                }
        //                else
        //                    //Console.WriteLine("the bus have not enough fuel");// the bus did more then 1200 km
        //                return 2;
        //            }
        //            else
        //                Console.WriteLine("the bus was taken off the road");// the bus did more then 20000 km
        //            return 3;
        //        }
        //    }
        //    Console.WriteLine("the bus dosnt exsist");//the bus doesnt exsist
        //}
        public bool checkDate()
        {
            DateTime date1 = DateTime.Now;
            TimeSpan N = date1 - date_treatment;
            if (N.Days < 356)
                return true;
            return false;
        }
        public int look_if_the_bus_exsist_or_fine(int k_m)//
        {
            DateTime date1 = DateTime.Now;
            TimeSpan N = date1 - date_treatment;
            if (N.Days < 356)
            {
                if (km + k_m < 1200 && Km_between_treatment + k_m < 20000)//if the bus didnt do more then 1200 km
                {
                    Km = Km + k_m;
                    Km_between_treatment += k_m;
                    //Console.WriteLine("done, the bus is ready to drive");
                    return 1;
                }
                else
                    //Console.WriteLine("the bus have not enough fuel");// the bus did more then 1200 km
                    return 2;
            }
            else
                Console.WriteLine("the bus was taken off the road");// the bus did more then 20000 km
            return 3;
        }
        public static void print_km7(Bus bus)
        {

            Console.WriteLine(bus.Licens_plate.Substring(0, 2) + "-" + bus.Licens_plate.Substring(2, 3) + "-" + bus.Licens_plate.Substring(5, 2) + " done " + bus.km_between_treatment + " since the last treatment");
        }
        public static void print_km8(Bus bus)
        {

            Console.WriteLine(bus.Licens_plate.Substring(0, 3) + "-" + bus.Licens_plate.Substring(3, 2) + "-" + bus.Licens_plate.Substring(5, 3) + " done " + bus.km_between_treatment + " since the last treatment");
        }
        public static bool the_bus_exsist(List<Bus> a, string n)//if the bus exsist
        {
            foreach (Bus i in a)
            {
                if (n == i.Licens_plate)
                    return true;
            }
            Console.WriteLine("the bus doesnt exsist");
            return false;
        }
    }
}
//    public class Bus:
//    {
//        public string Licens_plate { get; set; }
//        public DateTime date { get; set; }
//        public float km  { get; set; }
//        public DateTime date_treatment { get; set; }
//        public int km_between_treatment { get; set; }
//        public enum Status { ready = 0, on_road, at_the_gas_station, in_treatment }
//        public Status status { get; set; }

//        public Bus()
//        { }
//        public Bus(DateTime _date, string _Licens_plat)
//        {
//            km_between_treatment = 0;
//            km = 0;
//            Licens_plate = _Licens_plat;
//            date = _date;
//            date_treatment = _date;
//            status = 0;// לבנתיים
//        }

//        public override string ToString()
//        {
//            string str="";
//            if (status == (Status)0)
//                str = "is ready";
//            if (status == (Status)1)
//                str = "on the road";
//            if (status == (Status)2)
//                str = "at the gas station";
//            if (status == (Status)3)
//                str = "in_treatment";
//            string dorest_to_string = $"Licens plate {Licens_plate}\n\n the bus {str}\n\n date of activity {date}\n\n km from the last refueling {km}" +
//                $"\n\n last treatment {date_treatment}\n\n km from the last treatment {km_between_treatment}\n\n ";
//            return dorest_to_string;

//        }
//       // public override string ToString()
//        //{
//        //    //return string.Format("Licens plate {0}" ,Licens_plate);

//        //}

//        public static bool check_the_year_fit_the_digit_number(int Licens, DateTime date)
//        {
//            if (date.Year < 2018 && Licens <= 9999999 || date.Year > 2018 && Licens > 9999999)
//                return true;
//            else
//                return false;
//        }
//        //public static int look_if_the_bus_exsist_or_fine(int k_m, string Licens, List<Bus> a)//
//        //{
//        //    foreach (Bus i in a)
//        //    {
//        //        if (i.Licens_plate == Licens)///look the right Licens_plate
//        //        {
//        //            DateTime date1 = DateTime.Now;
//        //            TimeSpan N = date1 - i.date_treatment;
//        //            if (N.Days < 356)
//        //            {
//        //                if (i.km + k_m < 1200 && i.km_between_treatment + k_m < 20000)//if the bus didnt do more then 1200 km
//        //                {
//        //                    i.km = i.km + k_m;
//        //                    i.km_between_treatment += k_m;
//        //                    //Console.WriteLine("done, the bus is ready to drive");
//        //                    return 1;
//        //                }
//        //                else
//        //                    //Console.WriteLine("the bus have not enough fuel");// the bus did more then 1200 km
//        //                return 2;
//        //            }
//        //            else
//        //                Console.WriteLine("the bus was taken off the road");// the bus did more then 20000 km
//        //            return 3;
//        //        }
//        //    }
//        //    Console.WriteLine("the bus dosnt exsist");//the bus doesnt exsist
//        //}

//        public int look_if_the_bus_exsist_or_fine(int k_m)//
//        {
//            DateTime date1 = DateTime.Now;
//            TimeSpan N = date1 - date_treatment;
//            if (N.Days < 356)
//            {
//                if (km + k_m < 1200 && km_between_treatment + k_m < 20000)//if the bus didnt do more then 1200 km
//                {
//                    km = km + k_m;
//                    km_between_treatment += k_m;
//                    //Console.WriteLine("done, the bus is ready to drive");
//                    return 1;
//                }
//                else
//                    //Console.WriteLine("the bus have not enough fuel");// the bus did more then 1200 km
//                    return 2;
//            }
//            else
//                Console.WriteLine("the bus was taken off the road");// the bus did more then 20000 km
//            return 3;
//        }
//        public static void print_km7(Bus bus)
//        {

//            Console.WriteLine(bus.Licens_plate.Substring(0, 2) + "-" + bus.Licens_plate.Substring(2, 3) + "-" + bus.Licens_plate.Substring(5, 2) + " done " + bus.km_between_treatment + " since the last treatment");
//        }
//        public static void print_km8(Bus bus)
//        {

//            Console.WriteLine(bus.Licens_plate.Substring(0, 3) + "-" + bus.Licens_plate.Substring(3, 2) + "-" + bus.Licens_plate.Substring(5, 3) + " done " + bus.km_between_treatment + " since the last treatment");
//        }
//        public static bool the_bus_exsist(List<Bus> a, string n)//if the bus exsist
//        {
//            foreach (Bus i in a)
//            {
//                if (n == i.Licens_plate)
//                    return true;
//            }
//            Console.WriteLine("the bus doesnt exsist");
//            return false;
//        }
//    }
//}