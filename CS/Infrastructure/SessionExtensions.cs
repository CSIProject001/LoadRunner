// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionExtensions.cs" company="CandiSyrup">
//   VirtualHeights LLC
// </copyright>
// <summary>
//   Defines the SessionExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CS.Infrastructure
{
    using Microsoft.AspNetCore.Http;

    using Newtonsoft.Json;

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));

        }

        public static T Get<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
