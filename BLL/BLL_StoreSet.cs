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
    public class BLL_StoreSet : IBLL_StoreSet
    {
        StoreSet newStore;
        IDAL_DATABASE newSet;

        public BLL_StoreSet()
        {
            newStore = new StoreSet();
            newSet = FactoryDal.GetStoreSet();
        }

        public DataTable Select()
        {
            return newSet.Select();
        }

        public void SendEmail(string mailToSend, string pass)
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
                    mail.Subject = "Welcom To " + newStore.Name;
                    //Email body message
                    messageBody = "<h3>Welcome to " + newStore.Name + " and thank you for register</h3>";
                    messageBody += "<p>User ID: " + mailToSend + "</p>";
                    messageBody += "<p>Password: " + pass + "</p>";
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

        public bool Add(object NewObject)
        {
            return newSet.Add(NewObject);
        }

        public bool Delete(object NewObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(object NewObject)
        {
            return newSet.Update(NewObject);
        }

        public DataTable Search(string KeyWord)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchById(string id)
        {
            throw new NotImplementedException();
        }

        public object FromIdToObject(string id)
        {
            return newSet.FromIdToObject("");
        }
    }
}
