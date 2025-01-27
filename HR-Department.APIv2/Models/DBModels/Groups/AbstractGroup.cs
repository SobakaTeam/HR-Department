using HR_Department.APIv2.Models.DBModels;
using System.ComponentModel.DataAnnotations;

namespace HR_Department.APIv2.Models.DBModels.Groups
{
    public class AbstractGroup : IGroups , IEquatable<AbstractGroup>
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual int GetPeopleCount()
        {
            return 0;
        }
        public bool Equals(AbstractGroup? other)
        {
            if (other == null) return false;
            if (this.ID == other.ID)
            {
                return true;
            }
            return false;
        }
    }
}
