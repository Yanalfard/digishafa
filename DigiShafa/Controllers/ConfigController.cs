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
    [RoutePrefix("api/ConfigCore")]
    public class ConfigController : ApiController
    {
        [Route("AddConfig")]
        [HttpPost]
        public IHttpActionResult AddConfig(TblConfig config)
        {
            var task = Task.Run(() => new ConfigService().AddConfig(config));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConfig(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteConfig")]
        [HttpPost]
        public IHttpActionResult DeleteConfig(int id)
        {
            var task = Task.Run(() => new ConfigService().DeleteConfig(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateConfig")]
        [HttpPost]
        public IHttpActionResult UpdateConfig(List<object> configLogId)
        {
            TblConfig config = JsonConvert.DeserializeObject<TblConfig>(configLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(configLogId[1].ToString());
            var task = Task.Run(() => new ConfigService().UpdateConfig(config, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllConfigs")]
        [HttpGet]
        public IHttpActionResult SelectAllConfigs()
        {
            var task = Task.Run(() => new ConfigService().SelectAllConfigs());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblConfig> dto = new List<DtoTblConfig>();
                    foreach (TblConfig obj in task.Result)
                        dto.Add(new DtoTblConfig(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectConfigById")]
        [HttpPost]
        public IHttpActionResult SelectConfigById(int id)
        {
            var task = Task.Run(() => new ConfigService().SelectConfigById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConfig(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectConfigByTellNo")]
        [HttpPost]
        public IHttpActionResult SelectConfigByTellNo(string tellNo)
        {
            var task = Task.Run(() => new ConfigService().SelectConfigByTellNo(tellNo));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblConfig(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
