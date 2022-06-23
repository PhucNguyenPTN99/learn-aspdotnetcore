using System;

namespace Meeting.Core.Entities.Common
{
    public interface IDateEntity
    {
        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset? LastModifiedAt { get; set; }
    }
}
