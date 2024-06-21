using ComidaChinaRest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos : Interface<Productos>
    {
        Comida_ChinaEntities context;
        public ProductoDatos()
        {
            context =new Comida_ChinaEntities();
        }

        public Productos ByNombre(string nombre) { 
            return context.Productos.Where(P => P.nombre == nombre).FirstOrDefault();
        }
        public Productos ById(int id)
        {
            return context.Productos.Where(P => P.id_producto == id).FirstOrDefault();
        }
        public bool Actualizar(Productos item)
        {
            Productos temp = ById(item.id_producto);

            temp.nombre= item.nombre;
            temp.descripcion= item.descripcion;
            temp.precio = item.precio;
            temp.id_categoria= item.id_categoria;
            temp.prod_img = item.prod_img;
            context.SaveChanges();
            return true;
        }

        public bool Eliminar(Productos item)
        {
            Productos temp = ById(item.id_producto);
            if (temp != null)
            {
                context.Productos.Remove(temp);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Productos> Listar()
        {
            return context.Productos.ToList();
        }

        public bool Nuevo(Productos item)
        {
            if (context.Productos.Add(item) != null)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
