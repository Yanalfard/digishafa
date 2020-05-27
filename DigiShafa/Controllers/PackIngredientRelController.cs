using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using DigiShafa.Models.Dto;
using DigiShafa.Models.Regular;
using DigiShafa.Services.Impl;

namespace DigiShafa.Controllers
{
    [RoutePrefix("api/PackIngredientRelCore")]
    public class PackIngredientRelController : ApiController
    {
        [Route("AddPackIngredientRel")]
        [HttpPost]
        public IHttpActionResult AddPackIngredientRel(TblPackIngredientRel packIngredientRel)
        {
            var task = Task.Run(() => new PackIngredientRelService().AddPackIngredientRel(packIngredientRel));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPackIngredientRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePackIngredientRel")]
        [HttpPost]
        public IHttpActionResult DeletePackIngredientRel(int id)
        {
            var task = Task.Run(() => new PackIngredientRelService().DeletePackIngredientRel(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePackIngredientRel")]
        [HttpPost]
        public IHttpActionResult UpdatePackIngredientRel(List<object> packIngredientRelLogId)
        {
            TblPackIngredientRel packIngredientRel = JsonConvert.DeserializeObject<TblPackIngredientRel>(packIngredientRelLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(packIngredientRelLogId[1].ToString());
            var task = Task.Run(() => new PackIngredientRelService().UpdatePackIngredientRel(packIngredientRel, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPackIngredientRels")]
        [HttpGet]
        public IHttpActionResult SelectAllPackIngredientRels()
        {
            var task = Task.Run(() => new PackIngredientRelService().SelectAllPackIngredientRels());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPackIngredientRel> dto = new List<DtoTblPackIngredientRel>();
                    foreach (TblPackIngredientRel obj in task.Result)
                        dto.Add(new DtoTblPackIngredientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackIngredientRelById")]
        [HttpPost]
        public IHttpActionResult SelectPackIngredientRelById(int id)
        {
            var task = Task.Run(() => new PackIngredientRelService().SelectPackIngredientRelById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPackIngredientRel(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackIngredientRelByPackId")]
        [HttpPost]
        public IHttpActionResult SelectPackIngredientRelByPackId(int kId)
        {
            var task = Task.Run(() => new PackIngredientRelService().SelectPackIngredientRelByPackId(kId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPackIngredientRel> dto = new List<DtoTblPackIngredientRel>();
                    foreach (TblPackIngredientRel obj in task.Result)
                        dto.Add(new DtoTblPackIngredientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackIngredientRelByIngredientId")]
        [HttpPost]
        public IHttpActionResult SelectPackIngredientRelByIngredientId(int redientId)
        {
            var task = Task.Run(() => new PackIngredientRelService().SelectPackIngredientRelByIngredientId(redientId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPackIngredientRel> dto = new List<DtoTblPackIngredientRel>();
                    foreach (TblPackIngredientRel obj in task.Result)
                        dto.Add(new DtoTblPackIngredientRel(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
