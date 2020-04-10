using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillTest.Core;
using CSharpFunctionalExtensions;

namespace SkillTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillTestController : BaseController
    {
        private readonly ILogger<SkillTestController> _logger;
        private readonly Messages _messages;

        public SkillTestController(Messages messages, ILogger<SkillTestController> logger)
        {
            _messages = messages;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetLokasi()
        {
            var result = _messages.Query(new LokasiListQuery());
            return Ok(result);
        }

        // [HttpGet]
        // public IActionResult GetData()
        // {
        //     var result = _messages.Query(new DataListQuery());
        //     return Ok(result);
        // }

        // [HttpGet]
        // public IActionResult GetGroupByLokasi()
        // {
        //     var result = _messages.Query(new GroupByLokasiQuery());
        //     return Ok(result);
        // }

        [HttpPost]
        public IActionResult CreateData([FromBody] NewDataDto dto)
        {
            var command = new DataCreateCommand(dto.DataID, dto.Judul, dto.Keterangan, dto.Foto, dto.LokasiID);
            Result result = _messages.Command(command);
            return FromResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateData([FromBody] EditDataDto dto)
        {
            var command = new DataUpdateCommand(dto.DataID, dto.Keterangan, dto.Foto, dto.LokasiID);
            Result result = _messages.Command(command);

            return FromResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJudul([FromBody] EditJudulDto dto)
        {
            var command = new DataUpdateJudulCommand(dto.DataID,dto.Judul);
            Result result = _messages.Command(command);

            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(long id)
        {
            Result result = _messages.Command(new DataDeleteCommand(id));
            return FromResult(result);
        }
    }
}
