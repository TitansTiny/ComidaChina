using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface Interface <T>
    {
        List<T> Listar();
        bool Actualizar(T item);
        T ByNombre(string nombre);
        T ById(int id);
        bool Nuevo(T item);
        bool Eliminar(T item);
    }
}
