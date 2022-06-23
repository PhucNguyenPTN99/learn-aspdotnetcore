namespace Meeting.Core.Entities.Common
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
