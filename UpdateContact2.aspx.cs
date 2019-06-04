using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhoneBook2.Classes;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook2
{
    public partial class UpdateContact2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitDropDown();
                string sContactID = string.Empty;
                int iContactID = 0;
                string sUserID = string.Empty;
                if (Request.QueryString["user_id"] != null)
                {
                    sUserID = Request.QueryString["user_id"].ToString();

                    ViewState["user_id"] = sUserID;

                }
              
                if (Request.QueryString["contact_id"] != null)
                {
                    sContactID = Request.QueryString["contact_id"].ToString();
                    iContactID = Convert.ToInt32(sContactID);
                    ViewState["contact_id"] = sContactID;
                    LoadData(iContactID);
                    BindPhone();
                    BindEmails();
                    BindAddress();
                }
                
            }
            
        }
        protected void LoadData(int iContactID) {
            Contact c = new Contact();
            c.ID = iContactID;
            DataTable dt = new DataTable();
            dt = c.GetContact_BYId();
            if (dt.Rows.Count > 0)
            {
                txtFirstName.Text = dt.Rows[0]["FIRST_NM"].ToString();
                txtLastName.Text = dt.Rows[0]["LAST_NM"].ToString();
                txtDateofBirth.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToShortDateString() ;
                if (dt.Rows[0]["PERSON_TYPE_ID"] != null) {

                    DDLPersonType.SelectedValue = dt.Rows[0]["PERSON_TYPE_ID"].ToString();
                }

            
            }
        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            Contact c = new Contact();
            int iContactID = 0;
            int iUserID = 0;
            bool bValid = true;
            if (ViewState["UserID"] != null) {
                iUserID = Convert.ToInt32(ViewState["UserID"].ToString());
            }
            if (ViewState["ContactID"] != null) {
                iContactID = Convert.ToInt32(ViewState["ContactID"].ToString());
            }
            c.ID =iContactID;
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.DOB = Convert.ToDateTime (txtDateofBirth.Text);
            c.PersonTypeId = Convert.ToInt32(DDLPersonType.SelectedValue);
            c.USER_ID = iUserID;
           // c.UpdateContact();

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

            if (bValid)
            {
                c.UpdateContact();
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

       // PHONES

        protected void BindPhone()
        {
            DataTable dt = new DataTable();
            Phone p = new Phone();
            p.ContactId = Convert.ToInt32(ViewState["contact_id"]);
            dt = p.GetPhones();

            grvPhone.DataSource = dt;           
            grvPhone.DataBind();

        }

        protected void LoadPhoneGrid(int iContactID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("PHONE_NUMBER");
            for (int i = 0; i < 10; i++)               
                dt.Columns.Add("PHONE_TYPE");
            for (int i = 0; i < 10; i++)                
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = i + 1;
                dr["PHONE_NUMBER"] = "" + (i + 1);
                dr["PHONE_TYPE"] = "" + (i + 1);               
                dt.Rows.Add(dr);
            }
            grvPhone.DataSource = dt;
            grvPhone.DataBind();
        }

        protected string ConvertSortDirectionToSql(string sortExpression, SortDirection sortDirection)
        {
            string newSortDirection = "ASC";
            string currentSortDirection = ViewState["GridViewSortDirection"].ToString();
            string currentSortExpression = ViewState["GridViewSortExpression"].ToString();

            if (sortExpression.Equals(currentSortExpression))
            {
                switch (currentSortDirection)
                {
                    case "ASC":
                        newSortDirection = "DESC";
                        ViewState["GridViewSortDirection"] = "DESC";
                        break;

                    case "DESC":
                        newSortDirection = "ASC";
                        ViewState["GridViewSortDirection"] = "ASC";
                        break;
                }
            }
            else
            {
                ViewState["GridViewSortDirection"] = newSortDirection;
            }

            ViewState["GridViewSortExpression"] = sortExpression;
            return newSortDirection;
        }

        protected void grvPhone_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                BindPhone();
                DataTable dt = this.grvPhone.DataSource as DataTable;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortExpression, e.SortDirection);
                    this.grvPhone.DataSource = dv;
                    this.grvPhone.DataBind();
                }
            }
            catch
            {
                throw;
            }
        }

        protected void grvPhone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPhone.PageIndex = e.NewPageIndex;

            BindPhone();


        }

        protected void btnAdd_Phone(object sender, ImageClickEventArgs e)
        {
            string sUser_id = string.Empty;
            if (Request.QueryString["user_id"] != null)
            {
                sUser_id = Request.QueryString["user_id"].ToString();
            }
            Response.Redirect("AddPhone.aspx?user_id=" + sUser_id);
        }

        protected void grvPhone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                
                string sphone_id = rowView["ID"].ToString();
                string scontact_id = string.Empty;
                string suser_id = string.Empty;

                TableCellCollection grdCells = e.Row.Cells;

                HyperLink link = (HyperLink)grdCells[0].Controls[0];
                if (ViewState["contact_id"] != null)
                {
                    scontact_id = ViewState["contact_id"].ToString();
                }
                if (ViewState["user_id"] != null)
                {
                    suser_id = ViewState["user_id"].ToString();
                }
                link.NavigateUrl = "AddPhone.aspx?contact_id=" + scontact_id + "&user_id=" + suser_id +"&p_id="+ sphone_id;


            }
        }
        protected bool IsNumeric(string sValue)
        {
            bool bResult = false;
            try
            {
                Convert.ToInt32(sValue);
                bResult = true;
            }
            catch (Exception)
            {
                bResult = false;
            }
            return bResult;
        }

        protected bool PhoneDate(string strDate)
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

        protected void grvPhone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sID = e.CommandArgument.ToString();
            int iID = 0;
            if (!sID.Equals(string.Empty))
            {
                if (IsNumeric(sID))
                {
                    iID = Convert.ToInt32(sID);
                }
            }

            if (e.CommandName.Equals("Delete"))
            {
                try
                {
                    Phone p = new Phone();
                    p.ID = iID;
                    p.DeletePhone();
                    BindPhone();
                }
                catch
                {
                    //lblMessage.Text = "Error: unable to delete the selected record.";
                    //lblMessage.Visible = true;
                }

            }            

        }

        protected void grvPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
                 
        // ADDRESS

        protected void BindAddress()
        {
            DataTable dt = new DataTable();
            Address a = new Address();
            a.ContactId = Convert.ToInt32(ViewState["contact_id"]);
            dt = a.GetAddress();

            grvAddress.DataSource = dt;
            grvAddress.DataBind();

        }

        protected void LoadAddressGrid(int iContactID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("ADDRESS_1");
            for (int i = 0; i < 10; i++)
                dt.Columns.Add("ADDRESS_2");
            for (int i = 0; i < 10; i++)
                dt.Columns.Add("CITY");
            for (int i = 0; i < 10; i++)
            dt.Columns.Add("ZIP");
            for (int i = 0; i < 10; i++)
            dt.Columns.Add("STATE");
            for (int i = 0; i < 10; i++)
            dt.Columns.Add("ADDRESS_TYPE");
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = i + 1;
                dr["ADDRESS_1"] = "" + (i + 1);
                dr["ADDRESS_2"] = "" + (i + 1);
                dr["CITY"] = "" + (i + 1);
                dr["ZIP"] = "" + (i + 1);
                dr["STATE"] = "" + (i + 1);
                dr["ADDRESS_TYPE"] = "" + (i + 1);
                dt.Rows.Add(dr);
            }
            grvAddress.DataSource = dt;
            grvAddress.DataBind();
        }
      
        protected string ConvertSortDirectionToSqlAddress(string sortExpression, SortDirection sortDirection)
        {
            string newSortDirection = "ASC";
            string currentSortDirection = ViewState["GridViewSortDirection"].ToString();
            string currentSortExpression = ViewState["GridViewSortExpression"].ToString();

            if (sortExpression.Equals(currentSortExpression))
            {
                switch (currentSortDirection)
                {
                    case "ASC":
                        newSortDirection = "DESC";
                        ViewState["GridViewSortDirection"] = "DESC";
                        break;

                    case "DESC":
                        newSortDirection = "ASC";
                        ViewState["GridViewSortDirection"] = "ASC";
                        break;
                }
            }           
            else
            {
                ViewState["GridViewSortDirection"] = newSortDirection;
            }

            ViewState["GridViewSortExpression"] = sortExpression;
            return newSortDirection;
        }


        protected void grvAddress_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                BindAddress();
                DataTable dt = this.grvAddress.DataSource as DataTable;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.Sort = e.SortExpression + " " + ConvertSortDirectionToSqlAddress(e.SortExpression, e.SortDirection);
                    this.grvAddress.DataSource = dv;
                    this.grvAddress.DataBind();
                }
            }
            catch
            {
                throw;
            }
        }

      protected void grvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
      {
          grvAddress.PageIndex = e.NewPageIndex;

            BindAddress();
      }

      protected void btnAdd_Address(object sender, ImageClickEventArgs e)
      {
          string sUser_id = string.Empty;
          if (Request.QueryString["user_id"] != null)
          {
              sUser_id = Request.QueryString["user_id"].ToString();
          }
          Response.Redirect("AddPhone.aspx?user_id=" + sUser_id);
      }

      protected void grvAddress_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              DataRowView rowView = (DataRowView)e.Row.DataItem;

              string saddress_id = rowView["ID"].ToString();
              string scontact_id = string.Empty;
              string suser_id = string.Empty;
              
              TableCellCollection grdCells = e.Row.Cells;

              HyperLink link = (HyperLink)grdCells[0].Controls[0];
              if (ViewState["contact_id"] != null)
              {
                  scontact_id = ViewState["contact_id"].ToString();
              }
              if (ViewState["user_id"] != null)
              {
                  suser_id = ViewState["user_id"].ToString();
              }
              link.NavigateUrl = "AddPhone.aspx?contact_id=" + scontact_id + "&user_id=" + suser_id + "&p_id=" + saddress_id;


              
          }
      }

      protected bool IsNumer(string sValue)
      {
          bool bResult = false;
          try
          {
              Convert.ToInt32(sValue);
              bResult = true;
          }
          catch (Exception)
          {
              bResult = false;
          }
          return bResult;
      }

        
      protected bool AddressDate(string strDate)
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

      protected void grvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
      {
          string sID = e.CommandArgument.ToString();
          int iID = 0;
          if (!sID.Equals(string.Empty))
          {
              if (IsNumeric(sID))
              {
                  iID = Convert.ToInt32(sID);
              }
          }

          if (e.CommandName.Equals("Delete"))
          {
              try
              {
                  Address a = new Address();
                  a.ID = iID;
                  a.DeleteAddress();
                  BindAddress();
              }
              catch
              {
                  //lblMessage.Text = "Error: unable to delete the selected record.";
                  //lblMessage.Visible = true;
              }

          }

      }

      protected void grvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {

      }

        ///////EMAILS

      protected void BindEmails()
      {
          DataTable dt = new DataTable();
          Email em = new Email();
          em.ContactId = Convert.ToInt32(ViewState["contact_id"]);
          dt = em.GetEmails();

          grvEmails.DataSource = dt;
          grvEmails.DataBind();

      }

      protected void LoadEmailsGrid(int iContactID)
      {
          DataTable dt = new DataTable();
          dt.Columns.Add("Id");
          dt.Columns.Add("EMAIL_ADDRESS");
          for (int i = 0; i < 10; i++)
              dt.Columns.Add("EMAIL_TYPE");
          for (int i = 0; i < 10; i++)
          {
              DataRow dr = dt.NewRow();
              dr["Id"] = i + 1;
              dr["EMAIL_ADDRESS"] = "" + (i + 1);
              dr["EMAIL_TYPE"] = "" + (i + 1);
              dt.Rows.Add(dr);
          }
          grvEmails.DataSource = dt;
          grvEmails.DataBind();
      }

      protected string ConvertSortDirectionToSqlEmail(string sortExpression, SortDirection sortDirection)
      {
          string newSortDirection = "ASC";
          string currentSortDirection = ViewState["GridViewSortDirection"].ToString();
          string currentSortExpression = ViewState["GridViewSortExpression"].ToString();
          
          if (sortExpression.Equals(currentSortExpression))
          {
              switch (currentSortDirection)
              {
                  case "ASC":
                      newSortDirection = "DESC";
                      ViewState["GridViewSortDirection"] = "DESC";
                      break;

                  case "DESC":
                      newSortDirection = "ASC";
                      ViewState["GridViewSortDirection"] = "ASC";
                      break;
              }
          }
          else
          {
              ViewState["GridViewSortDirection"] = newSortDirection;
          }

          ViewState["GridViewSortExpression"] = sortExpression;
          return newSortDirection;
      }

      protected void grvEmails_Sorting(object sender, GridViewSortEventArgs e)
      {
          try
          {
              BindEmails();
              DataTable dt = this.grvEmails.DataSource as DataTable;
              if (dt != null)
              {
                  DataView dv = new DataView(dt);
                  dv.Sort = e.SortExpression + " " + ConvertSortDirectionToSqlEmail(e.SortExpression, e.SortDirection);
                  this.grvEmails.DataSource = dv;
                  this.grvEmails.DataBind();
              }
          }
          catch
          {
              throw;
          }
      }

      protected void grvEmails_PageIndexChanging(object sender, GridViewPageEventArgs e)
      {
          grvEmails.PageIndex = e.NewPageIndex;

          BindEmails();
          
      }

      protected void btnAdd_Emails(object sender, ImageClickEventArgs e)
      {
          string sUser_id = string.Empty;
          if (Request.QueryString["user_id"] != null)
          {
              sUser_id = Request.QueryString["user_id"].ToString();
          }
          Response.Redirect("AddPhone.aspx?user_id=" + sUser_id);
      }

      protected void grvEmails_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              DataRowView rowView = (DataRowView)e.Row.DataItem;

              string semail_id = rowView["ID"].ToString();
              string scontact_id = string.Empty;
              string suser_id = string.Empty;

              TableCellCollection grdCells = e.Row.Cells;

              HyperLink link = (HyperLink)grdCells[0].Controls[0];
              if (ViewState["contact_id"] != null)
              {
                  scontact_id = ViewState["contact_id"].ToString();
              }
              if (ViewState["user_id"] != null)
              {
                  suser_id = ViewState["user_id"].ToString();
              }
              link.NavigateUrl = "AddPhone.aspx?contact_id=" + scontact_id + "&user_id=" + suser_id + "&p_id=" + semail_id;


          }
      }
      protected bool IsNumerical(string sValue)
      {
          bool bResult = false;
          try
          {
              Convert.ToInt32(sValue);
              bResult = true;
          }
          catch (Exception)
          {
              bResult = false;
          }
          return bResult;
      }

      protected bool EmailDate(string strDate)
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

      protected void grvEmails_RowCommand(object sender, GridViewCommandEventArgs e)
      {
          string sID = e.CommandArgument.ToString();
          int iID = 0;
          if (!sID.Equals(string.Empty))
          {
              if (IsNumerical(sID))
              {
                  iID = Convert.ToInt32(sID);
              }
          }
          
          if (e.CommandName.Equals("Delete"))
          {
              try
              {
                  Email em = new Email();
                  em.ID = iID;
                  em.DeleteEmails();
                  BindEmails();
              }
              catch
              {
                  //lblMessage.Text = "Error: unable to delete the selected record.";
                  //lblMessage.Visible = true;
              }

          }

      }

      protected void grvEmails_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {

      }
                 


    }
}