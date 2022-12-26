using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService qualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            this.qualificationService = qualificationService;
        }

        [HttpDelete]
        [Route("deletequal/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Delete(int id)
        {
            return qualificationService.Delete(id);
        }
        [HttpGet]
        [Route("getqualbyid/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Qualification GetQualificationById(int id)
        {
            return qualificationService.GetQualificationById(id);
        }
        [HttpGet]
        [Route("qetallqual")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Qualification> GetQualifications()
        {
            return qualificationService.GetQualifications();
        }
        [HttpGet]
        [Route("qetallqualwithname")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<GetQualNameDTO> GetQualificationsWithName()
        {
            return qualificationService.GetQualificationsWithName();
        }
        ///
        [HttpGet]
        [Route("qetallqualwithnamebyid/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<GetQualNameDTO> GetQualificationWithNameById(int id)
        {
            return qualificationService.GetQualificationWithNameById(id);
        }
        [HttpPost]
        [Route("insertnewqualfication")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public string Insert()
        {
            Qualification qualification = new Qualification();
            var file = Request.Form.Files[0];
            var data = Request.Form.ToList();
            qualification.Title = data[0].Value;
            qualification.Employeeid = Convert.ToInt32(data[1].Value);
            qualification.Time = DateTime.Now;
            try
            {
                using (var memory = new MemoryStream())
                {
                    file.CopyTo(memory);
                    memory.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string imageFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                string path = Path.Combine("./../../ERPSystemFE/src/assets/EmployeeQualification/", imageFileName);
                using (var filest = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(filest);
                }
                qualification.Filepath = imageFileName;
                return qualificationService.Insert(qualification);


            }
            catch (FileLoadException e)
            {
                return "Error";
            }
        }

        [HttpPost]
        [Route("updatequalification")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Update([FromBody] Qualification qualification)
        {
            return qualificationService.Update(qualification);
        }
    }
}
