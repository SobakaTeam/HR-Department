using HR_Department.API.Models.Groups;

namespace HR_Department.API.Models.Other
{
    public class AbstractBaseData : IEquatable<AbstractBaseData>
    {
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
