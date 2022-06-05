using Agenda.Dominio.Locais.Entidades;

namespace Agenda.Dominio.Locais.Servicos.Interfaces
{
    public interface ILocaisServico
    {
        Local Validar(int id);
    }
}