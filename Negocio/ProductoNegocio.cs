using ComidaChinaRest;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        ProductoDatos producto;
        public ProductoNegocio(){
            producto = new ProductoDatos();
        }

        public List<Productos> All() { 
            return producto.Listar();
        }

        public Productos ByNombre(string nombre) {
            return producto.Listar().Where(P => P.nombre == nombre).SingleOrDefault();
        }
        public Productos ById(int id)
        {
            return producto.Listar().Where(P => P.id_producto == id).SingleOrDefault();
        }
        public bool insertarProductos(Productos nuevo) {
            return producto.Nuevo(nuevo);
        }

        public bool actualizarProducto(Productos prod)
        {
            return producto.Actualizar(prod);
        }
        public bool eliminarProducto(Productos prod)
        {
            return producto.Eliminar(prod);
        }
    }
}
