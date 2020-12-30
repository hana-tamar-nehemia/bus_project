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
        //public static List<User> List_User;
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
        static int code = 11111;
        static int id = 1;
        static int line_number = 1;






        static void InitAllLists()
        {
            #region buses
            List_Bus = new List<Bus>
            {
              new Bus
              {
                  License_num = 1068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 2068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 5068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 6068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 8068393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 1168393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 2268393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3368393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4468393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 5568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 6668393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 8868393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 9968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 7568393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 4768393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              },
              new Bus
              {
                  License_num = 3968393,
                  Start_date= DateTime.Now,
                  Km=0,
                  Fuel_tank= r.Next(300),
                  Bus_status=r.Next(5)
              }



            };
            #endregion

            #region  stations//איתחול תחנות
            List_Station = new List<Station>
            {
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Latitude = 31.825302,
                    longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Latitude = 31.738425,
                    longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Latitude = 31.738676,
                    longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Latitude = 31.789128,
                    longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.766358,
                    longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Latitude = 31.790758,
                    longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.768643,
                    longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.769899,
                    longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.767064,
                    longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765863,
                    longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.799804,
                    longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765717,
                    longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767265,
                    longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767084,
                    longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.768759,
                    longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.77002,
                    longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8003,
                    longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8,
                    longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Latitude = 31.797708,
                    longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.217057
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Latitude = 31.796818,
                    longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Latitude = 31.796129,
                    longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Latitude = 31.794631,
                    longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Latitude = 31.79508,
                    longitude = 35.211684
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Latitude = 31.796255,
                    longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Latitude = 31.798423,
                    longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Latitude = 31.798689,
                    longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Latitude = 31.799165,
                    longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Latitude = 31.797829,
                    longitude = 35.205601
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Latitude = 31.840063,
                    longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Latitude = 31.838481,
                    longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
            Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Latitude = 31.837748,
                    longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Latitude = 31.840279,
                    longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Latitude = 31.843598,
                    longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Latitude = 31.766256,
                    longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Latitude = 31.76736,
                    longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Latitude = 31.770543,
                    longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Latitude = 31.768465,
                    longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Latitude = 31.759534,
                    longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Latitude = 31.761447,
                    longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.761447,
                    longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.759186,
                    longitude = 35.189336
                },


             new Station
            {
            Code = 1518,
            Name = "פרץ ברנשטיין/נזר דוד",
            Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
            Latitude = 31.759121,
            longitude = 35.189178
        },
              new Station
              {
            Code = 1522,
            Name = "מוזיאון ישראל/רופין",
            Address = "  רחוב:דרך רופין  עיר: ירושלים ",
            Latitude = 31.774484,
            longitude = 35.204882
                },

             new Station
                  {
             Code = 1523,
            Name = "הרצוג/טשרניחובסקי",
            Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
            Latitude = 31.769652,
            longitude = 35.208248
                },
              new Station
                {
              Code = 1524,
            Name = "רופין/שד' הזז",
            Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
            Latitude = 31.769652,
            longitude = 35.208248,
                 },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Latitude = 31.796033,
                    longitude =35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Latitude = 31.794958,
                    longitude =35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Latitude = 31.79617,
                    longitude =35.206158
                }

                
            
        };
            #endregion


            List_Bus_Line = new List<BusLine>
            {
            new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=73,
               Last_Station=76,



            },
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=77,
               Last_Station=78,
            } , 
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=83,
               Last_Station=84,
            },    new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=85,
               Last_Station=86,
            } , 
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=88,
               Last_Station=89,
            } , 
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=90,
               Last_Station=91,
            } , 
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=93,
               Last_Station=94,
            },  
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=95,
               Last_Station=97,
            } ,  
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=102,
               Last_Station=103,
            }   ,
                new BusLine
            {
               Bus_Id=id++,
               Area=(Areas)r.Next(7),
               Line_Number=line_number++,
               First_Station=105,
               Last_Station=106,
            }
        };
        }
    }
}
