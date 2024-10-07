namespace StudentTeacherQnA.Entities
{
    //define the role of the students
    public class Student : ApplicationUser
    {
        public string InstituteName { get; set; }
        public int InstituteIdCardNumber { get; set; }
    }
}
