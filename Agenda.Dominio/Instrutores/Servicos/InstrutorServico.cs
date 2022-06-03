using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Enumeradores;
using Agenda.Dominio.Instrutores.Repositorios;
using Agenda.Dominio.Instrutores.Servicos.Interfaces;
using Libraries.Dominio.Excecoes;

namespace Agenda.Dominio.Instrutores.Servicos
{
    public class InstrutorServico : IInstrutorServico
    {
        private readonly IInstrutoresRepositorio instrutorRepositorio;

        public InstrutorServico(IInstrutoresRepositorio instrutorRepositorio)
        {
            this.instrutorRepositorio = instrutorRepositorio;
        }

        public Instrutor Atualizar(int id, string nome, string abreviacao, string email, DisponibilidadeEnum disponibilidade, string pilar)
        {
            Instrutor instrutor = Validar(id);
            
            instrutor.SetNome(nome);
            instrutor.SetAbreviacao(abreviacao);
            instrutor.SetEmail(email);
            instrutor.SetDisponibilidade(disponibilidade);
            instrutor.SetPilar(pilar);
           
            return instrutor;
        }

        public Instrutor Instanciar(string nome, string abreviacao, string email, DisponibilidadeEnum disponibilidade, string pilar)
        {
            Instrutor instrutor = new Instrutor(
                nome,
                abreviacao,
                email,
                disponibilidade,
                pilar
            );

            return instrutor;
        }

        public Instrutor Validar(int idInstrutor)
        {
            Instrutor instrutor = instrutorRepositorio.Recuperar(idInstrutor);

            if(instrutor == null)
            {
                throw new RegraDeNegocioExcecao("Instrutor não encontrado!");
            }

            return instrutor;
        }
    }
}