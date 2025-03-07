using SQLite;

namespace SampleMAUIApp.Bab5
{
    public class DataAccess
    {
        SQLiteConnection database;

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqliteConnection;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            sqliteConnection = new SQLiteConnection(dbPath);
            return sqliteConnection;
        }

        public DataAccess()
        {
            database = GetConnection();
            database.CreateTable<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return database.Query<Employee>("select * from Employee order by EmpName");
        }

        public int SaveEmployee(Employee employee)
        {
            return database.Insert(employee);
        }

        public int DeleteEmployee(Employee employee)
        {
            return database.Delete(employee);
        }

        public int EditEmployee(Employee employee)
        {
            return database.Update(employee);
        }
    }

}
