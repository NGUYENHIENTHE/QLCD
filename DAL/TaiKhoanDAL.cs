using Neo4j.Driver;
using System.Threading.Tasks;

public class TaiKhoanDAL
{
    private readonly IDriver _neo4jDriver;

    public TaiKhoanDAL(IDriver neo4jDriver)
    {
        _neo4jDriver = neo4jDriver;
    }

    // Method to test the connection to Neo4j
    public async Task<bool> TestConnection()
    {
        try
        {
            using (var session = _neo4jDriver.AsyncSession())
            {
                await session.RunAsync("RETURN 1"); // Simple query to check the connection
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    // Method for logging in
    public async Task<bool> Login(string maNV, string matKhau)
    {
        var taiKhoan = await GetTaiKhoanAsync(maNV, matKhau);
        return taiKhoan != null; // Return true if a valid account is found
    }

    public async Task<TaiKhoan> GetTaiKhoanAsync(string maNV, string matKhau)
    {
        using (var session = _neo4jDriver.AsyncSession())
        {
            var cursor = await session.RunAsync("MATCH (t:TaiKhoan {MaNV: $maNV, MatKhau: $matKhau}) RETURN t", new { maNV, matKhau });
            var results = await cursor.ToListAsync();

            if (results.Count == 0)
                return null;

            var record = results[0];
            var taiKhoanNode = record["t"].As<INode>();

            return new TaiKhoan
            {
                MaNV = taiKhoanNode.Properties["MaNV"].As<string>(),
                MatKhau = taiKhoanNode.Properties["MatKhau"].As<string>(),
                HoTen = taiKhoanNode.Properties["HoTen"].As<string>(),
                ChiNhanh = taiKhoanNode.Properties["ChiNhanh"].As<string>(),
                SoDT = taiKhoanNode.Properties["SoDT"].As<string>(),
                LoaiTK = taiKhoanNode.Properties["LoaiTK"].As<string>()
            };
        }
    }
}
