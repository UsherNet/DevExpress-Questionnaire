using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Questions : System.Web.UI.Page
{
	protected DataTable GetQuestions()
	{
		DataTable questions = new DataTable();
		questions.Columns.Add("Id", typeof(int));
		questions.Columns.Add("QuestionId", typeof(double));
		questions.Columns.Add("Question", typeof(string));
		questions.Columns.Add("IsSection", typeof(bool));
		questions.Columns.Add("Answer", typeof(bool));
		questions.Columns.Add("Details", typeof(string));
		questions.Columns.Add("SectionId", typeof(int));
		questions.Columns.Add("SectionName", typeof(string));
		DataColumn[] keys = new DataColumn[1];
		keys[0] = questions.Columns[0];
		questions.PrimaryKey = keys;

		using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyWebConnectionString"].ConnectionString))
		{
			con.Open();
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT * from cQuestions with (nolock) Order By QNo;", con);
			System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();
			bool isSection = false;
			string sectionName = string.Empty;
			while (rs.Read())
			{
				isSection = false;
				sectionName = string.Empty;
				if (!DBNull.Value.Equals(rs[3]))
				{
					isSection = true;
					sectionName = (string)rs[2];
				}
				questions.Rows.Add(rs[0], rs[1], rs[2], isSection, false, "", rs[1], sectionName);
			}
			rs.Close();
			con.Close();
		}
		return questions;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["Q"] == null)
		{
			Session["Q"] = GetQuestions();
		}

		grid.DataSource = Session["Q"];
		if (!IsPostBack && !IsCallback)
		{
			grid.DataBind();
		}
	}

	protected void ASPxGridView1_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
	{
		if (e.RowType == DevExpress.Web.GridViewRowType.Data)
		{
			if (e.KeyValue != null && (bool)e.GetValue("IsSection"))
			{
				//if ((bool)e.GetValue("IsSection"))
				//{
				e.Row.Visible = false;
				//					}
			}
		}

	}

	protected void grid_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
	{
		e.Visible = false;
	}

	private void SendQuestionsAsEmail()
	{
		System.Text.StringBuilder text = new System.Text.StringBuilder();
		foreach (DataRow row in ((DataTable)Session["Q"]).Rows)
		{
			if ((bool)row["IsSection"])
			{
				text.AppendLine(string.Format("<b>{0}</b><br/>", row["SectionName"]));
			}
			else
			{
				text.AppendLine(string.Format("<li>{0} : <b>{1} - {2}</b></li><br/>", row["Question"], row["Answer"].ToString().Replace("True", "Yes").Replace("False", "No"), row["Details"]));
			}
		}

		string body = string.Format("Hi,<br/>A new Questionnaire has been filled out<br/><br/>{0}<br/>", text.ToString());
		string cc = string.Empty;
		Mailer.SendMail(true, "Questionnaire", body);
	}

	protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
	{
		DataRow row = ((DataTable)Session["Q"]).Rows.Find(e.Keys["Id"]);
		row["Answer"] = e.NewValues["Answer"];
		row["Details"] = e.NewValues["Details"];
		e.Cancel = true;
		grid.CancelEdit();
		grid.DataBind();
	}

	protected void grid_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
	{
		SendQuestionsAsEmail();
	}


}