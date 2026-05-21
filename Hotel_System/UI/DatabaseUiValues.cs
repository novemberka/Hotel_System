using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;

namespace Hotel_System.UI
{
    internal static class DatabaseUiValues
    {
        private static readonly string[] RoomStatuses =
        {
            "Available",
            "Occupied",
            "Reserved",
            "Reserved/Booked",
            "Cleaning",
            "Maintenance"
        };

        private static readonly string[] BookingStatuses =
        {
            "Reserved",
            "Booked",
            "Checked In",
            "Checked Out",
            "Cancelled",
            "Completed"
        };

        private static readonly string[] PaymentMethods =
        {
            "Cash",
            "Card",
            "Bank",
            "Other",
            "Credit Card",
            "Transfer"
        };

        private static readonly string[] PaymentStatuses =
        {
            "Paid",
            "Pending",
            "Refunded",
            "Unpaid",
            "Partial"
        };

        public static IReadOnlyList<string> GetRoomStatuses()
        {
            return LoadDistinctValues("SELECT DISTINCT Status FROM rooms WHERE Status IS NOT NULL", RoomStatuses);
        }

        public static IReadOnlyList<string> GetBookingStatuses()
        {
            return LoadDistinctValues("SELECT DISTINCT Status FROM bookings WHERE Status IS NOT NULL", BookingStatuses);
        }

        public static IReadOnlyList<string> GetPaymentMethods()
        {
            return LoadDistinctValues("SELECT DISTINCT PaymentMethod FROM payments WHERE PaymentMethod IS NOT NULL", PaymentMethods);
        }

        public static IReadOnlyList<string> GetPaymentStatuses()
        {
            return LoadDistinctValues("SELECT DISTINCT PaymentStatus FROM payments WHERE PaymentStatus IS NOT NULL", PaymentStatuses);
        }

        private static IReadOnlyList<string> LoadDistinctValues(string sql, IEnumerable<string> fallbackValues)
        {
            List<string> values = new();
            HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);

            try
            {
                using SqlConnection connection = new DbConnection().GetConnection();
                connection.Open();
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AddValue(values, seen, reader.GetValue(0)?.ToString());
                }
            }
            catch
            {
                // Empty/new installations and design-time tooling can run before SQL Server is ready.
            }

            foreach (string value in fallbackValues)
            {
                AddValue(values, seen, value);
            }

            return values;
        }

        private static void AddValue(List<string> values, HashSet<string> seen, string? value)
        {
            string normalized = value?.Trim() ?? string.Empty;
            if (normalized.Length == 0 || !seen.Add(normalized))
            {
                return;
            }

            values.Add(normalized);
        }
    }
}
