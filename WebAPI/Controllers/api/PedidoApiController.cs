using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Models.Rs;

namespace WebAPI.Controllers.api
{
    public class PedidoApiController : ApiController
    {
        DBJuliacaContext db = new DBJuliacaContext();

        #region PEDIDO

        [HttpPost]
        public IHttpActionResult AgregarPedido(PEDIDO model)
        {

            model.IdPedido = Guid.NewGuid();

            try
            {
                db.PEDIDO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerPedido()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.PEDIDO.ToList();
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
        public IHttpActionResult ObtenerPedidoPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PEDIDO.Where(c => c.IdPedido == g).FirstOrDefault();
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
        public IHttpActionResult EliminarPedidoPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PEDIDO.Where(c => c.IdPedido == g).FirstOrDefault();
                response.EstadoPedido = 0;

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
        public IHttpActionResult ActualizarPedido(PEDIDO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.PEDIDO.Where(c => c.IdPedido == model.IdPedido).FirstOrDefault();

                response.FechPedido = model.FechPedido;
                response.EstadoPedido = model.EstadoPedido;

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

        #endregion PEDIDO

        #region PEDIDODETALLE

        [HttpPost]
        public IHttpActionResult AgregarPedidoDetalle(PEDIDODETALLE model)
        {

            model.IdPedido = Guid.NewGuid();

            try
            {
                db.PEDIDODETALLE.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerPedidoDetalle()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.PEDIDODETALLE.ToList();
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
        public IHttpActionResult ObtenerPedidoDetallePorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PEDIDODETALLE.Where(c => c.IdPedido == g).FirstOrDefault();
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
        public IHttpActionResult EliminarPedidoDetallePorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.PEDIDODETALLE.Where(c => c.IdPedido == g).FirstOrDefault();

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
        public IHttpActionResult ActualizarPedidoDetalle(PEDIDODETALLE model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.PEDIDODETALLE.Where(c => c.IdPedido == model.IdPedido).FirstOrDefault();

                response.CantProducto = model.CantProducto;
                response.PrecProducto = model.PrecProducto;

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

        #endregion PEDIDODETALLE

        #region DELIVERYPRECIO

        [HttpPost]
        public IHttpActionResult AgregarDeliveryPrecio(DELIVERYPRECIO model)
        {

            model.IdDeliveryPrecio = 0;

            try
            {
                db.DELIVERYPRECIO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerDeliveryPrecio()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.DELIVERYPRECIO.ToList();
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
        public IHttpActionResult ObtenerDeliveryPrecioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DELIVERYPRECIO.Where(c => c.IdDeliveryPrecio == id).FirstOrDefault();
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
        public IHttpActionResult EliminarDeliveryPrecioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DELIVERYPRECIO.Where(c => c.IdDeliveryPrecio == id).FirstOrDefault();


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
        public IHttpActionResult ActualizarDeliveryPrecio(DELIVERYPRECIO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DELIVERYPRECIO.Where(c => c.IdDeliveryPrecio == model.IdDeliveryPrecio).FirstOrDefault();

                response.DistanciaDelivery = model.DistanciaDelivery;
                response.PrecioDelivery = model.PrecioDelivery;

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

        #endregion PRECIODELIVERY

        #region TIPOPAGO

        [HttpPost]
        public IHttpActionResult AgregarTipoPago(DELIVERYPRECIO model)
        {

            model.IdDeliveryPrecio = 0;

            try
            {
                db.DELIVERYPRECIO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerTipoPago()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.TIPOPAGO.ToList();
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
        public IHttpActionResult ObtenerTipoPagoPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOPAGO.Where(c => c.IdTipoPago == id).FirstOrDefault();
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
        public IHttpActionResult EliminarTipoPagoPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOPAGO.Where(c => c.IdTipoPago == id).FirstOrDefault();
                response.EstadoPago = false;

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
        public IHttpActionResult ActualizarTipoPago(TIPOPAGO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOPAGO.Where(c => c.IdTipoPago == model.IdTipoPago).FirstOrDefault();

                response.DescPago = model.DescPago;
                response.EstadoPago = model.EstadoPago;

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

        #endregion TIPOPAGO
    }
}
