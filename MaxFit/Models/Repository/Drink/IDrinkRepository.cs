using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFit.Models.Repository.Drink
{
    internal interface IDrinkRepository
    {
        IEnumerable<Entities.Drink> AllDrinks();
        IEnumerable<Entities.Drink> FindDrinks(DateTime initialDate, DateTime finalDate);
        bool SaveDrink(Entities.Drink drink);

    }
}
