using Session10.Dataset;
using Session10.Model;
using Session10.Report1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Session10.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report1 = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report1;
            Database1Entities db = new Database1Entities();
            DataSet1 data = getData(db.Transactions.ToList());
            report1.SetDataSource(data);
        }

        private DataSet1 getData(List<Transaction> transactions)
        {
            DataSet1 data = new DataSet1();
            var headertable = data.Transaction;
            var detailtable = data.TransactionDetail;

            foreach (Transaction t in transactions)
            {
                var headerRow = headertable.NewRow();
                headerRow["Id"] = t.Id;
                headerRow["CustomerId"] = t.CustomerId;
                headerRow["Date"] = t.Date;
                headertable.Rows.Add(headerRow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var detailRow = detailtable.NewRow();
                    detailRow["TransactionId"] = d.TransactionId;
                    detailRow["FoodId"] = d.FoodId;
                    detailRow["Quantity"] = d.Quantity;
                    detailtable.Rows.Add(detailRow);
                }
            }
            return data;
        }
    }
}