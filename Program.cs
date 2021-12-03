using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            bool stop = true;
            do
            {
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Delete customer");
                Console.WriteLine("3. Update employee adress");
                Console.WriteLine("4. Show ordervalue by country");
                Console.WriteLine("5. Place order");
                Console.WriteLine("6. Delete order");
                Console.WriteLine("7. Exit program");

                int input = MenuInputHandler();

                switch (input)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        Console.WriteLine("Delete by:\n1. Customer ID\n2. Company Name");
                        int userinput;
                        while (!int.TryParse(Console.ReadLine(), out userinput) || userinput < 1 || userinput > 2)
                        {
                            Console.WriteLine("Invalid input, please try again...\n");
                        }
                        if (userinput == 1)
                        {
                            Console.WriteLine("Enter customer ID:");
                            int userInput2 = int.Parse(Console.ReadLine());
                            DeleteCustomer(userInput2);
                        }
                        else if (userinput == 2)
                        {
                            Console.WriteLine("Enter company name:");
                            string userInput3 = Console.ReadLine();
                            DeleteCustomer(userInput3);
                        }
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        ShowCountrySales();
                        break;
                    case 5:
                        PlaceOrder();
                        break;
                    case 6:
                        DeleteCustomerOrder();
                        break;
                    case 7:
                        stop = false;
                        break;
                }
            } while (stop == true);
        }
        static void AddCustomer() //KLAR
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                Console.WriteLine("Enter customer ID:");
                string customerId = Console.ReadLine();
                Console.WriteLine("Enter company name:");
                string companyName = Console.ReadLine();
                Console.WriteLine("Enter contact name:");
                string contactName = Console.ReadLine();
                Console.WriteLine("Enter contact title:");
                string contactTitle = Console.ReadLine();
                Console.WriteLine("Enter adress:");
                string address = Console.ReadLine();
                Console.WriteLine("Enter city:");
                string city = Console.ReadLine();
                Console.WriteLine("Enter region:");
                string region = Console.ReadLine();
                Console.WriteLine("Enter postal code:");
                string postalCode = Console.ReadLine();
                Console.WriteLine("Enter country:");
                string country = Console.ReadLine();
                Console.WriteLine("Enter phone:");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter fax:");
                string fax = Console.ReadLine();

                string queryString =
                "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                "VALUES (@customerID, @companyName, @contactName, @contactTitle, @adress, @city, @region, @postalCode, @country, @phone, @fax)";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@customerID", customerId);
                command.Parameters.AddWithValue("@companyName", companyName);
                command.Parameters.AddWithValue("@contactName", contactName);
                command.Parameters.AddWithValue("@contactTitle", contactTitle);
                command.Parameters.AddWithValue("@adress", address);
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@region", region);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@country", country);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@fax", fax);

                connection.Open();
                command.ExecuteNonQuery();

                // PROBLEM 1
                // eftersom vi inte fick ändra struktur eller schema måste användaren lägga till customerID manuellt vilket skapar problem.
                // mitt syfte med att ändra i strukturen(omvandla customerID till INT) är att kunna autoinjecta ett customerID

                // PROBLEM 2
                // Försökte få alla parametrar att lagras i en lista för att använda indexet till parametrarna,
                // problem att få idexet att skrivas ut korrekt, for-loopen hoppar över index tom. i en array(för utskriften till användaren).
                // Måste använda LINQ?

                /*string[] parameterOutput = {
                    "Enter company name:",
                    "Enter contact name:",
                    "Enter contact title:",
                    "Enter adress:",
                    "Enter city:",
                    "Enter region:",
                    "Enter postal code:",
                    "Enter country:",
                    "Enter phone:",
                    "Enter fax:" };
                var parameterList = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(parameterOutput[i]);
                    string input = Console.ReadLine();
                    parameterList.Add(input);
                    i++;
                }
                foreach (var item in parameterOutput)
                {
                    Console.WriteLine(parameterOutput);
                    string input = Console.ReadLine();
                    parameterList.Add(input);
                }*/
            }
        }
        static void DeleteCustomer(int customerId) //KLAR
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                
                string queryString = 
                    "DELETE FROM Customers " +
                    "WHERE CustomerID = @customerId";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@customerId", customerId.ToString());

                connection.Open();
                command.ExecuteNonQuery();

                // PROBLEM 
                // Glömde konvertera intvariabeln som skickades till metoden till en string för att kunna köra parametern i SQLMSMMSMMSMMSMSss
            }
        }
        static void DeleteCustomer(string companyName) //KLAR
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {

                string queryString =
                    "DELETE FROM Customers " +
                    "WHERE CompanyName = @companyName";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@companyName", companyName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        static void UpdateEmployee() //KLAR
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                Console.WriteLine("Enter employeeID:");
                string employeeId = Console.ReadLine();
                Console.WriteLine("Enter new adress:");
                string adress = Console.ReadLine();

                string queryString = 
                    "UPDATE Addresses " +
                    "SET AddressText = @adress " +
                    "FROM Employees e " +
                    "JOIN Addresses a " +
                    "ON e.EmployeeID = a.AddressID " +
                    "WHERE e.EmployeeID = @employeeID";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@employeeID", employeeId);
                command.Parameters.AddWithValue("@adress", adress);
                
                // PROBLEM
                // Ingen aning om hur jag skall kunna koppla samman employeeID samt adressID i syfte att ändra townname i adresstable

                //Console.WriteLine("Enter new town:");
                //string town = Console.ReadLine();

                //string queryString2 =
                //    "UPDATE Towns SET Name = @town " +
                //    "FROM Employees e " +
                //    "JOIN Towns t " +
                //    "ON e.EmployeeID = t.TownID " +
                //    "WHERE e.EmployeeID = @employeeID";

                //SqlCommand command2 = new SqlCommand(queryString2, connection);
                //command.Parameters.AddWithValue("@employeeID", employeeId);
                //command.Parameters.AddWithValue("@town", town);

                //connection.Open();
                //command.ExecuteNonQuery();
            }
        }
        static void ShowCountrySales() //KLAR
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string queryString =
                    "SELECT e.FirstName, e.LastName, SUM(od.UnitPrice) AS Total, o.ShipCountry AS Country " +
                    "FROM Orders o " +
                    "INNER JOIN[Order Details] od " +
                    "ON od.OrderID = o.OrderID " +
                    "INNER JOIN Employees e " +
                    "ON o.EmployeeID = e.EmployeeID " +
                    "WHERE o.ShipCountry = 'Sweden' " +
                    "GROUP BY e.LastName, e.FirstName, o.ShipCountry " +
                    "ORDER BY Total";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        decimal total = (decimal)reader["Total"];
                        string country = (string)reader["Country"];
                        Console.WriteLine($"{firstName} {lastName} - {country} - {total}");
                    }
                }
                connection.Close();
            }
        }
        static void PlaceOrder() //KLAR
        {
            AddHardCodedCustomer();

            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string queryString =
                    "INSERT INTO Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, " +
                    "ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " +
                    "VALUES('ABBAS', '13', '2021-12-01', '2021-12-01', '2021-12-01', '1', '1337', " +
                    "'POSTNORD', 'Kalle Ankavägen 3A', 'Trosa', 'ST', '13337', 'Sweden') " +
                    "INSERT INTO[Order Details](OrderID, ProductID, UnitPrice, Quantity, Discount) " +
                    "VALUES(SCOPE_IDENTITY(), '43', '46', '13', '0')";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();

                // PROBLEM 1
                // Constraints gör att jag ej kan lägga till OrderID, testade med noahs sätt att slänga in scope_identity och då funkar det, men vet ej varför
                // Hittade constraintsen i table men förstår inte varför OrderID inte fungerar. enda constraints jag hittade var på quantity, price och discount
                // Fråga Paul

                // PROBLEM 2
                // Constraint på CustomerID. En customer måste finnas för att kunna lägga en order, löste genom att lägga till en customer med CustomerID = ABBAS i databasen
                // Numera löst genom att skapa en customer med samma CustomerID som ordern läggs till
            }
        }
        static void DeleteCustomerOrder() //KLAR

        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string queryString =
                    "DELETE FROM [Order Details] " +
                    "WHERE OrderID " +
                        "IN(SELECT o.OrderID FROM Orders o WHERE o.CustomerID = 'ABBAS') " +
                    "DELETE FROM Orders " +
                    "WHERE CustomerID = 'ABBAS' " +
                    "DELETE FROM Customers " +
                    "WHERE CustomerID = 'ABBAS'";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static int MenuInputHandler()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 7)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please try again...\n");
            }
            return input;
        }
        static void AddHardCodedCustomer()
        {
            string connString =
                @"Data Source=DESKTOP-C1T12G4\SQLEXPRESS;" +
                @"Initial Catalog=TelerikAcademy05;" +
                @"Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                string queryString =
                "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                "VALUES (@customerID, @companyName, @contactName, @contactTitle, @adress, @city, @region, @postalCode, @country, @phone, @fax)";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@customerID", "ABBAS");
                command.Parameters.AddWithValue("@companyName", "ABBA AB");
                command.Parameters.AddWithValue("@contactName", "Pelle Svanslös");
                command.Parameters.AddWithValue("@contactTitle", "ASDF");
                command.Parameters.AddWithValue("@adress", "Huvudvärksgatan 99");
                command.Parameters.AddWithValue("@city", "Brno");
                command.Parameters.AddWithValue("@region", "Europe");
                command.Parameters.AddWithValue("@postalCode", "13377");
                command.Parameters.AddWithValue("@country", "Tjeckien");
                command.Parameters.AddWithValue("@phone", "1337");
                command.Parameters.AddWithValue("@fax", "1337-2");

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
