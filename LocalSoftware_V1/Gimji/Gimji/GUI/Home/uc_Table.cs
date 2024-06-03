using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimji.GUI.Home
{
    public partial class uc_Table : UserControl
    {
        public event EventHandler BtnBookTableClick;
        public uc_Table()
        {
            InitializeComponent();
        }

        private void btn_Table_Click(object sender, EventArgs e)
        {
            BtnBookTableClick?.Invoke(this, e);
        }

        #region Properties
        public int ID
        {
            get { return Convert.ToInt32(btn_Table.Text); }
            set { btn_Table.Text = value.ToString(); }
        }
        #endregion

    }


}
