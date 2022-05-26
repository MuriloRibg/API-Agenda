using System;
using System.Runtime.Serialization;

namespace Libraries.Dominio.Excecoes
{
   [Serializable]
    public class CampoParaOrdernacaoInformadoNaoEValidoExcecao : RegraDeNegocioExcecao
    {
        public CampoParaOrdernacaoInformadoNaoEValidoExcecao(string campo)
            : base("O campo (" + campo + ") informado para ordenação não é valido")
        {
        }

        protected CampoParaOrdernacaoInformadoNaoEValidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}