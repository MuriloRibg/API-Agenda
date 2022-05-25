using System.ComponentModel;

namespace Agenda.Dominio.Instrutores.Enumeradores
{
    public enum DisponibilidadeEnum
    {
        [Description("Disponível")]
        Disponivel = 0,
        [Description("Férias")]
        Férias = 1,
        [Description("Atestado")]
        Atestado = 2
    }
}
