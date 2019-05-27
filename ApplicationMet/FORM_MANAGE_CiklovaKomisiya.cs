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
    public partial class FORM_MANAGE_CiklovaKomisiya : Form
    {
        DB db = new DB();
        CiklovaKomisiya ck = new CiklovaKomisiya();
       
        DataTable table = new DataTable();
        int position = 0;

        public FORM_MANAGE_CiklovaKomisiya()
        {
            InitializeComponent();
            // populate datagridview and listbox
            table = db.getData("get_all_CiklovaKomisiya", null);
            DGV_CK.DataSource = table;
            navigation(position);
        }
        // button insert categorie
        private void BTN_INSERT_CK_Click(object sender, EventArgs e)
        {
            db.openConnection();
            if ((TB_CK_shifr.Text != string.Empty) || (TB_CK_name.Text != string.Empty))
            {
                ck.insertCK(TB_CK_shifr.Text, TB_CK_name.Text);
                MessageBox.Show("New Category Inserted Successfully", "Insert Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DGV_CK.DataSource = ck.getCK();
            }
        }
        // button delete categorie
        private void BTN_DELETE_CK_Click(object sender, EventArgs e)
        {
            if (TB_ck_nomer.Text != string.Empty)
            {
                if (MessageBox.Show("do you really want to delete this CK", "Remove CK", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ck.deleteCK(Convert.ToInt32(TB_ck_nomer.Text));
                        table = ck.getCK();
                        DGV_CK.DataSource = table;
                        MessageBox.Show("CK Deleted Successfully", "Remove CK");
                        TB_ck_nomer.Text = "";
                        TB_CK_shifr.Text = "";
                        TB_CK_name.Text = "";
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty shifr", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // update categorie
        private void BTN_UPDATE_CK_Click(object sender, EventArgs e)
        {
            if (TB_ck_nomer.Text != string.Empty || TB_CK_shifr.Text != string.Empty || TB_CK_name.Text != string.Empty)
            {
                try
                {
                    db.openConnection();
                    ck.updateCK(Convert.ToInt16(TB_ck_nomer.Text), TB_CK_shifr.Text, TB_CK_name.Text);
                    MessageBox.Show("CK успішне оновлення", "Update CK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DGV_CK.DataSource = ck.getCK();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Порожні данні", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void navigation(int pos)
        {
            DataTable table = new DataTable();
            table = ck.getCK();
            TB_ck_nomer.Text = table.Rows[pos][0].ToString();
            TB_CK_shifr.Text = table.Rows[pos][1].ToString();
            TB_CK_name.Text = table.Rows[pos][2].ToString();
        }

          private void BTN_NEW_CK_Click(object sender, EventArgs e)
        {
            TB_ck_nomer.Text = "";
            TB_CK_shifr.Text = "";
            TB_CK_name.Text = "";
          }

        private void PANEL_MIN_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PANEL_Close_Click(object sender, EventArgs e)
        {
            Close();
        } 
        
        
        //TB_ck_search
         private void BTN_search_CK_Click(object sender, EventArgs e)
        {
            DGV_CK.DataSource = ck.searchCK(TB_ck_search.Text);
        }

         private void FORM_MANAGE_CiklovaKomisiya_Load(object sender, EventArgs e)
         {
             navigation(position);
             int cc = Convert.ToInt32(DGV_CK.Rows[0].Cells[0].Value.ToString());
         }

         private void DGV_CK_Click(object sender, EventArgs e)
         {
             TB_ck_nomer.Text = DGV_CK.CurrentRow.Cells[0].Value.ToString();
             TB_CK_shifr.Text = DGV_CK.CurrentRow.Cells[1].Value.ToString();
             TB_CK_name.Text = DGV_CK.CurrentRow.Cells[2].Value.ToString();
         }

         private void BTN_NEXT_Click(object sender, EventArgs e)
         {
             if (position == ck.getCK().Rows.Count - 1)
                 return;
             position++;
             navigation(position);
         }

         private void BTN_PREVIOUS_Click(object sender, EventArgs e)
         {
             if (position == 0)
                 return;
             position--;
             navigation(position);
         }

         private void TB_ck_search_Click(object sender, EventArgs e)
         {
             TB_ck_search.Text = "";
         }
        

    }
}
