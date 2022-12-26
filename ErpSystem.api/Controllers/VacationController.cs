using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService service;
        public VacationController(IVacationService service)
        {
            this.service = service;
        }

        [ProducesResponseType(typeof(Task<List<VacationDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public Task<List<VacationDTO>> GetAll()
        {
            return service.GetAll();
        }

        [ProducesResponseType(typeof(Task<Vacation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:decimal}")]
        public Task<Vacation> GetById(decimal id)
        {
            return service.GetById(id);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("insertnewleave")]
        public Task<int> Insert([FromBody]Vacation vacation)
        {
            return service.Insert(vacation);
        }

        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Email")]
        public void SendEmail([FromBody] Email email)
        {
            service.SendEmail(email);
        }

        [ProducesResponseType(typeof(Task<Vacation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByIdApproved")]
        public Task<Vacation> GetApprovedById([FromBody] Vacation vacation)
        {
            return service.GetByIdApproved(vacation.Id);
        }

        [ProducesResponseType(typeof(Task<List<Vacation>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByEmployeeId")]
        public Task<List<Vacation>> GetByEmployeeId([FromBody] Vacation vacation)
        {
            var id = vacation.Id;
            return service.GetByEmployeeId(id);
        }

        [ProducesResponseType(typeof(Task<List<VacationDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByDate")]
        public Task<List<VacationDTO>> GetByDate([FromBody] IntervalDTO interval)
        {
            return service.GetByDate(interval.startDate, interval.endDate);
        }

        [ProducesResponseType(typeof(Task<List<VacationDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByIdAndDate")]
        public Task<List<VacationDTO>> GetByIdAndDate([FromBody] IntervalDTO interval)
        {
            if (interval.id.HasValue)
            {
                decimal temp = Convert.ToDecimal(interval.id);
                return service.GetByIdAndDate(temp, interval.startDate, interval.endDate);
            }
            return null;
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public Task<int> Update([FromBody]Vacation vacation)
        {
            return service.Update(vacation);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("Approve")]
        public Task<int> Approve([FromBody] ApprovalDTO approval)
        {
            return service.Approve(approval.id, approval.reviwedBy, approval.approvedBy);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:decimal}")]
        public Task<int> Delete(decimal id)
        {
            return service.Delete(id);
        }

        [HttpGet]
        [Route("GetVacationCount")]
        public VacationCountDto GetCount()
        {
            return service.GetCount();
        }

        [HttpPost]
        [Route("postnewleave")]
        public Task<int> insertLeave()
        {
            Vacation vacation  = new Vacation();
            var file = Request.Form.Files[0];
            var data = Request.Form.ToList();
            vacation.Employeeid = Convert.ToInt32(data[0].Value);
            vacation.Starttime = Convert.ToDateTime(data[1].Value);

            vacation.Endtime = Convert.ToDateTime(data[2].Value);
            vacation.Type = Int32.Parse(data[3].Value);
            vacation.Comments = data[4].Value;
            vacation.Status = 0;
            vacation.Reviewedby = 4;
            vacation.Approvedby = Convert.ToInt32(data[0].Value);




            try
            {
                using (var memory = new MemoryStream())
                {
                    file.CopyTo(memory);
                    memory.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string imageFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                string path = Path.Combine("./../../ERPSystemFE/src/assets/FileLeave/", imageFileName);
                using (var filest = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(filest);
                }
                vacation.Filepath = imageFileName;
                return service.Insert(vacation);


            }
            catch (FileLoadException e)
            {
                return service.Insert(vacation); ;
            }
        }
        [HttpGet]
        [Route("ApproveWaterMark/{FileName}")]
        public bool ApproveWaterMark(string FileName)
        {
            //Load the PDF document

            FileStream docStream = new FileStream("./../../ERPSystemFE/src/assets/FileLeave/"+FileName, FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            PdfPageBase loadedPage = loadedDocument.Pages[loadedDocument.Pages.Count-1];

            PdfGraphics graphics = loadedPage.Graphics;

            //Load the image file as stream

            FileStream imageStream = new FileStream("./../../ERPSystemFE/src/assets/OtherImage/approve.jpg", FileMode.Open, FileAccess.Read);

            PdfImage image = new PdfBitmap(imageStream);

            PdfGraphicsState state = graphics.Save();

            graphics.SetTransparency(0.25f);

            graphics.DrawImage(image, new PointF(0, 0), loadedPage.Graphics.ClientSize);

            //Save the document into stream.

            MemoryStream stream = new MemoryStream();

            loadedDocument.Save(stream);

            stream.Position = 0;

            //Close the document.

            loadedDocument.Close(true);

            //Defining the ContentType for pdf file.

            string contentType = "application/pdf";

            //Define the file name.


            string path = Path.Combine("./../../ERPSystemFE/src/assets/FileLeave/", FileName);
            using (var filest = new FileStream(path, FileMode.Create))
            {
                stream.CopyTo(filest);
            }
            //Creates a FileContentResult object by using the file contents, content type, and file name.

            return true;
        }

        [HttpGet]
        [Route("RejectWaterMark/{FileName}")]
        public bool RejectWaterMark(string FileName)
        {
            //Load the PDF document

            FileStream docStream = new FileStream("./../../ERPSystemFE/src/assets/FileLeave/" + FileName, FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            PdfPageBase loadedPage = loadedDocument.Pages[loadedDocument.Pages.Count - 1];

            PdfGraphics graphics = loadedPage.Graphics;

            //Load the image file as stream

            FileStream imageStream = new FileStream("./../../ERPSystemFE/src/assets/OtherImage/reject.png", FileMode.Open, FileAccess.Read);

            PdfImage image = new PdfBitmap(imageStream);

            PdfGraphicsState state = graphics.Save();

            graphics.SetTransparency(0.25f);

            graphics.DrawImage(image, new PointF(0, 0), loadedPage.Graphics.ClientSize);

            //Save the document into stream.

            MemoryStream stream = new MemoryStream();

            loadedDocument.Save(stream);

            stream.Position = 0;

            //Close the document.

            loadedDocument.Close(true);

            //Defining the ContentType for pdf file.

            string contentType = "application/pdf";

            //Define the file name.


            string path = Path.Combine("./../../ERPSystemFE/src/assets/FileLeave/", FileName);
            using (var filest = new FileStream(path, FileMode.Create))
            {
                stream.CopyTo(filest);
            }
            //Creates a FileContentResult object by using the file contents, content type, and file name.

            return true;
        }






    }


   
}
