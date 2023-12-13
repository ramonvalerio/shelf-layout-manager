﻿using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Rows;
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RowController : ControllerBase
    {
        private readonly ILogger<RowController> _logger;
        private readonly IRowApplication _application;

        public RowController(ILogger<RowController> logger, IRowApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet("{cabinetNumber}")]
        public async Task<ActionResult> Get(string cabinetNumber)
        {
            var result = await _application.GetRowsByCabinetNumber(cabinetNumber);
            return Ok(result);
        }

        [HttpGet("{cabinetNumber}/{number}")]
        public async Task<ActionResult> Get(string cabinetNumber, string number)
        {
            var result = await _application.GetRowByCabinetNumber(cabinetNumber, number);
            return Ok(result);
        }

        [HttpPost("{cabinetNumber}")]
        public async Task<ActionResult> Create(string cabinetNumber, [FromBody] Row row)
        {
            try
            {
                await _application.CreateRow(cabinetNumber, row);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{cabinetNumber}")]
        public async Task<ActionResult> Update(string cabinetNumber, [FromBody] Row row)
        {
            try
            {
                await _application.UpdateRow(cabinetNumber, row);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{cabinetNumber}/{number}")]
        public async Task<ActionResult> Delete(string cabinetNumber, string number)
        {
            try
            {
                await _application.DeleteRow(cabinetNumber, number);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}