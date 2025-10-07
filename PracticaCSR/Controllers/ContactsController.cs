using Microsoft.AspNetCore.Mvc;
using PracticaCSR.Models.DTOs.Requests;
using PracticaCSR.Services;

namespace PracticaCSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAllContacts();
            if (!contacts.Any())
            {
                return NoContent();
            }
            return Ok(contacts);
        }

        [HttpGet("{contactId}")]
        public IActionResult GetByContactId(int contactId)
        {
            var contact = _contactService.GetByContactId(contactId);
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAndUpdateContactDto contactDto)
        {
            if (contactDto == null)
                return BadRequest("Invalid contact data.");

            var createdContact = _contactService.Create(contactDto);
            return Ok(createdContact);
        }

        [HttpPut("{contactId}")]
        public IActionResult Update(int contactId, [FromBody] CreateAndUpdateContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Invalid contact data.");
            }

            try
            {
                var updatedContact = _contactService.Update(contactId, contactDto);
                return Ok(updatedContact);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{contactId}")]
        public IActionResult Delete(int contactId)
        {
            var deleted = _contactService.Delete(contactId);
            if (!deleted)
            {
                return NotFound($"Contact with ID {contactId} not found.");
            }

            return NoContent();
        }
    }
}
