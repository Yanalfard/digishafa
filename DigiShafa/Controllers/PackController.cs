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
    [RoutePrefix("api/PackCore")]
    public class PackController : ApiController
    {
        [Route("AddPack")]
        [HttpPost]
        public IHttpActionResult AddPack(TblPack pack)
        {
            var task = Task.Run(() => new PackService().AddPack(pack));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblPack(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeletePack")]
        [HttpPost]
        public IHttpActionResult DeletePack(int id)
        {
            var task = Task.Run(() => new PackService().DeletePack(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdatePack")]
        [HttpPost]
        public IHttpActionResult UpdatePack(List<object> packLogId)
        {
            TblPack pack = JsonConvert.DeserializeObject<TblPack>(packLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(packLogId[1].ToString());
            var task = Task.Run(() => new PackService().UpdatePack(pack, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllPacks")]
        [HttpGet]
        public IHttpActionResult SelectAllPacks()
        {
            var task = Task.Run(() => new PackService().SelectAllPacks());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPack> dto = new List<DtoTblPack>();
                    foreach (TblPack obj in task.Result)
                        dto.Add(new DtoTblPack(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackById")]
        [HttpPost]
        public IHttpActionResult SelectPackById(int id)
        {
            var task = Task.Run(() => new PackService().SelectPackById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblPack(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackByName")]
        [HttpPost]
        public IHttpActionResult SelectPackByName(string name)
        {
            var task = Task.Run(() => new PackService().SelectPackByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPack> dto = new List<DtoTblPack>();
                    foreach (TblPack obj in task.Result)
                        dto.Add(new DtoTblPack(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectPackBySectionId")]
        [HttpPost]
        public IHttpActionResult SelectPackBySectionId(int sectionId)
        {
            var task = Task.Run(() => new PackService().SelectPackBySectionId(sectionId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblPack> dto = new List<DtoTblPack>();
                    foreach (TblPack obj in task.Result)
                        dto.Add(new DtoTblPack(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectIngredientByPackId")]
        [HttpPost]
        public IHttpActionResult SelectIngredientByPackId(int packId)
        {
            var task = Task.Run(() => new PackService().SelectIngredientsByPackId(packId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblIngredient> dto = new List<DtoTblIngredient>();
                    foreach (TblIngredient obj in task.Result)
                        dto.Add(new DtoTblIngredient(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
