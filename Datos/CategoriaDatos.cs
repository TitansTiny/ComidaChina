using ComidaChinaRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriaDatos : Interface<Categorias>
    {
        Comida_ChinaEntities context;
        public CategoriaDatos()
        {
            context = new Comida_ChinaEntities();
        }

        public Categorias BuscarNombre(string nombre)
        {
            return context.Categorias.Where(P => P.nombre == nombre).FirstOrDefault();
        }
        public bool Actualizar(Categorias item)
        {
            Categorias temp = BuscarNombre(item.nombre);

            temp.nombre = item.nombre;
            temp.descripcion = item.descripcion;

            context.SaveChanges();
            return true;
        }

        public bool Eliminar(Categorias item)
        {
            Categorias temp = BuscarNombre(item.nombre);
            if (temp != null)
            {
                context.Categorias.Remove(temp);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Categorias> Listar()
        {
            return context.Categorias.ToList();
        }

        public bool Nuevo(Categorias item)
        {
            if (context.Categorias.Add(item) != null)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Categorias ByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Categorias ById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
