using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetVulture
{
    public partial class frmManageHosts : Form
    {

        public List<string> HostList { get { return _lst; } }
        private List<string> _lst = null;

        public frmManageHosts()
        {
            InitializeComponent();
            _lst = new List<string>();
        }

        public frmManageHosts(List<string> lst)
        {
            InitializeComponent();
            _tbxListInput.Text = String.Join(Environment.NewLine, lst);
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _lst = new List<string>();

            foreach (string item in _tbxListInput.Lines)
            {
                string str = item.Replace(" ", string.Empty);
                _lst.Add(str);
            }
        }
    }
}
