namespace HR_Department.APIv2.DBModels
{
    public class PersonDTO
    {
        public long Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MidleName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateOnly? Birthday { get; set; }

        public bool? IsWorking { get; set; }

        public bool? IsMarried { get; set; }

        public string? NowPlaceLiving { get; set; }

        public DateOnly? HireDate { get; set; }
    }
}
