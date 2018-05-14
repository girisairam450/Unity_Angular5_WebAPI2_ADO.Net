using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Unity
{
    public interface IIoCContainer
    {
        /// <summary>
        /// Resolve an instance of the requested type with the given name from the container.
        /// 
        /// </summary>
        /// <returns>
        /// The retrieved object.
        /// </returns>
        object Resolve(Type t, string name);

        /// <summary>
        /// Return instances of all registered types requested.
        /// 
        /// </summary>
        /// <returns>
        /// Set of objects of type <paramref name="t"/>.
        /// </returns>
        IEnumerable<object> ResolveAll(Type t);

        /// <summary>
        /// Resolve an instance of the default requested type from the container.
        /// 
        /// </summary>
        /// <returns>
        /// The retrieved object.
        /// </returns>
        T Resolve<T>();

        /// <summary>
        /// Return instances of all registered types requested.
        /// 
        /// </summary>
        /// <returns>
        /// Set of objects of type <typeparamref name="T"/>.
        /// </returns>
        IEnumerable<T> ResolveAll<T>();
    }
}
