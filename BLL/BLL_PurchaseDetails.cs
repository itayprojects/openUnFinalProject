using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PurchaseDetails : IBLL_PurchaseDetails
    {
        StoreSet newStore;
        IDAL_DATABASE newSet;

        IDAL_PurchaseDetails newPurchase;

        public BLL_PurchaseDetails()
        {
            newStore = new StoreSet();
            newSet = FactoryDal.GetStoreSet();

            newPurchase = FactoryDal.GetPurchaseDetails();
        }

        public bool Add(object NewObject)
        {
            return newPurchase.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string KeyWord)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchById(string id)
        {
            return newPurchase.SearchById(id);
        }

        public DataTable SelectByDate(DateTime startDate, DateTime endDate)
        {
            return newPurchase.SelectByDate(startDate.ToString("d"), endDate.ToString("d"));
        }
        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(object NewObject)
        {
            return newPurchase.Update(NewObject);
        }
        
        public void SendEmail(string mailToSend, string orderID)
        {
            newStore = newSet.FromIdToObject("") as StoreSet;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    string messageBody;
                    //set Source Email 
                    mail.From = new MailAddress(newStore.Email);
                    //set Destination Email
                    mail.To.Add(mailToSend);
                    mail.Subject = "Thanks for buying in " + newStore.Name;
                    //Email body message
                    messageBody = "<h3>Thanks for buying in the store " + newStore.Name + "</h3>";
                    messageBody += "<p>Order ID: " + orderID + "</p>";
                    messageBody += "<p>You can see the order on the website We will be happy to serve you again</p>";
                    mail.Body = messageBody;
                    mail.IsBodyHtml = true;

                    //set email access permissions
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {

                        smtp.Credentials = new System.Net.NetworkCredential(newStore.Email, newStore.EmailConfig);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"An Error occurred\n inner exception : " + ex.Message);
            }

        }

        public object FromIdToObject(string id)
        {
            return newPurchase.FromIdToObject(id);
        }
    }
}
