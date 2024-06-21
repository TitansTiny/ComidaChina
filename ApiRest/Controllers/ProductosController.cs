using ComidaChinaRest;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiRest.Controllers
{
    public class ProductosController : ApiController
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();

        // get
        public IHttpActionResult Get()
        {
            var respuesta = productoNegocio.All();
            return Ok(respuesta);
        }
        public IHttpActionResult Get(string nombre) 
        {
            Productos respuesta = productoNegocio.ByNombre(nombre);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Productos producto)
        {
            try
            {
                productoNegocio.insertarProductos (producto);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, Productos producto)
        {
            // Obtener el producto existente por su ID
            Productos productoExistente = productoNegocio.ById(id);
            if (productoExistente == null)
            {
                return BadRequest("El producto no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            productoExistente.nombre = producto.nombre;
            productoExistente.precio = producto.precio;
            productoExistente.descripcion = producto.descripcion;
            productoExistente.prod_img = producto.prod_img;

            // Guardar los cambios en la base de datos
            if (productoNegocio.actualizarProducto(productoExistente))
            {
                return Ok("Producto actualizado correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Productos productoEliminar = productoNegocio.ById(id);
                if (productoEliminar == null)
                {
                    return NotFound();
                }
                productoNegocio.eliminarProducto(productoEliminar);
                return Ok("Producto Eliminado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}