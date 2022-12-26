using ErpSystem.core.Data;
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
    public class AboutServiceController : ControllerBase
    {
        private readonly IAboutServiceService aboutServiceService;

        public AboutServiceController(IAboutServiceService aboutServiceService)
        {
            this.aboutServiceService = aboutServiceService;
        }
    

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public string Insert([FromBody] AboutService aboutService)
        {
            return aboutServiceService.Insert(aboutService);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return aboutServiceService.Delete(id);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public List<AboutService> Getall()
        {
            return aboutServiceService.Getall();
        }
        
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("updateabout")]
        public bool Update()
        {
            AboutService aboutService = new AboutService();
            var file = Request.Form.Files[0];
            var data = Request.Form.ToList();
            aboutService.Title = data[0].Value;
            aboutService.Description = data[1].Value;
            aboutService.Id = Int32.Parse(data[2].Value);
            try
            {
                using (var memory = new MemoryStream())
                {
                    file.CopyTo(memory);
                    memory.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string imageFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                string path = Path.Combine("./../../ERPSystemFE/src/assets/AboutImage/", imageFileName);
                using (var filest = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(filest);
                }
                aboutService.ImagePath = imageFileName;
                return aboutServiceService.Update(aboutService);


            }
            catch (FileLoadException e)
            {
                return false;
            }
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById/{id}")]
        public AboutService GetById(int id)
        {
            return aboutServiceService.GetById(id);
        }

    }
}
