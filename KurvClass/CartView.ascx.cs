using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Optiguy;
using OrdreClass;

namespace KurvClass
{
    public partial class CartView : System.Web.UI.UserControl
    {
        private Cart cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            cart = new Cart();
            if (!IsPostBack)
            {
                Refresh();    
            }   
        }

        public void Refresh()
        {
            cart = new Cart();
            CartView_Repeater.DataSource = cart.Items;
            CartView_Repeater.DataBind();
        }

        protected void CartView_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //int id = (int)e.CommandArgument;
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "plus")
            {
                cart.addAmountOnProduct(id, 1);
            }
            else if (e.CommandName == "minus")
            {
                cart.reduceAmountOnProduct(id, 1);
            }

            Refresh();
        }

        protected void Empty_Cart_Button_Click(object sender, EventArgs e)
        {
            cart.removeAllProductsFromCart();
            Refresh();
        }

        protected void Checkout_Cart_Button_Click(object sender, EventArgs e)
        {
           Response.Redirect("")
        }
    }
}