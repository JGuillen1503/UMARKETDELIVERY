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
    public class ConfiguradorApiController : ApiController
    {
        DBJuliacaContext db = new DBJuliacaContext();

        [HttpPost]
        public IHttpActionResult AgregarConfigurador(CONFIGURADOR model)
        {

            model.IdConfigurador = Guid.NewGuid();

            try
            {
                db.CONFIGURADOR.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerConfigurador()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.CONFIGURADOR.ToList();
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
        public IHttpActionResult ObtenerConfiguradorPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.CONFIGURADOR.Where(c => c.IdConfigurador == g).FirstOrDefault();
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
        public IHttpActionResult EliminarConfiguradorPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.CONFIGURADOR.Where(c => c.IdConfigurador == g).FirstOrDefault();

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
        public IHttpActionResult ActualizarConfigurador(CONFIGURADOR model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.CONFIGURADOR.Where(c => c.IdConfigurador == model.IdConfigurador).FirstOrDefault();

                response.ColorTienda = model.ColorTienda;

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

    }
}
