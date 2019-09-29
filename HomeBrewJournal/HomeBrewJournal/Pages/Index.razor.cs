using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrewJournal.Data;
using HomeBrewJournal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace HomeBrewJournal.Pages
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        protected BeerDbContext BeerContext { get; set; }
        protected IList<BeerListItemModel> Beers { get; set; }        

        protected override async Task OnParametersSetAsync()
        {
            Beers = await BeerContext.Beers
                                     .OrderBy(b => b.Name)
                                     .Select(b => new BeerListItemModel
                                     {
                                         Id = b.Id,
                                         Name = b.Name
                                     })
                                     .ToListAsync();

            await base.OnParametersSetAsync();
        }
    }
}
