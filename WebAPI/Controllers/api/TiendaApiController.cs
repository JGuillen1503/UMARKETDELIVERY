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
    public class TiendaApiController : ApiController
    {
        DBJuliacaContext db = new DBJuliacaContext();

        #region TIENDA

        [HttpGet]
        public IHttpActionResult ObtenerTiendas() 
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.TIENDAS.ToList();
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
        public IHttpActionResult AgregarTienda(TIENDAS model) 
        {
            model.IdTienda = Guid.NewGuid();
            try
            {
                db.TIENDAS.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });

            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerTiendaPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.TIENDAS.Where(c => c.IdTienda == g).FirstOrDefault();
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
        public IHttpActionResult EliminarTiendaPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.TIENDAS.Where(c => c.IdTienda == g).FirstOrDefault();
                response.EstadoTienda = false;

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
        public IHttpActionResult ActualizarTienda(TIENDAS model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIENDAS.Where(c => c.IdTienda == model.IdTienda).FirstOrDefault();

                response.DescTienda = model.DescTienda;
                response.DirecTienda = model.DirecTienda;
                response.TelefTienda = model.TelefTienda;
                response.CorreoTienda = model.CorreoTienda;
                response.EstadoTienda = model.EstadoTienda;
                

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

        #endregion TIENDA

        #region CIUDAD

        [HttpPost]
        public IHttpActionResult AgregarCiudad(CIUDAD model)
        {

             model.IdCiudad = Guid.NewGuid();
            try
            {
                db.CIUDAD.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }
            
            return Ok(new ResponseModel { Success = true,Message="Registro Exitoso"});
        }
        
        [HttpGet]
        public IHttpActionResult ObtenerCiudad()
        {
            ResponseModelList rmOL = new ResponseModelList();
              try
              {
                  var response = db.CIUDAD.ToList();
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
        public IHttpActionResult ObtenerCiudadPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);
          
                var response = db.CIUDAD.Where(c => c.IdCiudad == g).FirstOrDefault();
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
        public IHttpActionResult EliminarCiudadPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.CIUDAD.Where(c => c.IdCiudad == g).FirstOrDefault();
                response.EstadoCiudad = false;
                
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
        public IHttpActionResult ActualizarCiudad(CIUDAD model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.CIUDAD.Where(c => c.IdCiudad == model.IdCiudad).FirstOrDefault();

                response.DescCiudad = model.DescCiudad;
                response.EstadoCiudad = model.EstadoCiudad;
                
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

        #endregion CIUDAD

        #region BANNER

        [HttpGet]
        public IHttpActionResult ObtenerBanner()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.BANNER.ToList();
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
        public IHttpActionResult AgregarBanner(BANNER model)
        {
            model.IdBanner = Guid.NewGuid();
            try
            {
                db.BANNER.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });

            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerBannerPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.BANNER.Where(c => c.IdBanner == g).FirstOrDefault();
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
        public IHttpActionResult EliminarBannerPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.BANNER.Where(c => c.IdBanner == g).FirstOrDefault();
                

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
        public IHttpActionResult ActualizarBanner(BANNER model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.BANNER.Where(c => c.IdBanner == model.IdBanner).FirstOrDefault();

                response.IMGBanner = model.IMGBanner;
                response.BannerFileName = model.BannerFileName;

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

        #endregion BANNER




    }
}
