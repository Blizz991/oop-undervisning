using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Optiguy;

namespace OrdreClass
{
    public class Order
    {
        private int order_id;
        private int user_id;
        private DateTime created_date;
        private List<CartProduct> products;

        public int OrderId { get { return this.order_id; } }

        public int UserId { get { return this.user_id; } set { this.user_id = value; } }

        public DateTime CreatedDate { get { return this.created_date; } set { this.created_date = value; } }

        public List<CartProduct> Products { get { return this.products; } }


        public Order(int userId)
        {
            this.user_id = userId;
            this.created_date = DateTime.Now;
        }

        public void addProduct(CartProduct item)
        {
            this.products.Add(item);
        }

        public void saveOrder()
        {
            var save_order_dict = new Dictionary<string,object>
            {
                {"FK_KundeID", UserId}
            };

            order_id = Database.DbInsertDict("Kundeordre", save_order_dict);
            //Opret en ordre i databasen - Returner id'et
            //Brug id'et fra ordren til at oprette alle ordre linier med.
        }

        public int createProductOrders()
        {
            var new_order_dict = new Dictionary<string, object> { };

            foreach (CartProduct CP in products)
            {
                new_order_dict.Add("FK_KundeordreID", user_id);
                new_order_dict.Add("FK_ProduktID", CP.Id);
                new_order_dict.Add("Antal", CP.Amount);
            }

            return Database.DbInsertDict("Produktordre", new_order_dict);
        }
    }
}