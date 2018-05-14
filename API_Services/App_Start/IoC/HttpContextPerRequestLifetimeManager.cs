using System;
using System.Web;
using Unity.Container.Lifetime;
using Unity.Lifetime;

namespace Services_WebApi2.App_Start.IoC
{
    public class HttpContextPerRequestLifetimeManager : LifetimeManager
    {
        /// <summary>
        ///     The key.
        /// </summary>
        private readonly object key = new object();

        /// <summary>
        ///     The get value.
        /// </summary>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        public override object GetValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(key))
            {
                return HttpContext.Current.Items[key];
            }

            return null;
        }

        /// <summary>
        ///     The remove value.
        /// </summary>
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items.Remove(key);
            }
        }

        /// <summary>
        ///     The set value.
        /// </summary>
        /// <param name="newValue">
        ///     The new value.
        /// </param>
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[key] = newValue;
            }
        }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            throw new NotImplementedException();
        }
    }
}