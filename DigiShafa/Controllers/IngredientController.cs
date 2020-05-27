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
    [RoutePrefix("api/IngredientCore")]
    public class IngredientController : ApiController
    {
        [Route("AddIngredient")]
        [HttpPost]
        public IHttpActionResult AddIngredient(TblIngredient ingredient)
        {
            var task = Task.Run(() => new IngredientService().AddIngredient(ingredient));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result != null)
                    return Ok(new DtoTblIngredient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("DeleteIngredient")]
        [HttpPost]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var task = Task.Run(() => new IngredientService().DeleteIngredient(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("UpdateIngredient")]
        [HttpPost]
        public IHttpActionResult UpdateIngredient(List<object> ingredientLogId)
        {
            TblIngredient ingredient = JsonConvert.DeserializeObject<TblIngredient>(ingredientLogId[0].ToString());
            int logId = JsonConvert.DeserializeObject<int>(ingredientLogId[1].ToString());
            var task = Task.Run(() => new IngredientService().UpdateIngredient(ingredient, logId));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result)
                    return Ok(true);
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectAllIngredients")]
        [HttpGet]
        public IHttpActionResult SelectAllIngredients()
        {
            var task = Task.Run(() => new IngredientService().SelectAllIngredients());
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
        [Route("SelectIngredientById")]
        [HttpPost]
        public IHttpActionResult SelectIngredientById(int id)
        {
            var task = Task.Run(() => new IngredientService().SelectIngredientById(id));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblIngredient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }
        [Route("SelectIngredientByName")]
        [HttpPost]
        public IHttpActionResult SelectIngredientByName(string name)
        {
            var task = Task.Run(() => new IngredientService().SelectIngredientByName(name));
            if (task.Wait(TimeSpan.FromSeconds(10)))
                if (task.Result.id != -1)
                    return Ok(new DtoTblIngredient(task.Result, HttpStatusCode.OK));
                else
                    return Conflict();
            return StatusCode(HttpStatusCode.RequestTimeout);
        }

    }
}
