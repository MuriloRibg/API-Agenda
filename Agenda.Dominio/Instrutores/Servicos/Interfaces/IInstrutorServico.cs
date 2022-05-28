using Agenda.Dominio.Instrutores.Entidades;
using Agenda.Dominio.Instrutores.Enumeradores;
using System;

namespace Agenda.Dominio.Instrutores.Servicos.Interfaces
{
    public interface IInstrutorServico
    {
        Instrutor Validar(int idInstrutor);
        Instrutor Atualizar(int id, string nome, string abreviacao, string email, DisponibilidadeEnum disponibilidade, string pilar);
        Instrutor Instanciar(string nome, string abreviacao, string email, DisponibilidadeEnum disponibilidade, string pilar);
    }
}