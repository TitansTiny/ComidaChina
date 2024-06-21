using ComidaChinaRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PedidoDatos : Interface<Pedido>
    {
        Comida_ChinaEntities context;
        public PedidoDatos()
        {
            context = new Comida_ChinaEntities();
        }

        public Pedido BuscarId(int id)
        {
            return context.Pedido.Where(P => P.id_pedido == id).FirstOrDefault();
        }
        public bool Actualizar(Pedido item)
        {
            Pedido temp = BuscarId(item.id_pedido);
            
            temp.fecha_pedido = item.fecha_pedido;
            temp.total = item.total;
            temp.estado = item.estado;

            context.SaveChanges();
            return true;
        }

        public bool Eliminar(Pedido item)
        {
            Pedido temp = BuscarId(item.id_pedido);
            if (temp != null)
            {
                context.Pedido.Remove(temp);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Pedido> Listar()
        {
            return context.Pedido.ToList();
        }

        public bool Nuevo(Pedido item)
        {
            if (context.Pedido.Add(item) != null)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Pedido ByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Pedido ById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
