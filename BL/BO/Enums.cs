using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public enum Areas { Galilee, North, South, Jerusalem, Haifa, Krayot, Tiberias }
    public enum Bus_status { DRIVER, AVAILABLE_TRAVEL, TREATMENT, REFUELING }
    public enum StudentStatus { ACTIVE, SUSPENDED, ACADEMIC_VACATION, FINISHED }
    public enum StudentGraduate { BSC, MSC, PHD, BA, MA, MD }
    public enum LecturerStatus { STUFF, SABBATICAL, ADJUNCT, PENSIONER, FIRED, LEFT }
    public enum LecturerPosition { TEACHER, SENIOR_TEACHER, LECTURER, SENIOR_LECTURER, ASSISTANT_PROFESSOR, ASSOCIATE_PROFESSOR, PROFESSOR, ASSISTANT_TEACHER_A, ASSISTANT_TEACHER_B }
    public enum CourseLectureStatus { LECTURER, PRACTITIONER }
}
