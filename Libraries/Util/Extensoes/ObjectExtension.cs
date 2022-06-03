using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Util.Extensoes
{
    /// <summary>
    /// Métodos de extensão para as classes do tipo object
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Verificar se o objeto é nulo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static bool IsNull(this object objeto)
        {
            return objeto == null;
        }

        /// <summary>
        /// Verificar se o objeto não é nulo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object objeto)
        {
            return objeto != null;
        }
    }
}
