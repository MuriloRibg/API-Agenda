using Agenda.Dominio.Disciplinas.Entidades;
using Agenda.Dominio.Disciplinas.Repositorios;
using Agenda.Dominio.Disciplinas.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.Disciplinas.Servicos
{
    public class DisciplinasServico : IDisciplinasServico
    {
        private readonly IDisciplinasRepositorio disciplinasRepositorio;

        public DisciplinasServico(IDisciplinasRepositorio disciplinasRepositorio)
        {
            this.disciplinasRepositorio = disciplinasRepositorio;
        }

        public Disciplina Validar(int id)
        {
            Disciplina disciplina = disciplinasRepositorio.Recuperar(id);
            if (disciplina == null)
                throw new RegraDeNegocioExcecao("Disciplina não encontrada!");
            return disciplina;
        }
    }
}