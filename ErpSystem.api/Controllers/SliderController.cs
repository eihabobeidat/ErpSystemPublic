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
    public class SliderController : ControllerBase
    {
        private readonly ISliderService sliderService;
        public SliderController(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }
        [HttpGet]
        [Route("getslider")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<SliderImageDTO> GetImage()
        {
            return sliderService.GetImage();
        }
        [HttpGet]
        [Route("InsertSliderId")]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
       

        [HttpPost]
        [Route("postslider")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool newSlider()
        {
            SliderImageDTO sliderImageDTO = new SliderImageDTO();
            var file = Request.Form.Files;

            string[] fill = new string[file.Count];
            for(int i=0;i<file.Count;i++)
            { 
            using (var memory = new MemoryStream())
            {
                file[i].CopyTo(memory);
                memory.ToArray();
            }
            var fileName = Path.GetFileNameWithoutExtension(file[i].FileName);
            string imageFileName = $"{fileName}.{Path.GetExtension(file[i].FileName).Replace(".", "")}";
            string path = Path.Combine("./../../ERPSystemFE/src/assets/SliderImage/", imageFileName);
            using (var filest = new FileStream(path, FileMode.Create))
            {
                file[i].CopyTo(filest);
            }
                fill[i] = imageFileName;
            }

            return sliderService.newSlider(fill);

        }
        [HttpGet]
        [Route("getallimage")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<SliderImageDTO> GetAllImage()
        {
            return sliderService.GetAllImage();

        }





    }

}


