using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private IRateService rateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public IViewComponentResult Invoke(string title, string subtitle)
        {
            var ratesVM = new CreditCardWidgetVM()
            {                
                WidgetTitle = title,
                WidgetSubTitle = subtitle,
                Rates = rateService.GetCreditCardRates()
            };

            return View(ratesVM);
        }
    }

    // TODO: Move to external class
    public class CreditCardWidgetVM
    {
        public string WidgetTitle { get; set; }
        public string WidgetSubTitle { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
