using System.Linq;
using System.Threading.Tasks;
using HomeBrewJournal.Data;
using HomeBrewJournal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace HomeBrewJournal.Pages
{
    public class EditBeerPage : ComponentBase
    {
        [Inject]
        protected BeerDbContext BeerContext { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; } = "0";

        protected BeerEditModel CurrentBeer { get; set; } = new BeerEditModel();
        protected string PageTitle { get; private set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Id == null || Id == "0")
            {
                PageTitle = "Add beer";
                return;
            }
            else
            {
                PageTitle = "Edit beer";
                var beer = await BeerContext.Beers
                                            .Where(b => b.Id == int.Parse(Id))
                                            .Select(b => new BeerEditModel()
                                            {
                                                Id = b.Id,
                                                Name = b.Name,
                                                Description = b.Description
                                            })
                                            .FirstOrDefaultAsync();

                CurrentBeer = beer;
            }

            await base.OnParametersSetAsync();
        }

        protected async Task SaveBeer()
        {
            Beer beer;

            if(CurrentBeer.Id == 0)
            {
                beer = new Beer();
                BeerContext.Beers.Add(beer);
            }
            else
            {
                beer = await BeerContext.Beers.FindAsync(int.Parse(Id));
            }

            beer.Name = CurrentBeer.Name;
            beer.Description = CurrentBeer.Description;

            await BeerContext.SaveChangesAsync();

            NavigationManager.NavigateTo("/");
        }
    }
}
