using ComidaChinaRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteDatos : Interface<Cliente>
    {

        Comida_ChinaEntities context;
        public ClienteDatos()
        {
            context = new Comida_ChinaEntities();
        }

        public Cliente BuscarNombre(string nombre) { 
            return context.Cliente.Where(P => P.nombre == nombre).FirstOrDefault();
        }
        public bool Actualizar(Cliente item)
        {
            Cliente temp = BuscarNombre(item.nombre);

            temp.nombre = item.nombre;
            temp.telefono = item.telefono;
            temp.email = item.email;
            temp.direccion = item.direccion;
            
            context.SaveChanges();
            return true;
        }

        public bool Eliminar(Cliente item)
        {
            Cliente temp = BuscarNombre(item.nombre);
            if (temp != null)
            {
                context.Cliente.Remove(temp);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Cliente> Listar()
        {
            return context.Cliente.ToList();
        }

        public bool Nuevo(Cliente item)
        {
            if (context.Cliente.Add(item) != null)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Cliente ByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Cliente ById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
