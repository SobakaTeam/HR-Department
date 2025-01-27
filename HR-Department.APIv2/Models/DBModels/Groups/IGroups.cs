namespace HR_Department.APIv2.Models.DBModels.Groups
{
    public interface IGroups
    {
        int ID { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        DateTime? CreateAt { get; set; }
        DateTime? UpdateAt { get; set; }

        int GetPeopleCount();

    }
}
