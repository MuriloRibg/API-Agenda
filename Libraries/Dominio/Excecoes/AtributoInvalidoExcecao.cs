using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Dominio.Excecoes
{
    [Serializable]
    public class AtributoInvalidoExcecao : RegraDeNegocioExcecao
    {
        public AtributoInvalidoExcecao(string atributo) : base(atributo + " inválido")
        {
        }

        protected AtributoInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
