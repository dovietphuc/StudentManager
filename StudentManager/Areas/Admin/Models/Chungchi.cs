using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManager.Areas.Admin.Models
{
    public class Chungchi
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Tên chứng chỉ không được để trống")]
        [Display(Name = "Tên chứng chỉ")]
        public string sTenchungchi { get; set; }
        [Required(ErrorMessage = "Ngày bắt đầu không được để trống")]
        [Display(Name = "Ngày bắt đầu")]
        public string dNgaybatdau { set; get; }
        [Required(ErrorMessage = "Ngày kết thúc không được để trống")]
        [Display(Name = "Ngày kết thúc")]
        public string dNgayketthuc { get; set; }
        [Display(Name = "Đường dẫn drive tệp đính kèm")]
        public string sLinkdinhkem { get; set; }
    }

    class ListChungchi
    {
        DBConnection db;
        public ListChungchi()
        {
            db = new DBConnection();
        }
        public List<Chungchi> getChungChi(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT * FROM tbl_chungchi";
            else
                sql = "SELECT * FROM tbl_chungchi WHERE ID = " + ID;
            List<Chungchi> listChungchi = new List<Chungchi>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Chungchi chungchi;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                chungchi = new Chungchi();
                chungchi.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                chungchi.sTenchungchi = dt.Rows[i]["sTenchungchi"].ToString();
                chungchi.dNgaybatdau = dt.Rows[i]["dNgaybatdau"].ToString();
                chungchi.dNgayketthuc = dt.Rows[i]["dNgayketthuc"].ToString();
                chungchi.sLinkdinhkem = dt.Rows[i]["sLinkdinhkem"].ToString();
                listChungchi.Add(chungchi);
            }
            return listChungchi;

        }

        
        public void addChungchi(Chungchi cc)
        {
            string sql = "INSERT INTO tbl_chungchi(sTenchungchi, dNgaybatdau, dNgayketthuc, sLinkdinhkem) VALUES ( @tenchungchi, @ngaybatdau, @ngayketthuc, @link)";
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@tenchungchi", cc.sTenchungchi);
            cmd.Parameters.AddWithValue("@ngaybatdau", cc.dNgaybatdau);
            cmd.Parameters.AddWithValue("@ngayketthuc", cc.dNgayketthuc);
            cmd.Parameters.AddWithValue("@link", cc.sLinkdinhkem);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void updateChungchi(Chungchi cc)
        {
            string sql = "UPDATE tbl_chungchi SET sTenchungchi = @tenchungchi, dNgaybatdau = @ngaybatdau, dNgayketthuc = @ngayketthuc, sLinkdinhkem = @link WHERE ID = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", cc.ID);
                cmd.Parameters.AddWithValue("@tenchungchi", cc.sTenchungchi);
                cmd.Parameters.AddWithValue("@ngaybatdau", cc.dNgaybatdau);
                cmd.Parameters.AddWithValue("@ngayketthuc", cc.dNgayketthuc);
                cmd.Parameters.AddWithValue("@link", cc.sLinkdinhkem);
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
        public void deleteChungchi(int ID = 0)
        {
            string sql = "DELETE FROM tbl_chungchi WHERE ID = @id";
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