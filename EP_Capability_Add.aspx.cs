using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Web.Services;
using System.Drawing;
using System.IO;
using System.Reflection;


public partial class EP_Capability_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Panel_CAP_table.Visible = false;
            DBint();
            
        }
    }
    [System.Web.Services.WebMethod]
    protected void Delete_CAP(string sql)
    {
        clsMySQL db = new clsMySQL();
        string sql_delete_cap = "Delete from npi_cap_ep where CAP_EP_Name='" + sql + "'";
        if(db.dbQueryExecuteNonQuery(sql_delete_cap)==true)
        {
            string strScript = string.Format("<script language='javascript'>alert('未刪除!');</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
        }

    }

    protected void butSearch_Click(object sender, EventArgs e)
    {

    }
    protected void DBint()
    {
        //string sql_cap = "select * from npi_ep_cap where like '" + Text_packge.Text.Trim() + "%'";
        string sql_cap = "select * from npi_cap_ep ";
        clsMySQL ds = new clsMySQL();

        clsMySQL.DBReply dr = ds.QueryDS(sql_cap);
        GD_CAP.DataSource = dr.dsDataSet.Tables[0].DefaultView;
        GD_CAP.DataBind();
        ds.Close();
        
    }

    protected void GD_CAP_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    protected void GD_CAP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strScript = "";
        clsMySQL db = new clsMySQL();
        int index=0;
       

        switch (e.CommandName) {

        case "Insert":

                Panel_CAP_table.Visible = true;
                Panel_Packge.Visible = false;
                break;
       case "Delete" :
                index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selecteRow = GD_CAP.Rows[index];
                string Packge_Name = selecteRow.Cells[1].Text;
                string strData = Packge_Name;
                strScript = string.Format("<script language='javascript'>ConfirmDelManual('確定刪除？','" + strData + "');</script>",Packge_Name);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);

                /*string sql_cap_delete = "delete from npi_cap_ep where CAP_EP_Name='" + Packge_Name+ "'";
                if (db.QueryExecuteNonQuery(sql_cap_delete) == true)
                {
                    string strScript = string.Format("<script language='javascript'>alert('此" + Packge_Name + "刪除成功!');</script>");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
                    DBint();
                }
                else
                {
                    string strScript = string.Format("<script language='javascript'>alert('此" + Packge_Name + "刪除失敗!');</script>");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
                }*/
                break;
                
  
        }
    }

    protected void Button_Save_CAP_Click(object sender, EventArgs e)
    {

       



   }



    protected void Button_Add_Click(object sender, EventArgs e)
    {
        clsMySQL db = new clsMySQL();

        string Status = "Y";
        string User_Name = "CIM";
        String insert_cap = string.Format("insert into npi_cap_ep" +
                                        "(CAP_EP_Name,Update_Time,npiuser,CAP_EP_Status," +
                                      "CAP_EP_01,CAP_EP_02,CAP_EP_03,CAP_EP_04,CAP_EP_05," +
                                      "CAP_EP_06,CAP_EP_07,CAP_EP_08,CAP_EP_09,CAP_EP_10," +
                                      "CAP_EP_11,CAP_EP_12,CAP_EP_13,CAP_EP_14,CAP_EP_15," +
                                      "CAP_EP_16,CAP_EP_17,CAP_EP_18,CAP_EP_19,CAP_EP_20," +
                                      "CAP_EP_21,CAP_EP_22,CAP_EP_23,CAP_EP_24,CAP_EP_25," +
                                      "CAP_EP_26,CAP_EP_27,CAP_EP_28,CAP_EP_29,CAP_EP_30," +
                                      "CAP_EP_31,CAP_EP_32,CAP_EP_33,CAP_EP_34,CAP_EP_35," +
                                      "CAP_EP_36,CAP_EP_37,CAP_EP_38,CAP_EP_39,CAP_EP_40," +
                                      "CAP_EP_41,CAP_EP_42,CAP_EP_43,CAP_EP_44,CAP_EP_45," +
                                      "CAP_EP_46,CAP_EP_47,CAP_EP_48,CAP_EP_49,CAP_EP_50," +
                                      "CAP_EP_51,CAP_EP_52,CAP_EP_53,CAP_EP_54,CAP_EP_55," +
                                      "CAP_EP_56,CAP_EP_57,CAP_EP_58,CAP_EP_59,CAP_EP_60," +
                                      "CAP_EP_61,CAP_EP_62,CAP_EP_63,CAP_EP_64,CAP_EP_65," +
                                      "CAP_POR_EP_01,CAP_POR_EP_02,CAP_POR_EP_03,CAP_POR_EP_04,CAP_POR_EP_05," +
                                      "CAP_POR_EP_06,CAP_POR_EP_07,CAP_POR_EP_08,CAP_POR_EP_09,CAP_POR_EP_10," +
                                      "CAP_POR_EP_11,CAP_POR_EP_12,CAP_POR_EP_13,CAP_POR_EP_14,CAP_POR_EP_15)values" +
                                      "('{0}',NOW(),'{1}','{2}'," +
                                       "'{3}','{4}','{5}','{6}','{7}'," +
                                       "'{8}','{9}','{10}','{11}','{12}'," +
                                       "'{13}','{14}','{15}','{16}','{17}'," +
                                       "'{18}','{19}','{20}','{21}','{22}'," +
                                       "'{23}','{24}','{25}','{26}','{27}'," +
                                       "'{28}','{29}','{30}','{31}','{32}'," +
                                       "'{33}','{34}','{35}','{36}','{37}'," +
                                       "'{38}','{39}','{40}','{41}','{42}'," +
                                       "'{43}','{44}','{45}','{46}', '{47}'," +
                                       "'{48}','{49}','{50}','{51}','{52}'," +
                                       "'{53}','{54}','{55}','{56}','{57}'," +
                                       "'{58}','{59}','{60}','{61}','{62}'," +
                                       "'{63}','{64}','{65}','{66}','{67}'," +
                                       "'{68}','{69}','{70}','{71}','{72}'," +
                                       "'{73}','{74}','{75}','{76}','{77}'," +
                                       "'{78}','{79}','{80}','{81}','{82}')"
                                       , Text_Packge_insert.Text, User_Name, Status,
                                       Text__CAP_1.Text, Text__CAP_2.Text, Text__CAP_3.Text, Text__CAP_4.Text, Text__CAP_5.Text,
                                       Text__CAP_6.Text, Text__CAP_7.Text, Text__CAP_8.Text, Text__CAP_9.Text, Text__CAP_10.Text,
                                       Text__CAP_11.Text, Text__CAP_12.Text, Text__CAP_13.Text, Text__CAP_14.Text, Text__CAP_15.Text,
                                       Text__CAP_16.Text, Text__CAP_17.Text, Text__CAP_18.Text, Text__CAP_19.Text, Text__CAP_20.Text,
                                       Text__CAP_21.Text, Text__CAP_21.Text, Text__CAP_22.Text, Text__CAP_23.Text, Text__CAP_25.Text,
                                       Text__CAP_26.Text, Text__CAP_27.Text, Text__CAP_28.Text, Text__CAP_29.Text, Text__CAP_30.Text,
                                       Text__CAP_31.Text, Text__CAP_32.Text, Text__CAP_33.Text, Text__CAP_34.Text, Text__CAP_35.Text,
                                       Text__CAP_36.Text, Text__CAP_37.Text, Text__CAP_38.Text, Text__CAP_39.Text, Text__CAP_40.Text,
                                       Text__CAP_41.Text, Text__CAP_42.Text, Text__CAP_43.Text, Text__CAP_44.Text, Text__CAP_45.Text,
                                       Text__CAP_46.Text, Text__CAP_47.Text, Text__CAP_48.Text, Text__CAP_49.Text, Text__CAP_50.Text,
                                       Text__CAP_51.Text, Text__CAP_52.Text, Text__CAP_53.Text, Text__CAP_54.Text, Text__CAP_55.Text,
                                       Text__CAP_56.Text, Text__CAP_57.Text, Text__CAP_58.Text, Text__CAP_59.Text, Text__CAP_60.Text,
                                       Text__CAP_61.Text, Text__CAP_62.Text, Text__CAP_63.Text, Text__CAP_64.Text, Text__CAP_65.Text,
                                        Text_CAP_POR_EP_01.Text, Text_CAP_POR_EP_2.Text, Text_CAP_POR_EP_3.Text, Text_CAP_POR_EP_4.Text, Text_CAP_POR_EP_5.Text,
                                      Text_CAP_POR_EP_6.Text, Text_CAP_POR_EP_7.Text, Text_CAP_POR_EP_8.Text, Text_CAP_POR_EP_9.Text, Text_CAP_POR_EP_10.Text,
                                      Text_CAP_POR_EP_11.Text, Text_CAP_POR_EP_12.Text, Text_CAP_POR_EP_13.Text, Text_CAP_POR_EP_14.Text, Text_CAP_POR_EP_15.Text);

        try
        {
            if (Text_Packge_insert.Text.Trim()=="")
            {
                string strScript = string.Format("<script language='javascript'>alert('您沒有輸入Packge_Name!');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
            }
            else if(db.QueryExecuteNonQuery(insert_cap) == true)
            {
                string strScript = string.Format("<script language='javascript'>alert('Packge:" + Text_Packge_insert.Text + "新增成功');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
                Panel_CAP_table.Visible = false;
                Panel_Packge.Visible = true;
                DBint();
            }
            else
            {
                string strScript = string.Format("<script language='javascript'>alert('Packge:" + Text_Packge_insert.Text + "新增失敗');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Panel_Packge.Visible = true;
        Panel_CAP_table.Visible = false;
    }



    

    protected void GD_CAP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }

    protected void GD_CAP_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        clsMySQL db = new clsMySQL();
        try
        {

            GridViewRow gvrow = GD_CAP.Rows[e.RowIndex];

            //lblError.Text = gvrow.Cells[1].Text + "////" + gvrow.Cells[2].Text;
            string strSQL_Delete = string.Format("Delete from npiManual where CAP_EP_Name='{0}'",
                                                gvrow.Cells[1].Text.Trim());

            if (db.QueryExecuteNonQuery(strSQL_Delete))
            {
                RegisterStartupScript("訊息通知", "<script> alert('資料已刪除，成功！！');</script>");
                //ChangeViewMode();
            }
            else
            {
                //lblError.Text = strSQL_Delete;
                RegisterStartupScript("訊息通知", "<script> alert('資料刪除，失敗！！');</script>");
            }
        }
        catch (FormatException ex)
        {
            lblError.Text = "[Error Message::NPI Manual Form Delete Function]: " + ex.ToString();
        }
    }
}
