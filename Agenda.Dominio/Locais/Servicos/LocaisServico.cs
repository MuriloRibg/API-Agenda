using Agenda.Dominio.Locais.Entidades;
using Agenda.Dominio.Locais.Repositorios;
using Agenda.Dominio.Locais.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Util.Extensoes;

namespace Agenda.Dominio.Locais.Servicos
{
    public class LocaisServico : ILocaisServico
    {
        private readonly ILocaisRepositorio locaisRepositorio;

        public LocaisServico(ILocaisRepositorio locaisRepositorio)
        {
            this.locaisRepositorio = locaisRepositorio;
        }

        public Local Validar(int id)
        {
            Local local = locaisRepositorio.Recuperar(id);
            
            if(local.IsNull())
                throw new RegraDeNegocioExcecao("Local não encontrado!");
            
            return local;
        }
    }
}