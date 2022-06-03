using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Util.Extensoes
{
    /// <summary>
    /// Métodos de extensão para as classes que implementam a interface IEnumerable
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Verificar se a lista esta vazia
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// Verificar se duas listas são iguais
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool EqualsElements<T>(this IEnumerable<T> enumerable, IEnumerable<T> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(enumerable, obj)) return true;
            if (obj.GetType() != enumerable.GetType()) return false;
            return EqualElements(enumerable, obj);
        }

        private static bool EqualElements<T>(IEnumerable<T> enumerable, IEnumerable<T> obj)
        {
            return !enumerable.Except(obj).Any() && !obj.Except(enumerable).Any();
        }
    }
}
