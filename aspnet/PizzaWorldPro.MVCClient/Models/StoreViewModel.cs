using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.MVCClient.Models
{
    public class StoreViewModel:Controller
    {
      public long StoreID { get; set; }
      [BindProperty]
      public string StoreName { get; set; }
      public List<string> StoreListString { get; set; }
      public List<Store> Stores { get; set; }
      public Store StoreObj { get; set; }
      public User UserObj { get; set; }

      public StoreViewModel()
      {
        Stores = new List<Store>{};
        StoreListString = new List<string>{};
      }

    }
}
