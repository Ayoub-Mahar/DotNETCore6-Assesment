using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _unitOfWork.Items.GetAll();

                if (result == null)
                {
                    return NotFound("Data not found");
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                // Log the exception or perform any necessary actions
                // Return an error response indicating a server error occurred
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item itemModel)
        {
                
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _unitOfWork.Items.Add(itemModel);
                await _unitOfWork.CompleteAsync();

                return Ok(new { StatusCode = 200, Status = "Success", Message = "Item saved successfully!" });

            }
            catch (Exception ex)
            {
                // Log the exception or perform any necessary actions
                // Return an error response indicating a server error occurred
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _unitOfWork.Items.Remove(id);
                await _unitOfWork.CompleteAsync();

                return Ok(new { StatusCode = 200, Status = "Success", Message = "Item Deleted successfully!" });

            }
            catch (Exception ex)
            {
                // Log the exception or perform any necessary actions
                // Return an error response indicating a server error occurred
                return StatusCode(500, ex.Message);
            }

        }
    }
}
