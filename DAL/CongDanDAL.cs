using Neo4j.Driver;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class CongDanDAL
    {
        private IDriver _neo4jDriver;
        public async Task CapNhatCongDan(string cccd, string hoTen, string gioiTinh, DateTime ngaySinh, string queQuan, string thuongTru)
        {
            var driver = Neo4jConnectionManager.GetDriver();
            var session = driver.AsyncSession();

            try
            {
                // Thực thi câu lệnh Cypher để cập nhật thông tin công dân dựa trên CCCD
                await session.RunAsync("MATCH (c:CongDan {cccd: $cccd}) " +
                                        "SET c.hoten = $hoTen, c.gioitinh = $gioiTinh, c.ngaysinh = $ngaySinh, " +
                                        "c.quequan = $queQuan, c.thuongtru = $thuongTru",
                                        new { cccd, hoTen, gioiTinh, ngaySinh = ngaySinh.ToString("yyyy-MM-dd"), queQuan, thuongTru });

                Console.WriteLine("Cập nhật thông tin công dân thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task XoaCongDan(string cccd)
        {
            var driver = Neo4jConnectionManager.GetDriver();

            // Tạo session làm việc với cơ sở dữ liệu
            var session = driver.AsyncSession();

            try
            {
                // Thực thi câu lệnh Cypher để xóa công dân dựa trên CCCD
                await session.RunAsync("MATCH (c:CongDan {cccd: $cccd}) DETACH DELETE c", new { cccd });

                Console.WriteLine("Xóa công dân thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                // Đóng session sau khi hoàn tất
                await session.CloseAsync();
            }
        }


    }
}
