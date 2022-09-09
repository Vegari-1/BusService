using System.Text;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Polly;

using BusService.Routing;

namespace BusService
{
    public abstract class ConsumerBase<TEntity, TContract> : ISyncService<TEntity, TContract>, IConsumer
    {
        protected ILogger<ConsumerBase<TEntity, TContract>> _logger;

        protected ConsumerBase(ILogger<ConsumerBase<TEntity, TContract>> logger)
        {
            _logger = logger;
        }

        public Task Consume(string sender, byte[] data, Policy policy)
        {
            return Task.Run(() =>
                {
                    try
                    {
                        policy.Execute(async () =>
                        {
                            var entity = JsonConvert.DeserializeObject<TContract>(Encoding.UTF8.GetString(data));

                            if (entity == null)
                                throw new InvalidOperationException();

                            await SynchronizeAsync(entity, SubjectBuilder.GetEventName(sender));
                        });
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError(exception, "Entity can not be syncronized!");
                    }
                });
        }

        public abstract Task PublishAsync(TEntity entity, string action);

        public abstract Task SynchronizeAsync(TContract entity, string action);
    }
}