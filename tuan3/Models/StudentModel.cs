namespace tuan3.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public string Major { get; set; }

        public static List<StudentModel> DSDangKy = new List<StudentModel>();
    }
}
