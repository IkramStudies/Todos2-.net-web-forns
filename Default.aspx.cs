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
        }
    }