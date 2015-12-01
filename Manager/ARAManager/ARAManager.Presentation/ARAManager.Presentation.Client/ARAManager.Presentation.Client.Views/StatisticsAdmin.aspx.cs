// --------------------------------------------------------------------------------------------------------------------
/* <header file="StatisticsAdmin.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for StatisticsAdmin page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using AjaxControlToolkit;
using ARAManager.Common.Dto;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class StatisticsAdmin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customersList = ClientServiceFactory.CustomerService.GetAllCustomers();
            LoadSexPieChart(customersList);
            LoadAgeChart(GetAgeRanges(customersList));
        }
        /// <summary>
        /// Load the values for customer sex pie chart
        /// </summary>
        private void LoadSexPieChart(IList<Customer> customers)
        {
            SexPieChart.PieChartClientValues.Add(new PieChartValue()
            {
                Category = "Male",
                Data = customers.Count(c => c.Sex == "Male"),
                PieChartValueColor = "green",
                PieChartValueStrokeColor = "white"
            });

            SexPieChart.PieChartClientValues.Add(new PieChartValue()
            {
                Category = "Female",
                Data = customers.Count(c => c.Sex == "Female"),
                PieChartValueColor = "pink",
                PieChartValueStrokeColor = "red"
            });
        }

        private void LoadAgeChart(Dictionary<string, int> ageRanges)
        {
            foreach (var ageRange in ageRanges)
            {
                if (ageRange.Value > 0)
                {
                    AgePieChart.PieChartClientValues.Add(new PieChartValue()
                    {
                        Category = ageRange.Key,
                        Data = ageRange.Value
                    });
                }
            }
        }

        private Dictionary<string, int> GetAgeRanges(IList<Customer> customers)
        {
            var ageDic = new Dictionary<string, int>();
            
            ageDic.Add("1-20", customers.Count(c =>
                GetAge(c.BirthDay) < 21
            ));
            ageDic.Add("21-30", customers.Count(c=>GetAge(c.BirthDay) > 20 && GetAge(c.BirthDay) < 31));
            ageDic.Add("31-40", customers.Count(c => GetAge(c.BirthDay) > 30 && GetAge(c.BirthDay) < 41));
            ageDic.Add("41-50", customers.Count(c => GetAge(c.BirthDay) > 40 && GetAge(c.BirthDay) < 51));
            ageDic.Add("51-60", customers.Count(c => GetAge(c.BirthDay) > 50 && GetAge(c.BirthDay) < 61));
            ageDic.Add(">60", customers.Count(c => GetAge(c.BirthDay) > 60));

            return ageDic;
        }

        public Int32 GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
    }
}