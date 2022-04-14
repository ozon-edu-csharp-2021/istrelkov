using Ozon.MerchApi.Domain.Models;

using System.Collections.Generic;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure.Interfaces
{
    public interface IChangeTracker
    {
        IEnumerable<Entity> TrackedEntities { get; }

        public void Track(Entity entity);
    }
}