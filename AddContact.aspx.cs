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
    public partial class AddContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user_id"] != null)
            {
                lbluserid.Text = Request.QueryString["user_id"].ToString();
                ViewState["user_id"] = Request.QueryString["user_id"].ToString();
            }


            // c.GetContact_BYId();
            if (!Page.IsPostBack)
            {
                InitDropDown();
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Contact c = new Contact();
            int iContactID = 0;
            bool bValid = true;

            lblErrMsg.Text = string.Empty;
            c.FirstName = txtFirstName.Text.ToString();
            c.LastName = txtLastName.Text.ToString();
            if (!txtDateofBirth.Text.Trim().Equals(string.Empty))
            {
                if (IsDate(txtDateofBirth.Text.Trim()))
                {
                    c.DOB = Convert.ToDateTime(txtDateofBirth.Text.ToString());
                }
                else
                {
                    lblErrMsg.Text = "Invalid Date";
                    bValid = false;
                }
            }
            c.PersonTypeId = Convert.ToInt32(DDLPersonType.SelectedValue);
            c.USER_ID = Convert.ToInt32(ViewState["user_id"].ToString());

            if (bValid)
            {
                iContactID = c.InsertContact();
            }
        }

        protected void InitDropDown()
        {
            DataTable dt = new DataTable();
            dt = PB_Database.GetContactType();
            //DDLPersonType.DataValueField = "ID";
            //DDLPersonType.DataTextField = "PERSON_TYPE";
            //DDLPersonType.DataSource = dt;
            //DDLPersonType.DataBind();
            DDLPersonType.Items.Insert(0, "-Choose One-");

            foreach (DataRow rw in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Value = rw["ID"].ToString();
                li.Text = rw["PERSON_TYPE"].ToString();
                DDLPersonType.Items.Add(li);
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


    }
}
