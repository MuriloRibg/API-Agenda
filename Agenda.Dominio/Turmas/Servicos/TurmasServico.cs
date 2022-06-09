using Agenda.Dominio.Turmas.Entidades;
using Agenda.Dominio.Turmas.Repositorios;
using Agenda.Dominio.Turmas.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;
using Libraries.Util.Extensoes;

namespace Agenda.Dominio.Turmas.Servicos
{
    public class TurmasServico : ITurmasServico
    {
        private readonly ITurmasRepositorio turmasRepositorio;
        public TurmasServico(ITurmasRepositorio turmasRepositorio)
        {
            this.turmasRepositorio = turmasRepositorio;
        }
        public Turma Validar(int id)
        {
            Turma turma = turmasRepositorio.Recuperar(id);
            if(turma.IsNull())
                throw new RegraDeNegocioExcecao("Turma não encontrada!");
            return turma;
        }
    }
}