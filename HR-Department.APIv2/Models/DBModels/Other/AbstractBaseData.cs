using HR_Department.APIv2.Models.DBModels.Groups;
using System.ComponentModel.DataAnnotations;

namespace HR_Department.APIv2.Models.DBModels.Other
{
    public class AbstractBaseData : IEquatable<AbstractBaseData>
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public bool Equals(AbstractBaseData? other)
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