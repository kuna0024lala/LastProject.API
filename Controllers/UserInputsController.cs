using LastProject.API.Data;
using LastProject.API.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LastProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInputsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UserInputsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInputs()
        {
            var userInputs =  await dbContext.UserInputs.ToListAsync();
            return Ok(userInputs);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserInput([FromBody] UserInput userInput)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingInput = await dbContext.UserInputs.FirstOrDefaultAsync(x => x.InputNumber == userInput.InputNumber);
            if (existingInput != null)
            {
                return BadRequest("Number already exist");
            }

            await dbContext.UserInputs.AddAsync(userInput);
            await dbContext.SaveChangesAsync();
            return Ok(userInput);
        }
    }
}
