using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Northwind.WebForms
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void criterioRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var rbl = (RadioButtonList)sender;
            criterioMultiView.ActiveViewIndex =Convert.ToInt32(criterioRadioButtonList.SelectedItem.Value);

            produtosGrid.DataSourceID = $"produtosPor{criterioRadioButtonList.SelectedItem.Text}DataSource";
        }
    }
}