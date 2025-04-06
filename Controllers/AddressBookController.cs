using Microsoft.AspNetCore.Mvc;
using aa_interview.Services;
using aa_interview.Models;



[Route("api/[controller]")]
[ApiController]
public class AddressBookController(AddressBookService addressBookService) : ControllerBase
{
  
    [HttpGet()]
    public ActionResult<List<AddressBookEntry>> GetAllEntries()
    {
        var entries = addressBookService.GetAllEntries();
        return Ok(entries);
    }

    [HttpGet("{id}")]
    public ActionResult<AddressBookEntry> GetEntry(int id)
    {
        var entry = addressBookService.GetEntry(id);
        if (entry == null)
        {
            return NotFound();
        }
        return Ok(entry);
    }

    [HttpPost]
    public ActionResult<AddressBookEntry> CreateEntry(AddressBookEntry entry)
    {
        var createdEntry = addressBookService.AddEntry(entry);
        return CreatedAtAction(nameof(GetEntry), new { id = createdEntry.Id }, createdEntry);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEntry(int id, AddressBookEntry entry)
    {
        if (id != entry.Id)
        {
            return BadRequest();
        }

        var updated = addressBookService.UpdateEntry(entry);
        if (updated != 1)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEntry(int id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var deleted = addressBookService.DeleteEntry(id);
        if (deleted != 1)
        {
            return NotFound();
        }

        return NoContent();
    }

}
