using System.Composition.Convention;

namespace HR_Department.APIv2.DBModels.Types
{
    public class IJunction
    {
        public long Id { get; set; }
        public long Entity1Id { get; set; }
        public long Entity2Id { get; set; }
        public virtual object Entity1 { get; set; } = null!;
        public virtual object Entity2 { get; set; } = null!;
    }
}
