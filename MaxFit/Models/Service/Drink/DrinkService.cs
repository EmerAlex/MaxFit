using MaxFit.Models.Dto;
using MaxFit.Models.Repository.Drink;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;

namespace MaxFit.Models.Service.Drink
{
    public class DrinkService : IDrinkService
    {
        readonly DrinkRepository _DrinkRepository = new DrinkRepository();
        public IEnumerable<DrinkAllQuery> AllDrinks()
        {

            List<DrinkAllQuery> drinks = new List<DrinkAllQuery>();
            _DrinkRepository.AllDrinks().ForEach(dns => {
                drinks.Add(new DrinkAllQuery()
                {                
                    Date = dns.Date.ToString(),
                    Price = dns.Price
                });
            });
            return drinks;
        }

        public bool SaveDrink()
        {
            var drink = new Entities.Drink();
            drink.Date = DateTime.Now;
            drink.Price = (int)Models.Price.Price.agua;
            return _DrinkRepository.SaveDrink(drink);
        }

        public DrinkFindFilter FindFilterDrinks(string initialDate, string finalDate)
        {
            var drinkFind = new DrinkFindFilter();

            var drinks = FindDrinks(initialDate,finalDate);

            drinkFind.Drinks = drinks;
            drinkFind.Total = CalculateTotal(drinks);

            return drinkFind;


        }

        private int  CalculateTotal(IEnumerable<DrinkAllQuery> drinks)
        {
            int result = 0;

            drinks.ForEach(drink =>
            {
                result += drink.Price;
            });

            return result;

        }

        public IEnumerable<DrinkAllQuery> FindDrinks(string initialDate, string finalDate)
        {

            var dateInitial = new DateTime();
            var dateFinal = new DateTime();
            if (initialDate == null || finalDate == null)
            {
                dateInitial = DateTime.Now;
                dateFinal = DateTime.Now;
            }
            else
            {
                dateInitial = DateTime.Parse(initialDate);
                dateFinal = DateTime.Parse(finalDate);
            }
            

            List<DrinkAllQuery> drinks = new List<DrinkAllQuery>();
            _DrinkRepository.FindDrinks(dateInitial, dateFinal).ForEach(dks => {
                drinks.Add(new DrinkAllQuery()
                {
                    Date = dks.Date.ToString(),
                    Price = dks.Price
                });
            });
            return drinks;
        }
    }
}