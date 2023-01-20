using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interface;

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
            }
            return Ok(clientDTO);
        }
    }
}
