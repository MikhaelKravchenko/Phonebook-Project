using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PhoneBook2.Classes;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook2
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string susrid = string.Empty;
            if (!Page.IsPostBack)
            {
                InitDropDown();
                ViewState["GridViewSortDirection"] = "ASC";
                ViewState["GridViewSortExpression"] = "";

            }
            if (Request.QueryString["user_id"] != null)
            {
                susrid = Request.QueryString["user_id"].ToString();
                ViewState["user_id"] = susrid;

                //Contact c = new Contact();
                //c.FirstName = "";
                //c.LastName = "";
                //c.DOB = DateTime.Now;
                //int iContactID = 0;
                //c.PersonTypeId = 1;
                //iContactID = c.InsertContact();
                //c.ID = 2;
                //c.GetContact_BYId();

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

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string sErrorMsg = string.Empty;
            bool bValid = true;
            lblErrorMsg.Visible = false;
            if (!txtDateofBirth.Text.ToString().Equals(string.Empty)) 
            {

            if (!IsDate(txtDateofBirth.Text.ToString())) 
            {
              sErrorMsg += "Invalid DOB";
              bValid=false;
              }
            }    

            if (bValid)
            {
            BindGrid();
            } 
                else
                {

                lblErrorMsg.Visible=true;
                lblErrorMsg.Text=sErrorMsg;
                }
             
        }



        protected void BindGrid()
        {
            DataTable dt = new DataTable();
            Contact c = new Contact();
            c.FirstName = txtFirstName.Text.Trim();
            c.LastName = txtLastName.Text.Trim();
            if (IsDate(txtDateofBirth.Text.ToString()))//validation for date of birth through IsDate
            {
             c.DOB = Convert.ToDateTime(txtDateofBirth.Text.ToString());
            }          
            if (DDLPersonType.SelectedIndex > 0)
            {
                c.PersonTypeId = Convert.ToInt32(DDLPersonType.SelectedItem.Value.ToString());

            }
            dt = c.GetContacts();
            grvSearch.DataSource = dt;
            grvSearch.DataBind();
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

        protected void grvSearch_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                BindGrid();
                DataTable dt = this.grvSearch.DataSource as DataTable;
                if (dt != null)
                {
                    DataView dv = new DataView(dt);
                    dv.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortExpression, e.SortDirection);
                    this.grvSearch.DataSource = dv;
                    this.grvSearch.DataBind();
                }
            }
            catch
            {
                throw;
            }
        }

        protected void grvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSearch.PageIndex = e.NewPageIndex;

            BindGrid();


        }




        /// ////////////////////////////////////////////



        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //        LoadGridData();
        //}
        private void LoadGridData()
        {
            //Adding data to table.
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("FIRST_NM");
            for (int i = 0; i < 10; i++)
                dt.Columns.Add("LAST_NM");
            for (int i = 0; i < 10; i++)
                dt.Columns.Add("DOB");
            for (int i = 0; i < 10; i++)
                dt.Columns.Add("PERSON_TYPE");
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = i + 1;
                dr["FIRST_NM"] = "" + (i + 1);
                dr["LAST_NM"] = "" + (i + 1);
                dr["DOB"] = "" + (i + 1);
                dr["PERSON_TYPE"] = "" + (i + 1);
                dt.Rows.Add(dr);
            }
            grvSearch.DataSource = dt;
            grvSearch.DataBind();
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            string sUser_id = string.Empty;
            if (Request.QueryString["user_id"] != null)
            {
                sUser_id = Request.QueryString["user_id"].ToString();
            }
            Response.Redirect("AddContact.aspx?user_id=" + sUser_id);
        }

        protected void grvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                string scontact_id = rowView["ID"].ToString();
                string suser_id = string.Empty;

                TableCellCollection grdCells = e.Row.Cells;

                HyperLink link = (HyperLink)grdCells[0].Controls[0];
                if (ViewState["user_id"] != null)
                {
                    suser_id = ViewState["user_id"].ToString();
                }
                link.NavigateUrl = "UpdateContact2.aspx?contact_id=" + scontact_id + "&user_id=" + suser_id;
              // link.
                ////SSN


                //HttpUtility.UrlEncode(link.NavigateUrl);
            }

        }

        protected void grvSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //if (e.CommandName == "delete_click")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = grvSearch.Rows[index];
            //    try
            //    {
            //        int idIndex = GetColumnIndexByName(grvSearch, "Contact ID");
            //        int contactId = Convert.ToInt32(row.Cells[idIndex].Text);
            //        Contact c = new Contact();
            //        c.ID = contactId;
            //        string user = ViewState["UserId"].ToString();
            //        c.DeleteContact(user);
            //        BindGrid();
            //    }


            //}
    


        }






        public partial class DateTime_EditField : System.Web.DynamicData.FieldTemplateUserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }

            protected void MyValidator_ServerValidate(object source, ServerValidateEventArgs args)
            {







            }
        }

        protected void grvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    Contact c = new Contact();
                    c.ID = iID;
                    c.DeleteContact();
                    BindGrid();
                }
                catch
                {
                    //lblMessage.Text = "Error: unable to delete the selected record.";
                    //lblMessage.Visible = true;
                }

            }


        }

        protected bool IsNumeric(string sValue) {
            bool bResult = false;
            try {
                Convert.ToInt32(sValue);
                bResult = true;
            }catch(Exception){
                bResult=false ;
            }
            return bResult;
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

        
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand delCmd = new SqlCommand("Delete_Contact"))
            //    {
            //        con.Open();
            //        delCmd = new SqlCommand("USP_PB_DELETE_PB_CONTACT", con);
            //        delCmd.CommandType = CommandType.StoredProcedure;

                     
                    
                    //delCmd.CommandType = CommandType.StoredProcedure;
                    //delCmd.Parameters.AddWithValue("@Action", "DELETE");
                    //delCmd.Parameters.AddWithValue("@ContactId", contactId);
                    //delCmd.Connection = con;
                    //delCmd.ExecuteNonQuery();
                   
               
                    //con.Close();

                }

              //  this.BindGrid();

            }

    



























//void grdView_RowDataBound(object sender, GridViewRowEventArgs e){
//        if(e.Row.RowType == DataControlRowType.DataRow) {
//            DataRowView rowView = (DataRowView)e.Row.DataItem;
//            string sPerson_Id = rowView["ID"].ToString();
//            string sFirstName = rowView["FIRST_NM"].ToString();
//            string sLastName = rowView["LAST_NM"].ToString();
//            string sDOB = rowView["DOB"].ToString();
//            string sPersonType = rowView["PERSON_TYPE_ID"].ToString();
//            sFileId = FNET.Resources.QueryString.EncryptUrlEnQueryString(sFileId);
//            sCin = FNET.Resources.QueryString.EncryptUrlEnQueryString(sCin);


//            TableCellCollection grdCells = e.Row.Cells;
//            HyperLink link = (HyperLink)grdCells[0].Controls[0];
//            link.NavigateUrl = "Details.aspx?contact_id=" + scontact_id;

//FNET.Resources.QueryString.EncryptUrlEnQueryString(sFileId);
//                sCin = FNET.Resources.QueryString.EncryptUrlEnQueryString(sCin);
//                string sSSN = rowView["SSN"].ToString();
//            try {
//                   sSSN = FNET.Resources.Encrypt.DecryptString(sSSN, FNET.Resources.EncryptContext.EncryptKeyFNET);
//            } catch (Exception) { }
//            grdCells[11].Text = sSSN;
//            if (grdCells[17].Text.Equals("Rejected")) {
//                grdCells[16].ForeColor = System.Drawing.Color.Red;
//            }
//    }
//}