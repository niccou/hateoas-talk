using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace WebApi.Tests.Bindings.Shared
{
    public class ContextBase
    {
        private ScenarioContext Context { get; }

        protected void Set<T>(T value, [CallerMemberName] string key = "") => Context.Set(value, key);

        protected T? Get<T>([CallerMemberName] string key = "") => Context.TryGetValue(key, out T value) ? value : default;

        protected void Pending() => Context.Pending();

        protected ContextBase(ScenarioContext context)
        {
            Context = context;
        }

    }
}