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
    public class CellController : ControllerBase
    {
        private readonly ICellService cellService;
        public CellController(ICellService cellService)
        {
            this.cellService = cellService;

        }
        [HttpGet]
        [Route("Getimage")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Cell GetImg()
        {
            return cellService.GetImg();
        }
        [HttpPut]
        [Route("putcell")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update()
        {
            Cell cell = new Cell();
            var file1 = Request.Form.Files;
            string[] fill = new string[file1.Count];
            try
            {
                for (int i = 0; i < file1.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    using (var memory = new MemoryStream())
                    {
                        file.CopyTo(memory);
                        memory.ToArray();
                    }
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string imageFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                    string path = Path.Combine("./../../ERPSystemFE/src/assets/cellsImg/", imageFileName);
                    using (var filest = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filest);
                    }
                    fill[i] = imageFileName;
                }
                cell.img1 = fill[0];
                cell.img2 = fill[1];
                cell.img3 = fill[2];
                cell.img4 = fill[3];
                cell.img5 = fill[4];
                cell.img6 = fill[5];
                cell.img7 = fill[6];
                return cellService.Update(cell);



            }
            catch (FileLoadException e)
            {
                return false;
            }
        }


    }
}
