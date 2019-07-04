using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppContext = EMPSYS.DAL.Context.AppContext;


namespace EMPSYS.UIL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppContext _db;

        public IndexModel(AppContext appContext)
        {
            _db = appContext;
        }
        public void OnGet()
        {
            var dd = _db.Roles;
        }
    }
}
