using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interface;
using System.Threading;

namespace UnitTestWithXUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ClientDTO clientDTO, CancellationToken cancellationToken)
        {
            if (clientDTO == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _clientService.Create(clientDTO, cancellationToken);
                return NoContent();
            }
            return Ok(clientDTO);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ClientDTO clientDTO, CancellationToken cancellationToken)
        {
            if (clientDTO == null)
                return BadRequest();

            if (!await _clientService.ClientExist(clientDTO.Id, cancellationToken))
                return NotFound();

            if (ModelState.IsValid)
            {
                await _clientService.Update(clientDTO,cancellationToken);
                return NoContent();
            }
            return Ok(clientDTO);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {

            if (!await _clientService.ClientExist(id, cancellationToken))
                return NotFound();
            return Ok(await _clientService.Get(id, cancellationToken));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _clientService.Get(cancellationToken));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if (!await _clientService.ClientExist(id, cancellationToken))
                return NotFound();
            await _clientService.DeleteClient(id);
            return NoContent();
        }
    }
}
