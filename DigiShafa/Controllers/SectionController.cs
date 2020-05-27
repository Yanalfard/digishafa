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
    [RoutePrefix("api/SectionCore")]
    public class SectionController : ApiController
    {
        [Route("AddSection")]
        [HttpPost]
        public IHttpActionResult AddSection(TblSection section)
        {
            var task = Task.Run(() => new SectionService().AddSection(section));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblSection(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteSection")]
        [HttpPost]
        public IHttpActionResult DeleteSection(int id)
        {
            var task = Task.Run(() => new SectionService().DeleteSection(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateSection")]
        [HttpPost]
        public IHttpActionResult UpdateSection(List<object> sectionLogId)
        {
            TblSection section = JsonConvert.DeserializeObject<TblSection>(sectionLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(sectionLogId[1].ToString());
            var task = Task.Run(() => new SectionService().UpdateSection(section, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllSections")]
        [HttpGet]
        public IHttpActionResult SelectAllSections()
        {
            var task = Task.Run(() => new SectionService().SelectAllSections());
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSection> dto = new List<DtoTblSection>();
                    foreach (TblSection obj in task.Result)
                        dto.Add(new DtoTblSection(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionById")]
        [HttpPost]
        public IHttpActionResult SelectSectionById(int id)
        {
            var task = Task.Run(() => new SectionService().SelectSectionById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblSection(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectSectionByName")]
        [HttpPost]
        public IHttpActionResult SelectSectionByName(string name)
        {
            var task = Task.Run(() => new SectionService().SelectSectionByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.Count != 0)
                {
                    List<DtoTblSection> dto = new List<DtoTblSection>();
                    foreach (TblSection obj in task.Result)
                        dto.Add(new DtoTblSection(obj, HttpStatusCode.OK));
                    return Ok(dto);
                }
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
