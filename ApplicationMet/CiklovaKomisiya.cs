using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ApplicationMet
{
    class CiklovaKomisiya
    {
        public DataTable getCK()
        {
            DB db = new DB();
            DataTable tab = new DataTable();
            tab = db.getData("get_all_CiklovaKomisiya", null);
            db.closeConnection();
            return tab;
        }

        public void insertCK(string ShifrCK, string NazvaCK )
        {

            DB db = new DB();
            db.openConnection();
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@ShifrCK", SqlDbType.Char, 12);
            parameters[0].Value = ShifrCK;

            parameters[1] = new SqlParameter("@NazvaCK", SqlDbType.Char,40);
            parameters[1].Value = NazvaCK;

            

            db.setData("spr_insert_CiklovaKomisiya", parameters);
            db.closeConnection();

        }

       public DataTable searchCK(string valueToSearch)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@val", SqlDbType.VarChar, 100);
            parameters[0].Value = valueToSearch;
            table = db.getData("spr_search_CK", parameters);
            db.closeConnection();
            return table;
        }

       public void deleteCK(int id_CK)
        {

            DB db = new DB();
            DataTable table = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ckid", SqlDbType.Int);
            parameters[0].Value = id_CK;

            db.openConnection();
            db.setData("spr_delete_CiklovaKomisiya", parameters);
            db.closeConnection();

        }

        public void updateCK(int id, string ShifrCK, string NazvaCK)
        {

            DB db = new DB();
            db.openConnection();
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@id_CK", SqlDbType.Int);
            parameters[0].Value = id;

            parameters[1] = new SqlParameter("@ShifrCK", SqlDbType.Char);
            parameters[1].Value = ShifrCK;

            parameters[2] = new SqlParameter("@NazvaCK", SqlDbType.Char);
            parameters[2].Value = NazvaCK;

            db.setData("spr_update_CiklovaKomisiya", parameters);
            db.closeConnection();

        }
    }
}
