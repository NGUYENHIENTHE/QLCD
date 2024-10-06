using Neo4j.Driver;

namespace DAL
{
    public class Neo4jConnectionManager
    {
        private static IDriver _driver;

        // Phương thức này chỉ tạo kết nối một lần (singleton pattern)
        public static IDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = GraphDatabase.Driver("neo4j://localhost:7687", AuthTokens.Basic("neo4j", "12345678"));
            }
            return _driver;
        }

        // Đóng kết nối khi không còn sử dụng
        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.CloseAsync().Wait();
                _driver = null;
            }
        }
    }
}
