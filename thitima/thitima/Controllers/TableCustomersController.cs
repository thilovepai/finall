using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thitima.Model;

namespace thitima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCustomersController : ControllerBase
    {
        private readonly Kathi04Context _context;

        public TableCustomersController(Kathi04Context context)
        {
            _context = context;
        }

        // GET: api/TableCustomers
        [HttpGet]
        public IEnumerable<TableCustomer> GetTableCustomer()
        {
            return _context.TableCustomer;
        }

        // GET: api/TableCustomers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableCustomer = await _context.TableCustomer.FindAsync(id);

            if (tableCustomer == null)
            {
                return NotFound();
            }

            return Ok(tableCustomer);
        }

        // PUT: api/TableCustomers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableCustomer([FromRoute] string id, [FromBody] TableCustomer tableCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableCustomer.CustId)
            {
                return BadRequest();
            }

            _context.Entry(tableCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TableCustomers
        [HttpPost]
        public async Task<IActionResult> PostTableCustomer([FromBody] TableCustomer tableCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TableCustomer.Add(tableCustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableCustomerExists(tableCustomer.CustId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTableCustomer", new { id = tableCustomer.CustId }, tableCustomer);
        }

        // DELETE: api/TableCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableCustomer = await _context.TableCustomer.FindAsync(id);
            if (tableCustomer == null)
            {
                return NotFound();
            }

            _context.TableCustomer.Remove(tableCustomer);
            await _context.SaveChangesAsync();

            return Ok(tableCustomer);
        }

        private bool TableCustomerExists(string id)
        {
            return _context.TableCustomer.Any(e => e.CustId == id);
        }
    }
}