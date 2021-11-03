using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManager.Areas.Admin.Models
{
    public class Khenthuongkyluat
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [Display(Name = "Tiêu đề")]
        public string sTieude { get; set; }
        [Required(ErrorMessage = "Thời gian lập không được để trống")]
        [Display(Name = "Thời gian lập")]
        public string dThoigianlap { set; get; }
        [Required(ErrorMessage = "Thời gian duyệt không được để trống")]
        [Display(Name = "Thời gian duyệt")]
        public string dThoigianduyet { get; set; }
        [Required(ErrorMessage = "Kinh phí không được để trống")]
        [Display(Name = "Kinh phí")]
        public int iKinhphi { get; set; }
        [Display(Name = "Ghi chú")]
        public string sGhichu { get; set; }
    }

    class Listkhenthuongkyluat
    {
        DBConnection db;
        public Listkhenthuongkyluat()
        {
            db = new DBConnection();
        }
        public List<Khenthuongkyluat> getKhenthuongkyluat(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT * FROM tbl_khenthuongkyluat";
            else
                sql = "SELECT * FROM tbl_khenthuongkyluat WHERE ID = " + ID;
            List<Khenthuongkyluat> listKhenthuongkyluat = new List<Khenthuongkyluat>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Khenthuongkyluat ktkl;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                ktkl = new Khenthuongkyluat();
                ktkl.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                ktkl.sTieude = dt.Rows[i]["sTieude"].ToString();
                ktkl.dThoigianlap = dt.Rows[i]["dThoigianlap"].ToString();
                ktkl.dThoigianduyet = dt.Rows[i]["dThoigianduyet"].ToString();
                ktkl.iKinhphi = Convert.ToInt32(dt.Rows[i]["iKinhphi"].ToString());
                ktkl.sGhichu = dt.Rows[i]["sGhichu"].ToString();
                listKhenthuongkyluat.Add(ktkl);
            }
            return listKhenthuongkyluat;

        }


        public void addKhenthuongkyluat(Khenthuongkyluat ktkl)
        {
            string sql = "INSERT INTO tbl_khenthuongkyluat VALUES ( @tieude, @tglap, @tgduyet, @kinhphi, @ghichu)";
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@tieude", ktkl.sTieude);
            cmd.Parameters.AddWithValue("@tglap", ktkl.dThoigianlap);
            cmd.Parameters.AddWithValue("@tgduyet", ktkl.dThoigianduyet);
            cmd.Parameters.AddWithValue("@kinhphi", ktkl.iKinhphi);
            cmd.Parameters.AddWithValue("@ghichu", ktkl.sGhichu);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void updateKhenthuongkyluat(Khenthuongkyluat ktkl)
        {
            string sql = "UPDATE tbl_khenthuongkyluat SET sTieude = @tieude, dThoigianlap = @tglap, dThoigianduyet = @tgduyet, iKinhphi = @kinhphi, sGhichu = @ghichu WHERE ID = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", ktkl.ID);
                cmd.Parameters.AddWithValue("@tieude", ktkl.sTieude);
                cmd.Parameters.AddWithValue("@tglap", ktkl.dThoigianlap);
                cmd.Parameters.AddWithValue("@tgduyet", ktkl.dThoigianduyet);
                cmd.Parameters.AddWithValue("@kinhphi", ktkl.iKinhphi);
                cmd.Parameters.AddWithValue("@ghichu", ktkl.sGhichu);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void deleteKhenthuongkyluat(int ID = 0)
        {
            string sql = "DELETE FROM tbl_khenthuongkyluat WHERE ID = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

    }
}