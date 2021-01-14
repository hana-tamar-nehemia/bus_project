using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DO;
namespace DS
{
    public class DataSource
    {
        public static List<Bus> List_Bus;
        public static List<Station> List_Station;
        public static List<User> List_User;
        public static List<AdjStation> List_Adjstation;
        public static List<BusLine> List_Bus_Line;
       // public static List<BusOnTrip> List_Bus_On_Trip;
        public static List<LineStation> List_Line_Station;
      //  public static List<LineTrip> List_Line_Trip;
        //public static List<Trip> List_Trip;


        static DataSource()
        {
            InitAllLists();
        }
        static Random r = new Random();
        static int id = 1;
        static int line_number = 1;
        static void InitAllLists()
        {
            #region bus
            List_Bus = new List<Bus>
            {
              new Bus
              {
                  License_num = 1068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 2068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 3068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 4068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 5068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 6068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 7068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 8068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 1168393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 2268393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 3368393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 4468393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 5568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 6668393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 7768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 8868393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 9968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 7568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 4768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              },
              new Bus
              {
                  License_num = 3968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5),
                  ActBus=true
              }

            };
            #endregion

            #region  stations 
            List_Station = new List<Station>
            {
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Latitude = 31.825302,
                    longitude = 35.188624,
                     Act=true
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Latitude = 31.738425,
                    longitude = 35.228765,
                     Act=true
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Latitude = 31.738676,
                    longitude = 35.226704,
                     Act=true
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Latitude = 31.789128,
                    longitude = 35.206146,
                     Act=true
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.766358,
                    longitude = 35.240417,
                     Act=true
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Latitude = 31.790758,
                    longitude = 35.209791,
                     Act=true
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.768643,
                    longitude = 35.23850,
                     Act=true
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.769899,
                    longitude = 35.23973,
                     Act=true
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.767064,
                    longitude = 35.238443,
                     Act=true
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765863,
                    longitude = 35.247198,
                     Act=true
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.799804,
                    longitude = 35.213021,
                     Act=true
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765717,
                    longitude = 35.247102,
                     Act=true
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767265,
                    longitude = 35.246594,
                     Act=true
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767084,
                    longitude = 35.246655,
                     Act=true
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.768759,
                    longitude = 31.768759,
                     Act=true
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.77002,
                    longitude = 35.24348,
                     Act=true
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8003,
                    longitude = 35.208257,
                     Act=true
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8,
                    longitude = 35.214106,
                     Act=true
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Latitude = 31.797708,
                    longitude = 35.217133,
                     Act=true
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.217057,
                     Act=true
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.213728,
                     Act=true
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Latitude = 31.796818,
                    longitude = 35.212936,
                     Act=true
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Latitude = 31.796129,
                    longitude = 35.212698,
                     Act=true
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Latitude = 31.794631,
                    longitude = 35.21161,
                     Act=true
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Latitude = 31.79508,
                    longitude = 35.211684,
                     Act=true
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Latitude = 31.796255,
                    longitude = 35.211065,
                     Act=true
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Latitude = 31.798423,
                    longitude = 35.209575,
                     Act=true
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Latitude = 31.798689,
                    longitude = 35.208878,
                     Act=true
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Latitude = 31.799165,
                    longitude = 35.206918,
                     Act=true
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Latitude = 31.797829,
                    longitude = 35.205601,
                     Act=true
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Latitude = 31.840063,
                    longitude = 35.240062,
                     Act=true

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Latitude = 31.838481,
                    longitude = 35.23972,
                     Act=true
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
            Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Latitude = 31.837748,
                    longitude = 35.231598,
                     Act=true
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Latitude = 31.840279,
                    longitude = 35.246272 ,
                     Act=true
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Latitude = 31.843598,
                    longitude = 35.243639,
                     Act=true
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Latitude = 31.766256,
                    longitude = 35.173,
                     Act=true
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Latitude = 31.76736,
                    longitude = 35.184771,
                     Act=true
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Latitude = 31.770543,
                    longitude = 35.183999,
                     Act=true
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Latitude = 31.768465,
                    longitude = 35.178701,
                     Act=true
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Latitude = 31.759534,
                    longitude = 35.173688,
                     Act=true
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Latitude = 31.761447,
                    longitude = 35.175929,
                     Act=true
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.761447,
                    longitude = 35.199936,
                     Act=true
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.759186,
                    longitude = 35.189336,
                     Act=true
                },


