using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todos2
{
    public partial class _Default : Page
    {
        public List<string> Tasks
        {
            get
            {
                if (ViewState["Tasks"] == null)
                    ViewState["Tasks"] = new List<string>();

                return (List<string>)ViewState["Tasks"];
            }
            set
            {
                ViewState["Tasks"] = value;
            }
        }
        // name of repeater is tasksList
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tasksList.DataSource = Tasks;
                tasksList.DataBind();
            }
        }
        public void addTask(object sender, EventArgs e)
        {
            Tasks.Add(textbox.Text);

            tasksList.DataSource = Tasks;
            tasksList.DataBind();

            textbox.Text = "";
        }
        public void EditTask(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Button editbtn = (Button)sender;
            RepeaterItem item = (RepeaterItem)editbtn.NamingContainer;
            TextBox editText = (TextBox)item.FindControl("editText");
            Button saveBtn = (Button)item.FindControl("saveBtn");
            Button delBtn = (Button)item.FindControl("deleteBtn");
            Label taskText = (Label)item.FindControl("tasktext");
            Button cancelBtn = (Button)item.FindControl("cancelBtn");
            editText.Text = Tasks[index];
            taskText.Visible = false;
            editbtn.Visible = false;
            editText.Visible = true;
            saveBtn.Visible = true;
            delBtn.Visible = false;
            cancelBtn.Visible = true;
        }
        public void SaveTask(object sender, CommandEventArgs e)
        {
            Button savebtn = (Button)sender;
            RepeaterItem repeater = (RepeaterItem)savebtn.NamingContainer;
            TextBox editText = (TextBox)repeater.FindControl("editText");
            Label taskText = (Label)repeater.FindControl("tasktext");
            Button delBtn = (Button)repeater.FindControl("deleteBtn");
            int index = Convert.ToInt32(e.CommandArgument);
            Tasks[index] = editText.Text;
            taskText.Visible = true;
            editText.Visible = false;
            savebtn.Visible = false;
            tasksList.DataSource = Tasks;
            tasksList.DataBind();
        }
        public void CancelEdit(object sender, CommandEventArgs e)
        {
            Button cancelBtn = (Button)sender;
            RepeaterItem repeater = (RepeaterItem)cancelBtn.NamingContainer;
            TextBox editText = (TextBox)repeater.FindControl("editText");
            int index = Convert.ToInt32(e.CommandArgument);
            Tasks[index] = editText.Text;
            cancelBtn.Visible = false;
            tasksList.DataSource = Tasks;
            tasksList.DataBind();
        }
        public void DeleteTask(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Tasks.RemoveAt(index);
            tasksList.DataSource = Tasks;
            tasksList.DataBind();
        }
    }
 }