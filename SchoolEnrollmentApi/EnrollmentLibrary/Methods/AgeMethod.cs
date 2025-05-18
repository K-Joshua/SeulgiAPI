namespace SchoolEnrollmentApi.EnrollmentLibrary.Methods
{
    public class AgeMethod
    {

        public static int CalculateAge(DateOnly Birthday, DateOnly CurrentDate)
        {
            int Day = Birthday.Day;
            int Month = Birthday.Month;
            int Year =  Birthday.Year;
            int CurrentDay = CurrentDate.Day;
            int CurrentMonth = CurrentDate.Month;
            int CurrentYear = CurrentDate.Year;
            int age = CurrentYear - Year; 
            if ((Month > CurrentMonth) || (Month == CurrentMonth && Day > CurrentDay))
            {
                age--; // If the birth date has not occurred yet this year, subtract 1 from the age
            }
            return age;
        }
    }
}
