using System.Linq;
using System.Web.Mvc;

namespace mvc3spike.Core.Extensions
{
    public static class ProviderExtensions
    {
        public static void Remove<TProvider>(this FilterProviderCollection providers) where TProvider : IFilterProvider
        {
            var provider = FilterProviders.Providers.Single(f => f is TProvider);
            providers.Remove(provider);
        }
    }
}