using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PhoneBook2.Classes;

namespace PhoneBook2
{
    
    // ADD PHONE
    public partial class AddPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user_id"] != null)
            {
                lbluserid.Text = Request.QueryString["user_id"].ToString();
                ViewState["user_id"] = Request.QueryString["user_id"].ToString();
            }
            if (Request.QueryString["contact_id"] != null)
            {
              //  lbluserid.Text = Request.QueryString["user_id"].ToString();
                ViewState["contact_id"] = Request.QueryString["contact_id"].ToString();
                int contactID = Convert.ToInt32(Request.QueryString["contact_id"].ToString());
                LoadData(contactID);
            }
        
            if (!Page.IsPostBack)
            {
                InitDropDown();
            }

        }
    
        protected void btnAdd_Phone(object sender, ImageClickEventArgs e)
        {
            Phone p = new Phone();
            int iPhoneID = 0;
            bool bValid = true;

            lblErrMsg.Text = string.Empty;
            p.ContactId = Convert.ToInt32(ViewState["contact_id"].ToString());
            p.PhoneNumber = txtPhoneNumber.Text.ToString();                                   
            p.PhoneTypeId = Convert.ToInt32(DDLPhoneType.SelectedValue);
            p.User_ID = Convert.ToInt32(ViewState["user_id"].ToString());
            

            if (bValid)
            {
                iPhoneID = p.InsertPhone();
            }
        }

        protected void InitDropDown()
        {
            Phone p = new Phone();
            DataTable dt = new DataTable();
            dt = p.GetPhoneTypes();        
            DDLPhoneType.Items.Insert(0, "-Choose One-");

            foreach (DataRow rw in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Value = rw["ID"].ToString();
                li.Text = rw["PHONE_TYPE"].ToString();
                DDLPhoneType.Items.Add(li);
                ddlPhoneTypeEdit.Items.Add(li);
                li = null;
            }
        }
        
        protected bool IsDate(string strDate)
        {
            bool RetValue = false;
            try
            {
                Convert.ToDateTime(strDate);
                RetValue = true;
            }
            catch
            {
                RetValue = false;
            }

            return RetValue;
        }
    
            
        
        protected void LoadData(int iContactID) {
            Contact c = new Contact();
            c.ID = iContactID;
            DataTable dt = new DataTable();
            dt = c.GetContact_BYId();
            {

                
            }
            string sp_id = Request.QueryString["p_id"].ToString();
            int ip_id =Convert.ToInt32(sp_id);
            DataTable dt2 = new DataTable();
            Phone p = new Phone();
            p.ID = ip_id;
            dt2 = p.GetPhoneByPhoneId();
            if (dt2.Rows.Count > 0)
            {
                txtPhoneUpdate.Text = dt2.Rows[0]["PHONE_NUMBER"].ToString();               
                if (dt2.Rows[0]["PHONE_TYPE_ID"] != null) {
                    

                    ddlPhoneTypeEdit.SelectedValue = dt2.Rows[0]["PHONE_TYPE_ID"].ToString();
                }

            
            }
        }
        
        protected void btnUpdate_Phone(object sender, ImageClickEventArgs e)
        {
            Phone p = new Phone();
            int iContactID = 0;
            int iUserID = 0;
            bool bValid = true;
            if (ViewState["UserID"] != null) {
                iUserID = Convert.ToInt32(ViewState["UserID"].ToString());
            }
            if (ViewState["ContactID"] != null) {
                iContactID = Convert.ToInt32(ViewState["ContactID"].ToString());
            }
            p.ID =iContactID;
            p.PhoneNumber = txtPhoneUpdate.Text;           
            p.PhoneTypeId = Convert.ToInt32(ddlPhoneTypeEdit.SelectedValue);
            p.User_ID = iUserID;

            if (bValid)
            {
                p.UpdatePhone();
            }

        }
        
        //ADDRESS


        protected void btnAdd_Address(object sender, ImageClickEventArgs e)
        {
            Address a = new Address();
            int iAddressID = 0;
            bool bValid = true;

            lblErrMsg.Text = string.Empty;
            a.ContactId = Convert.ToInt32(ViewState["contact_id"].ToString());
            a.Address_1 = txtAddress_1.Text.ToString();
            a.Address_2 = txtAddress_2.Text.ToString();
            a.StateId = Convert.ToInt32(DDLState.SelectedValue);
            a.AddressTypeId = Convert.ToInt32(DDLAddressType.SelectedValue);
            a.City = txtCity.Text.ToString();
            a.sZip = txtZip.Text.ToString();
            a.User_ID = Convert.ToInt32(ViewState["user_id"].ToString());


            if (bValid)
            {
                iAddressID = a.InsertAddress();
            }
        }

        protected void InitDropDownAddress()
        {
            Address a = new Address();
            DataTable dt = new DataTable();
            dt = a.GetAddressType();
            DDLAddressType.Items.Insert(0, "-Choose One-");

            foreach (DataRow rw in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Value = rw["ID"].ToString();
                li.Text = rw["ADDRESS_TYPE"].ToString();
                DDLAddressType.Items.Add(li);
                ddlAddressTypeEdit.Items.Add(li);
                li = null;
            }
        }

        protected void InitDropDownState()
        {
            Address a = new Address();
            DataTable dt = new DataTable();
            dt = a.GetAddressType();
            DDLAddressType.Items.Insert(0, "-Choose One-");

            foreach (DataRow rw in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Value = rw["ID"].ToString();
                li.Text = rw["ADDRESS_TYPE"].ToString();
                DDLAddressType.Items.Add(li);
                ddlAddressTypeEdit.Items.Add(li);
                li = null;
            }
        }

        protected bool IsDateAddress(string strDate)
        {
            bool RetValue = false;
            try
            {
                Convert.ToDateTime(strDate);
                RetValue = true;
            }
            catch
            {
                RetValue = false;
            }

            return RetValue;
        }
        
        protected void LoadDataAddress(int iContactID) {
            Contact c = new Contact();
            c.ID = iContactID;
            DataTable dt = new DataTable();
            dt = c.GetContact_BYId();
            {               
            }
            string sp_id = Request.QueryString["p_id"].ToString();
            int ip_id = Convert.ToInt32(sp_id);
            DataTable dt4 = new DataTable();
            Address a = new Address();
            a.ID = ip_id;
            dt4 = a.GetAddressByAddressId();
            if (dt4.Rows.Count > 0)
            {
                txtAddress1Update.Text = dt4.Rows[0]["ADDRESS_1"].ToString();
                if (dt4.Rows[0]["ADDRESS_TYPE_ID"] != null)


                {

                    ddlAddressTypeEdit.SelectedValue = dt4.Rows[0]["ADDRESS_TYPE_ID"].ToString();
                }

            
            }
        }

        protected void btnUpdate_Address(object sender, ImageClickEventArgs e)
        {
            Address a = new Address();
            int iContactID = 0;
            int iUserID = 0;
            bool bValid = true;
            if (ViewState["UserID"] != null)
            {
                iUserID = Convert.ToInt32(ViewState["UserID"].ToString());
            }
            if (ViewState["ContactID"] != null)
            {
                iContactID = Convert.ToInt32(ViewState["ContactID"].ToString());
            }
            a.ID = iContactID;
            a.Address_1 = txtAddress_1.Text.ToString();
            a.Address_2 = txtAddress_2.Text.ToString();
            a.City = txtCity.Text.ToString();
            a.sZip = txtZip.Text.ToString();
            a.StateId = Convert.ToInt32(DDLState.SelectedValue);
            a.AddressTypeId = Convert.ToInt32(DDLAddressType.SelectedValue); 
            a.User_ID = iUserID;

            if (bValid)
            {
                a.UpdateAddress();
            }

        }


        // EMAILS


        //protected void btnAdd_Email(object sender, ImageClickEventArgs e)
        //{
        //    Email em = new Email();
        //    int iEmailID = 0;
        //    bool bValid = true;

        //    lblErrMsg.Text = string.Empty;
        //    em.ContactId = Convert.ToInt32(ViewState["contact_id"].ToString());
        //    em.EmailAddress = txtEmailAddress.Text.ToString();
        //    em.EmailTypeId = Convert.ToInt32(DDLEmailType.SelectedValue);
        //    em.User_ID = Convert.ToInt32(ViewState["user_id"].ToString());


        //    if (bValid)
        //    {
        //        iEmailID = em.InsertEmails();
        //    }
        //}

        //protected void InitDropDownEmail()
        //{
        //    Email em = new Email();
        //    DataTable dt = new DataTable();
        //    dt = em.GetEmailTypes();
        //    DDLEmailType.Items.Insert(0, "-Choose One-");

        //    foreach (DataRow rw in dt.Rows)
        //    {
        //        ListItem li = new ListItem();
        //        li.Value = rw["ID"].ToString();
        //        li.Text = rw["EMAIL_TYPE"].ToString();
        //        DDLEmailType.Items.Add(li);
        //        ddlEMailTypeEdit.Items.Add(li);
        //        li = null;
        //    }
        //}

        //protected bool IsDateEmail(string strDate)
        //{
        //    bool RetValue = false;
        //    try
        //    {
        //        Convert.ToDateTime(strDate);
        //        RetValue = true;
        //    }
        //    catch
        //    {
        //        RetValue = false;
        //    }

        //    return RetValue;
        //}



        //protected void LoadDataEmail(int iContactID)
        //{
        //    Contact c = new Contact();
        //    c.ID = iContactID;
        //    DataTable dt = new DataTable();
        //    dt = c.GetContact_BYId();
        //    {


        //    }
        //    string sp_id = Request.QueryString["p_id"].ToString();
        //    int ip_id = Convert.ToInt32(sp_id);
        //    DataTable dt2 = new DataTable();
        //    Email em = new Email();
        //    em.ID = ip_id;
        //    dt2 = em.GetEmailsByEmailsId();
        //    if (dt2.Rows.Count > 0)
        //    {
        //        txtEmailUpdate.Text = dt2.Rows[0]["PHONE_NUMBER"].ToString();
        //        if (dt2.Rows[0]["PHONE_TYPE_ID"] != null)
        //        {
                        
        //            ddlPhoneTypeEdit.SelectedValue = dt2.Rows[0]["PHONE_TYPE_ID"].ToString();
        //        }

        
        //    }
        //}

        //protected void btnUpdate_Phone(object sender, ImageClickEventArgs e)
        //{
        //    Phone p = new Phone();
        //    int iContactID = 0;
        //    int iUserID = 0;
        //    bool bValid = true;
        //    if (ViewState["UserID"] != null)
        //    {
        //        iUserID = Convert.ToInt32(ViewState["UserID"].ToString());
        //    }
        //    if (ViewState["ContactID"] != null)
        //    {
        //        iContactID = Convert.ToInt32(ViewState["ContactID"].ToString());
        //    }
        //    p.ID = iContactID;
        //    p.PhoneNumber = txtPhoneUpdate.Text;
        //    p.PhoneTypeId = Convert.ToInt32(ddlPhoneTypeEdit.SelectedValue);
        //    p.User_ID = iUserID;

        //    if (bValid)
        //    {
        //        p.UpdatePhone();
        //    }

        //}

















    }

}