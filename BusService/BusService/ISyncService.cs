﻿namespace BusService
{
    public interface ISyncService<TEntity, TContract>
    {
        Task PublishAsync(TEntity entity, string action);
        Task SynchronizeAsync(TContract entity, string action);
    }
}