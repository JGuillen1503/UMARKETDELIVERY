using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Rs;

namespace WebAPI.Controllers.api
{
    public class ProductoApiController : ApiController
    {
        DBJuliacaContext db = new DBJuliacaContext();

        #region PRODUCTO

        [HttpGet]
        public IHttpActionResult ObtenerProducto()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.PRODUCTOS.ToList();
                rmOL.Success = true;
                rmOL.LstObject = response;
            }
            catch (Exception e)
            {

                rmOL.Message = e.Message;
            }

            return Ok(rmOL);
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto(PRODUCTOS model)
        {
            model.IdProducto = Guid.NewGuid();
            try
            {
                db.PRODUCTOS.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });

            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerProductoPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PRODUCTOS.Where(c => c.IdProducto == g).FirstOrDefault();
                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        [HttpGet]
        public IHttpActionResult EliminarProductoPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PRODUCTOS.Where(c => c.IdProducto == g).FirstOrDefault();
                response.EstadoProducto = false;

                db.Entry(response).CurrentValues.SetValues(response);
                db.SaveChanges();

                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        [HttpPost]
        public IHttpActionResult ActualizarProducto(PRODUCTOS model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.PRODUCTOS.Where(c => c.IdProducto == model.IdProducto).FirstOrDefault();

                response.EstadoProducto = model.EstadoProducto;
                response.DescProducto = model.DescProducto;

                db.Entry(response).CurrentValues.SetValues(response);
                db.SaveChanges();

                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        #endregion PRODUCTO

        #region TIPOPRODUCTO

        [HttpPost]
        public IHttpActionResult AgregarTiposProducto(TIPOSPRODUCTO model)
        {

            model.IdTipoProducto = 0;

            try
            {
                db.TIPOSPRODUCTO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerTiposProducto()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.TIPOSPRODUCTO.ToList();
                rmOL.Success = true;
                rmOL.LstObject = response;
            }
            catch (Exception e)
            {
                rmOL.Message = e.Message;
            }

            return Ok(rmOL);
        }

        [HttpGet]
        public IHttpActionResult ObtenerTiposProductoPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOSPRODUCTO.Where(c => c.IdTipoProducto == id).FirstOrDefault();
                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        [HttpGet]
        public IHttpActionResult EliminarTiposProductoPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOSPRODUCTO.Where(c => c.IdTipoProducto == id).FirstOrDefault();
                response.EstadoTipoProducto = false;

                db.Entry(response).CurrentValues.SetValues(response);
                db.SaveChanges();

                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        [HttpPost]
        public IHttpActionResult ActualizarTiposProductoUsuario(TIPOSPRODUCTO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOSPRODUCTO.Where(c => c.IdTipoProducto == model.IdTipoProducto).FirstOrDefault();

                response.DescTipoProducto = model.DescTipoProducto;

                db.Entry(response).CurrentValues.SetValues(response);
                db.SaveChanges();

                rmO.Success = true;
                rmO.Object = response;
            }
            catch (Exception e)
            {
                rmO.Message = e.Message;
            }
            return Ok(rmO);
        }

        #endregion TIPOPRODUCTO

    }
}
