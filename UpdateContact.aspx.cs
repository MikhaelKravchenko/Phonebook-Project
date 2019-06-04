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
    public partial class UpdateContact : System.Web.UI.Page
    {


        private void LoadGridData()
        {

            DataTable dt = new DataTable();
            //dt.Columns.Add("Id");
            //dt.Columns.Add("FIRST_NM");
            //for (int i = 0; i < 10; i++)
            //    dt.Columns.Add("LAST_NM");
            //for (int i = 0; i < 10; i++)
            //    dt.Columns.Add("DOB");
            //for (int i = 0; i < 10; i++)
            //    dt.Columns.Add("PERSON_TYPE");
            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Id"] = i + 1;
            //    dr["FIRST_NM"] = "" + (i + 1);
            //    dr["LAST_NM"] = "" + (i + 1);
            //    dr["DOB"] = "" + (i + 1);
            //    dr["PERSON_TYPE"] = "" + (i + 1);
            //    dt.Rows.Add(dr);
            //}
            ////grvSearch.DataSource = dt;
            //grvSearch.DataBind();
        }

        //protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        //{
        //    string sUser_id = string.Empty;
        //    if (Request.QueryString["user_id"] != null)
        //    {
        //        sUser_id = Request.QueryString["user_id"].ToString();
        //    }
        //    Response.Redirect("AddContact.aspx?user_id=" + sUser_id);
        //}

        //protected void grvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}











        //    public partial class UpdateContact : System.Web.UI.Page
        //    {
        //        protected void Page_Load(object sender, EventArgs e)
        //        {
        //            if (Request.QueryString["user_id"] != null)
        //            {
        //                lbluserid.Text = Request.QueryString["user_id"].ToString();
        //                ViewState["user_id"]= Request.QueryString["user_id"].ToString();
        //            }


        //           // c.GetContact_BYId();
        //            if (!Page.IsPostBack) {
        //                InitDropDown();

        //                gvbind();

        //            }

        //        }




        //        protected void UpdateContact(object sender, ImageClickEventArgs e)
        //        {
        //            UpdateContact c = new UpdateContact();
        //            int iContactID = 0;
        //            bool bValid = true;

        //            lblErrMsg.Text = string.Empty;
        //            c.FirstName =txtFirstName.Text.ToString();
        //            c.LastName =txtLastName.Text.ToString();
        //            if (!txtDateofBirth.Text.Trim().Equals(string.Empty))
        //            {
        //                if (IsDate(txtDateofBirth.Text.Trim()))
        //                {
        //                    c.DOB = Convert.ToDateTime(txtDateofBirth.Text.ToString());
        //                }
        //                else {
        //                    lblErrMsg.Text = "Invalid Date";
        //                    bValid = false;
        //                }
        //            }
        //            c.PersonTypeId = Convert.ToInt32 ( DDLPersonType.SelectedValue);
        //            c.USER_ID = Convert.ToInt32(ViewState["user_id"].ToString());

        //            if (bValid)
        //            {
        //                iContactID = c.InsertContact();
        //            }
        //        }

        //        protected void InitDropDown() {
        //            DataTable dt = new DataTable();
        //            dt = PB_Database.GetContactType();
        //            //DDLPersonType.DataValueField = "ID";
        //            //DDLPersonType.DataTextField = "PERSON_TYPE";
        //            //DDLPersonType.DataSource = dt;
        //            //DDLPersonType.DataBind();
        //            DDLPersonType.Items.Insert(0, "-Choose One-");

        //            foreach (DataRow rw in dt.Rows)
        //            {
        //                ListItem li = new ListItem();
        //                li.Value = rw["ID"].ToString();
        //                li.Text = rw["PERSON_TYPE"].ToString();
        //                DDLPersonType.Items.Add(li);
        //                li = null;
        //            }
        //        }

        //        protected bool IsDate( string strDate ) {
        //            bool RetValue = false;
        //            try
        //            {
        //                Convert.ToDateTime(strDate);
        //                RetValue = true;
        //            }
        //            catch {
        //                RetValue = false;
        //            }

        //            return RetValue;
        //        }

        //        protected GridViewDeleteEventArgs

        //    }
        //}

    }
}