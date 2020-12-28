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
        public static List<> ListPersons;
        public static List<> ListCourses;
        public static List<> ListStudents;
        public static List<> ListLecturers;
        public static List<> ListLectInCourses;
        public static List<> ListStudInCourses;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        { }
    }
}
