using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceWebsite.MVC.Models
{
    public class StockQuote
    {
        #region Constructors and Destructors

        public StockQuote()
        {
            this.ChartEndDate = DateTime.Now;
            this.ChartEndDate = new DateTime(this.ChartEndDate.Year, this.ChartEndDate.Month, this.ChartEndDate.Day);
            this.ChartBeginDate = this.ChartEndDate.AddMonths(-6);
            this.TechnicalAnalysisBeginDate = this.ChartBeginDate;
            this.TechnicalAnalysisEndDate = this.ChartEndDate;
        }

        #endregion

        #region Public Properties

        [Required]
        [Display(Name = "Begin Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ChartBeginDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ChartEndDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TechnicalAnalysisBeginDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TechnicalAnalysisEndDate { get; set; }

        [Required(ErrorMessage = "Please enter a stock symbol.")]
        [StringLength(255)]
        [Display(Name = "Ticker Symbol")]
        public string TickerSymbol { get; set; }

        #endregion
    }
}