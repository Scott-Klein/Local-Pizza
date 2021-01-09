using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalPizza.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly LocalPizzaContext _context;

        public ToppingsController(LocalPizzaContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topping>>> GetToppings()
        {
            return await _context.Toppings.ToListAsync();
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topping>> GetTopping(int id)
        {
            var topping = await _context.Toppings.FindAsync(id);

            if (topping == null)
            {
                return NotFound();
            }

            return topping;
        }

        // PUT: api/Toppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopping(int id, Topping topping)
        {
            if (id != topping.Id)
            {
                return BadRequest();
            }

            _context.Entry(topping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingExists(id))
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

        // POST: api/Toppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("~/api/Toppings/{id}")]
        public async Task<ActionResult<Topping>> PostTopping(int? id, int[] Toppings)
        {
            var item =  _context.Items.Where(x => x.Id == id)
                .Include(x => x.ToppingsList).First();

            foreach (int toppingId in Toppings)
            {
                if (item.ToppingsList.Where(t => t.Id == toppingId).ToList().Count == 0) // if the topping is wanted but not there.
                {
                    item.ToppingsList.Add(_context.Toppings.Where(t => t.Id == toppingId).First());
                }
            }

            for (int i = item.ToppingsList.Count -1; i >= 0; i--)
            {
                if (Toppings.Where(t => t == item.ToppingsList[i].Id).Count() == 0)
                {
                    item.ToppingsList.RemoveAt(i);
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        [Route("~/api/Toppings/")]
        public async Task<ActionResult<Topping>> PostTopping(Topping topping)
        {
            var exists = await _context.Toppings.FindAsync(topping.Id);
            if (topping.Id != 0)
            {
                if (exists is not null)
                {
                    exists.Name = topping.Name;
                    exists.Price = topping.Price;
                    exists.Range = topping.Range;
                }
            }
            else
            {
                var tracked = await _context.AddAsync(topping);
                exists = tracked.Entity;
            }
            
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTopping", new { id = exists.Id }, exists); // this can be null and destroy everything.
        }
        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopping(int id)
        {
            var topping = await _context.Toppings.FindAsync(id);
            if (topping == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(topping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToppingExists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}