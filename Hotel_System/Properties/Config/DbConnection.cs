using Microsoft.Data.SqlClient;

namespace Hotel_System.Properties.Config
{
    public class DbConnection
    {
        public string ConnectionString { get; } =
            NormalizeConnectionString(
                Environment.GetEnvironmentVariable("HOTEL_SYSTEM_DB")
                ?? @"Server=localhost\SQLEXPRESS;Database=hoteldb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public bool CanConnect(out string errorMessage)
        {
            try
            {
                using SqlConnection connection = GetConnection();
                connection.Open();
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static string NormalizeConnectionString(string connectionString)
        {
            string normalized = connectionString
                .Replace("SslMode=None;", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("Ssl Mode=None;", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("SslMode=None", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace("Ssl Mode=None", string.Empty, StringComparison.OrdinalIgnoreCase);

            if (!normalized.Contains("TrustServerCertificate", StringComparison.OrdinalIgnoreCase))
            {
                normalized = normalized.TrimEnd(';') + ";TrustServerCertificate=True;";
            }

            if (!normalized.Contains("Encrypt", StringComparison.OrdinalIgnoreCase))
            {
                normalized = normalized.TrimEnd(';') + ";Encrypt=False;";
            }

            return normalized;
        }
    }
}

