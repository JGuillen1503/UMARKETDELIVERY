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
    public class UsuarioApiController : ApiController
    {
        DBJuliacaContext db = new DBJuliacaContext();

        #region LOGINUSUARIO

        [HttpPost]
        public IHttpActionResult LoginUsuario(USUARIO model)
        {
            var response = new USUARIO();

            try
            {
                response = db.USUARIO.Where(x => x.CorreoUsuario == model.CorreoUsuario && x.PasswordUsuario == model.PasswordUsuario).FirstOrDefault();

            }
            catch (Exception e)
            {
                return Ok(new ResponseModelObj { Message = e.Message });
            }

            return Ok(new ResponseModelObj { Success = true, Object = response, Message = "Se ingreso Correctamente" });
        }

        #endregion LOGINUSUARIO

        #region USUARIO

        [HttpPost]
        public IHttpActionResult AgregarUsuario(USUARIO model)
        {

            model.IdUsuario = Guid.NewGuid();
           
            try
            {
                db.USUARIO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerUsuario()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.USUARIO.ToList();
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
        public IHttpActionResult ObtenerUsuarioPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.USUARIO.Where(c => c.IdUsuario == g).FirstOrDefault();
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
        public IHttpActionResult EliminarUsuarioPorId(string id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                Guid g = Guid.Parse(id);

                var response = db.USUARIO.Where(c => c.IdUsuario == g).FirstOrDefault();
                response.EstadoUsuario = false;

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
        public IHttpActionResult ActualizarUsuario(USUARIO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.USUARIO.Where(c => c.IdUsuario == model.IdUsuario).FirstOrDefault();

                response.NomUsuario = model.NomUsuario;
                response.ApeUsuario = model.ApeUsuario;
                response.DNIUsuario = model.DNIUsuario;
                response.TelefUsuario = model.TelefUsuario;
                response.CorreoUsuario = model.CorreoUsuario;
                response.EstadoUsuario = model.EstadoUsuario;
                response.PasswordUsuario = model.PasswordUsuario;

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

        #endregion USUARIO

        #region TIPOUSUARIO

        [HttpPost]
        public IHttpActionResult AgregarTipoUsuario(TIPOUSUARIO model)
        {

            model.IdTipoUsuario = 0;

            try
            {
                db.TIPOUSUARIO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerTipoUsuario()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.TIPOUSUARIO.ToList();
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
        public IHttpActionResult ObtenerTipoUsuarioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOUSUARIO.Where(c => c.IdTipoUsuario == id).FirstOrDefault();
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
        public IHttpActionResult EliminarTipoUsuarioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {
                    
                var response = db.TIPOUSUARIO.Where(c => c.IdTipoUsuario == id).FirstOrDefault();
               

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
        public IHttpActionResult ActualizarTipoUsuario(TIPOUSUARIO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.TIPOUSUARIO.Where(c => c.IdTipoUsuario == model.IdTipoUsuario).FirstOrDefault();

                response.DescTipoUsuario = model.DescTipoUsuario;

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

        #endregion TIPOUSUARIO

        #region DIRECUSUARIO

        [HttpPost]
        public IHttpActionResult AgregarDirecUsuario(DIRECUSUARIO model)
        {

            model.IdDirecUsuario = 0;

            try
            {
                db.DIRECUSUARIO.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel { Message = e.Message });
            }

            return Ok(new ResponseModel { Success = true, Message = "Registro Exitoso" });
        }

        [HttpGet]
        public IHttpActionResult ObtenerDirecUsuario()
        {
            ResponseModelList rmOL = new ResponseModelList();
            try
            {
                var response = db.DIRECUSUARIO.ToList();
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
        public IHttpActionResult ObtenerDirecUsuarioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DIRECUSUARIO.Where(c => c.IdDirecUsuario == id).FirstOrDefault();
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
        public IHttpActionResult EliminarDirecUsuarioPorId(int id)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DIRECUSUARIO.Where(c => c.IdDirecUsuario == id).FirstOrDefault();
                
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
        public IHttpActionResult ActualizarDirecUsuario(DIRECUSUARIO model)
        {
            ResponseModelObj rmO = new ResponseModelObj();
            try
            {

                var response = db.DIRECUSUARIO.Where(c => c.IdDirecUsuario == model.IdDirecUsuario).FirstOrDefault();

                response.Longitud = model.Longitud;
                response.Latitud = model.Latitud;
                response.DescDireccion = model.DescDireccion;

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

        #endregion DIRECUSUARIO



    }
}
