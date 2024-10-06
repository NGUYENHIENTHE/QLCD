using DAL;
using Neo4j.Driver;
using Neo4jClient.Cypher;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL _taiKhoanDAL;
        private IDriver _neo4jDriver;

        public TaiKhoanBLL(IDriver neo4jDriver) // Pass IDriver in the constructor
        {
            _neo4jDriver = neo4jDriver;
            _taiKhoanDAL = new TaiKhoanDAL(neo4jDriver);
        }

        public async Task<bool> TestConnection()
        {
            return await _taiKhoanDAL.TestConnection();
        }

        public async Task<bool> Login(string maNV, string matKhau)
        {
            return await _taiKhoanDAL.Login(maNV, matKhau);
        }
        public async Task<TaiKhoan> GetTaiKhoanInfo(string maNV)
        {
            using (var session = _neo4jDriver.AsyncSession())
            {
                var result = await session.RunAsync("MATCH (t:TaiKhoan {MaNV: $maNV}) RETURN t", new { maNV });

                var records = await result.ToListAsync(); // Lấy tất cả các bản ghi vào danh sách
                if (records.Count > 0)
                {
                    var taiKhoanNode = records[0]["t"].As<INode>();
                    return new TaiKhoan
                    {
                        MaNV = taiKhoanNode.Properties["MaNV"].As<string>(),
                        MatKhau = taiKhoanNode.Properties["MatKhau"].As<string>(),
                        HoTen = taiKhoanNode.Properties["HoTen"].As<string>(),
                        ChiNhanh = taiKhoanNode.Properties["ChiNhanh"].As<string>(),
                        SoDT = taiKhoanNode.Properties["SoDT"].As<string>(),
                        LoaiTK = taiKhoanNode.Properties["LoaiTK"].As<string>(),
                    };
                }
                return null; // Trả về null nếu không có bản ghi nào
            }
        }
        public async Task<bool> ChangePassword(string maNV, string matKhauCu, string matKhauMoi)
        {
            using (var session = _neo4jDriver.AsyncSession())
            {
                var result = await session.RunAsync("MATCH (t:TaiKhoan {MaNV: $maNV}) WHERE t.MatKhau = $matKhauCu SET t.MatKhau = $matKhauMoi RETURN COUNT(t) AS count", new { maNV, matKhauCu, matKhauMoi });

                var records = await result.ToListAsync();

                // Kiểm tra xem có bản ghi nào không
                if (records.Count == 0)
                {
                    // Không có bản ghi nào thỏa mãn điều kiện
                    return false;
                }

                // Lấy giá trị COUNT(t)
                return records[0]["count"].As<int>() > 0; // Nếu có bản ghi được cập nhật
            }
        }


    }
}
