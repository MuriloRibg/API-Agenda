using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Dominio.Excecoes
{
    [Serializable]
    public class RegistroNaoFoiEncontradoExcecao : RegraDeNegocioExcecao
    {
        public RegistroNaoFoiEncontradoExcecao(string nomeDoRegistro) : base(nomeDoRegistro + " informado(a) não foi encontrado(a)")
        {

        }

        protected RegistroNaoFoiEncontradoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