             new Station
            {
            Code = 1518,
            Name = "פרץ ברנשטיין/נזר דוד",
            Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
            Latitude = 31.759121,
            longitude = 35.189178,
                     Act=true
        },
              new Station
              {
            Code = 1522,
            Name = "מוזיאון ישראל/רופין",
            Address = "  רחוב:דרך רופין  עיר: ירושלים ",
            Latitude = 31.774484,
            longitude = 35.204882,
                     Act=true
                },

             new Station
                  {
             Code = 1523,
            Name = "הרצוג/טשרניחובסקי",
            Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
            Latitude = 31.769652,
            longitude = 35.208248,
                     Act=true
                },
              new Station
                {
              Code = 1524,
            Name = "רופין/שד' הזז",
            Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
            Latitude = 31.769652,
            longitude = 35.208248,
                     Act=true
                 },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Latitude = 31.796033,
                    longitude =35.206094,
                     Act=true
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Latitude = 31.794958,
                    longitude =35.205216,
                     Act=true
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Latitude = 31.79617,
                    longitude =35.206158,
                     Act=true
                }

                
            
        };
            #endregion

            #region bus line
            List_Bus_Line = new List<BusLine>
            {
            new BusLine
            {
               Bus_Id=3968393,
               Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=73,
               Last_Station=90,
                  Act=true

            },
                new BusLine
            {
               Bus_Id=4768393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=91,
               Last_Station=108,
                Act=true
            } , 
                new BusLine
            {
               Bus_Id=7568393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=109,
               Last_Station=1485,
                Act=true
            },    
              new BusLine
            {
               Bus_Id=9968393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=1486,
               Last_Station=1511,
                Act=true
            } , 
                new BusLine
            {
               Bus_Id=8868393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=1512,
               Last_Station=73,
                Act=true
            } , 
                new BusLine
            {
               Bus_Id=7768393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=73,
               Last_Station=90,
                Act=true
            } , 
                new BusLine
            {
               Bus_Id=6668393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=91,
               Last_Station=108,
                Act=true
            },  
                new BusLine
            {
               Bus_Id=5568393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=109,
               Last_Station=1485,
                Act=true
            } ,  
                new BusLine
            {
               Bus_Id=4468393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=1486,
               Last_Station=1511,
                Act=true
            }   ,
                new BusLine
            {
               Bus_Id=3368393,
                Line_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=1512,
               Last_Station=76,
                Act=true
            }
        };
            #endregion
            
            #region LineStation
            List_Line_Station = new List<LineStation>
            {
               #region 10 station bus 1
                new LineStation
                {
                    Line_Id=1,
                    Code=73,
                    Line_Station_Index=1,
                    ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=76,
                    Line_Station_Index=2,
                    ActLineStation=true
                    

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=77,
                    Line_Station_Index=3,
                     ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=78,
                    Line_Station_Index=4,
                     ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=83,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=1,
                    Code=84,
                    Line_Station_Index=6,
                    ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=85,
                    Line_Station_Index=7,
                    ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=86,
                    Line_Station_Index=8,
                    ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=1,
                    Code=89,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=1,
                    Code=90,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
                #endregion
               
               #region  10 Station bus 2
                new LineStation
                {
                    Line_Id=2,
                    Code=91,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=93,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=94,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=95,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=97,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=102,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=103,
                    Line_Station_Index=7,
ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=105,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=106,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=2,
                    Code=108,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 3
                new LineStation
                {
                    Line_Id=3,
                    Code=109,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=110,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=111,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=112,
                    Line_Station_Index=4,
                    ActLineStation=true

                },
                new LineStation
                {
                    Line_Id=3,
                    Code=113,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=115,
                    Line_Station_Index=6,
ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=116,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=117,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=119,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=1485,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 4
                new LineStation
                {
                    Line_Id=4,
                    Code=1486,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1487,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1488,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1490,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1491,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1492,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1493,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1494,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1510,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=4,
                    Code=1511,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 5
                new LineStation
                {
                    Line_Id=5,
                    Code=1512,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=1514,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=1518,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=1522,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=1523,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=1524,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=121,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=125,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=122,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=5,
                    Code=73,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region 10 station bus 6
                new LineStation
                {
                    Line_Id=6,
                    Code=73,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=76,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=77,
                    Line_Station_Index=3,

                },
                new LineStation
                {
                    Line_Id=6,
                    Code=78,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=83,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=84,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=85,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=86,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=89,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=6,
                    Code=90,
                    Line_Station_Index=10,
                     ActLineStation=true
                },
                #endregion

               #region  10 Station bus 7
                new LineStation
                {
                    Line_Id=7,
                    Code=91,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=93,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=94,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=95,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=97,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=102,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=103,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=105,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=106,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=7,
                    Code=108,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 8
                new LineStation
                {
                    Line_Id=8,
                    Code=109,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=110,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=111,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=112,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=3,
                    Code=113,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=115,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=116,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=117,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=119,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=8,
                    Code=1485,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 9
                new LineStation
                {
                    Line_Id=9,
                    Code=1486,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1487,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1488,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1490,
                    Line_Station_Index=4,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1491,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1492,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1493,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1494,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1510,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=9,
                    Code=1511,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

               #region  10 Station bus 10
                new LineStation
                {
                    Line_Id=10,
                    Code=1512,
                    Line_Station_Index=1,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=1514,
                    Line_Station_Index=2,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=1518,
                    Line_Station_Index=3,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=1522,
                    Line_Station_Index=4,
                     ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=1523,
                    Line_Station_Index=5,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=1524,
                    Line_Station_Index=6,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=121,
                    Line_Station_Index=7,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=125,
                    Line_Station_Index=8,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=122,
                    Line_Station_Index=9,
                    ActLineStation=true
                },
                new LineStation
                {
                    Line_Id=10,
                    Code=76,
                    Line_Station_Index=10,
                    ActLineStation=true
                },
               #endregion

            };
            #endregion

            #region AdjStation
            List_Adjstation = new List<AdjStation>
            {
              new AdjStation
              {
                 Code_station1=90,
                 Code_station2=73,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                 Act=true
              },
            new AdjStation
              {
                 Code_station1=73,
                 Code_station2=76,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

            },
             new AdjStation
              {
                 Code_station1=76,
                 Code_station2=77,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=77,
                 Code_station2=78,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=78,
                 Code_station2=83,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=83,
                 Code_station2=84,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=84,
                 Code_station2=85,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=85,
                 Code_station2=86,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=86,
                 Code_station2=89,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=89,
                 Code_station2=90,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=91,
                 Code_station2=93,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=93,
                 Code_station2=94,
                 Distance=r.Next(0,1000),
               Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                Act=true

              },
            new AdjStation
              {
                 Code_station1=94,
                 Code_station2=95,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=95,
                 Code_station2=97,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=97,
                 Code_station2=102,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=102,
                 Code_station2=103,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=103,
                 Code_station2=105,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=105,
                 Code_station2=106,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=106,
                 Code_station2=108,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=108,
                 Code_station2=91,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1486,
                 Code_station2=1487,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1487,
                 Code_station2=1488,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1488,
                 Code_station2=1490,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=1490,
                 Code_station2=1491,
                 Distance=r.Next(0,1000),
                  Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                   Act=true

              },
            new AdjStation
              {
                 Code_station1=1492,
                 Code_station2=1493,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=1493,
                 Code_station2=1510,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1510,
                 Code_station2=1511,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=1511,
                 Code_station2=1486,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
             new AdjStation
              {
                 Code_station1=1512,
                 Code_station2=1514,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1514,
                 Code_station2=1518,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=1518,
                 Code_station2=1522,
                 Distance=r.Next(0,1000),
                  Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1522,
                 Code_station2=1523,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=1523,
                 Code_station2=1524,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
             new AdjStation
              {
                 Code_station1=1524,
                 Code_station2=121,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=121,
                 Code_station2=125,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=125,
                 Code_station2=122,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=122,
                 Code_station2=173,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=105,
                 Code_station2=106,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
             new AdjStation
              {
                 Code_station1=106,
                 Code_station2=108,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            new AdjStation
              {
                 Code_station1=108,
                 Code_station2=91,
                 Distance=r.Next(0,1000),
                Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                 Act=true

              },
            new AdjStation
              {
                 Code_station1=122,
                 Code_station2=73,
                 Distance=r.Next(0,1000),
                 Time_Between=new TimeSpan(0, r.Next(0, 4), r.Next(0, 60)),
                                  Act=true

              },
            };
            #endregion

            List_User = new List<User>
            {
               new User
               {
                  User_name="reut",
                   password="123456",
                   Admin=true,
               },
               new User
               {
                  User_name="hana",
                   password="987654",
                   Admin=true,
               },
               new User
               {
                  User_name="reutavitan",
                   password="1234567",
                   Admin=false,
               },
               new User
               {
                  User_name="hananechamya",
                   password="123456789",
                   Admin=false,
               },

            };

        }
    }
}
