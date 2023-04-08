using MaxFit.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFit.Models.Service.Drink
{
    interface IDrinkService
    {

        IEnumerable<DrinkAllQuery> AllDrinks();
        IEnumerable<DrinkAllQuery> FindDrinks(string initialDate, string finalDate);
        bool SaveDrink();
      
    }
}
