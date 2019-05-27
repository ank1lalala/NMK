using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationMet
{
    public partial class FORM_HOME : Form
    {
        public string userType;
        public FORM_HOME()
        {
            InitializeComponent();
        }

        private void CKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORM_MANAGE_CiklovaKomisiya fmcg = new FORM_MANAGE_CiklovaKomisiya();
            fmcg.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORM_MANAGE_USER fmus = new FORM_MANAGE_USER();
            fmus.ShowDialog();
        }

       
    }
}
