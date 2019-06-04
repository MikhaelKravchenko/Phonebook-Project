using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace PhoneBook2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu mnu = (Menu)Page.Master.FindControl("Menu1");
            mnu.Visible = false;
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
          //  txtUserName.Text
            string sLogin = string.Empty;
            string sPswd = string.Empty;
            sLogin = txtUserName.Text;
            sPswd = txtPassword.Text;
            string sConString = string.Empty;

         //   sConString = @"Data Source=sqldevf\sqldevf; initial catalog=FNETIntern01; user id=FNETUser; password=fnetdev;";
            SQLConnections sqlcnn = new SQLConnections();
            sConString = sqlcnn.GetSqlConnectionString();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(sConString)) {
                using (SqlCommand cm = new SqlCommand("USP_PB_GET_USER", cn)) {
                    cn.Open();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("@LOGIN", SqlDbType.NVarChar, 25).Value = sLogin;
                    cm.Parameters.Add("@PSWD", SqlDbType.NVarChar, 25).Value = sPswd;
                    using (SqlDataAdapter da = new SqlDataAdapter(cm)) {
                        da.SelectCommand = cm;
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string sUserId = string.Empty;
                            sUserId = dt.Rows[0]["ID"].ToString();
                           string sRole = dt.Rows[0]["ROLES"].ToString();
                            Session["UserName"] = dt.Rows[0]["USER_FN"].ToString();
                            Response.Redirect("search.aspx?user_id=" + sUserId +"&role=" + sRole );
                        }
                        else {
                            lblErrMsg.Visible = true;
                            lblErrMsg.Text = "Invalid User Name or Password.";

                        }
                    }

                }
            }

        }
    }
}

