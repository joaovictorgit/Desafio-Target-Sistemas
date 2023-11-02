using Microsoft.AspNetCore.Mvc;
using Release_WebApi.Data;
using Release_WebApi.Models;

namespace Release_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseController : ControllerBase
    {
        private readonly IRepository _repo;

        public ReleaseController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var result = await _repo.GetAllReleasesAsync();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByReleaseId(int Id)
        {
            try 
            {
                var result = await _repo.GetReleaseAsyncById(Id);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("data/{fromDate}")]
        public async Task<IActionResult> GetByReleaseData(DateTime fromDate)
        {
            try 
            {
                var result = await _repo.GetAllReleasesByData(fromDate);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Release model)
        {
            try 
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) 
                {
                    return Ok(model);
                }
            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Erro não esperado!!!");
        }

        [HttpPost("nao-avulso")]
        public async Task<IActionResult> PostNotSingle(Release model)
        {
            try 
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) 
                {
                    return Ok(model);
                }
            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Erro não esperado!!!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Release model)
        {
            try 
            {
                var release = await _repo.GetReleaseAsyncById(id);
                if (release == null) return NotFound();
                
                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) 
                {
                    return Ok(model);
                }


            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Erro não esperado!!!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                var release = await _repo.GetReleaseAsyncById(id);
                if (release == null) return NotFound();
                
                _repo.Delete(release);

                if (await _repo.SaveChangesAsync()) 
                {
                    return Ok(release);
                }


            } catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Erro não esperado!!!");
        }
    }
}