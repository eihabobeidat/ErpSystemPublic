using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clarifai.Api;
using Clarifai.Channels;
using Grpc.Core;
using StatusCode = Clarifai.Api.Status.StatusCode;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceService attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        [HttpDelete]
        [Route("deleteattendance/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return attendanceService.Delete(id);
        }
        [HttpGet]
        [Route("getattendance")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public List<Attendance> GetAllAttendance()
        {
            return attendanceService.GetAllAttendance();
        }
        [HttpGet]
        [Route("GetByDateAndEmployeeId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Attendance> GetByDateAndEmployeeId(DateDTO dateDTO)
        {
            return attendanceService.GetByDateAndEmployeeId(dateDTO);
        }
        [HttpGet]
        [Route("GetattendanceByEmployeeId/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Attendance> GetByEmployeeId(int id)
        {
            return attendanceService.GetByEmployeeId(id);
        }
        [HttpGet]
        [Route("GetattendanceById/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Attendance GetById(int id)
        {
            return attendanceService.GetById(id);
        }
        [HttpPost]
        [Route("insertnewattendance")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool insert([FromBody] Attendance attendance)
        {
            return attendanceService.insert(attendance);
        }
        [HttpPut]
        [Route("updateattendance")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update([FromBody] Attendance attendance)
        {
            return attendanceService.Update(attendance);
        }
        [HttpPost]
        [Route("UpdateCheckIn")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCheckIn([FromBody] CheckInDTO checkInDTO)
        {
            return attendanceService.UpdateCheckIn(checkInDTO);
        }
        [HttpPost]
        [Route("UpdateCheckOut")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string UpdateCheckOut([FromBody] CheckOutDTO checkOutDTO)
        {
            return attendanceService.UpdateCheckOut(checkOutDTO);
        }

        [HttpPost]
        [Route("DetectFace")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public SliderImageDTO DetectEmployee([FromBody] SliderImageDTO face)
        {
            SliderImageDTO faceRes = new SliderImageDTO();

            var client = new V2.V2Client(ClarifaiChannel.Grpc());

            var metadata = new Metadata{
                {"Authorization", "Key 15bfd39aad9046c4b041e5138e0f92a2"}
            };

            var response = client.PostModelOutputs(
            new PostModelOutputsRequest()
            {
                UserAppId = 
                    new UserAppIDSet()
                    { 
                        UserId = "eihab_obeidat",
                        AppId = "ERP_CheckIn_FD"
                    },
                ModelId = "Face-Recgnition-V2", // <- This is the general model_id
                Inputs =
                {
                    new List<Input>()
                    {
                        new Input()
                        {
                            Data = new Data()
                            {
                                Image = new Image()
                                {
                                    Url = face.image
                                }
                            }
                        }
                    }
                }
            },
            metadata
        );
            //Console.Write("Eihab print => \n ");
            //Console.Write(response.Outputs[0].data[0);
            //Console.Write("\n\n\n\n");
            if (response.Status.Code != Clarifai.Api.Status.StatusCode.Success)
            //throw new Exception("Request failed, response: " + response);
            {
                faceRes.image = "Connection Error";

                return faceRes;
            }
            //Console.WriteLine("Predicted concepts:");
            foreach (var concept in response.Outputs[0].Data.Concepts)
            {
                //Console.WriteLine($"{concept.Name, 15} {concept.Value:0.00}");
                faceRes.image = concept.Name;
                return faceRes;
            }
            return faceRes;


        }
    }
}
