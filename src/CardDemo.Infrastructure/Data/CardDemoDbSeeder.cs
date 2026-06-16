using CardDemo.Core.Entities;

namespace CardDemo.Infrastructure.Data;

/// <summary>
/// Database seeder for initial demo data
/// </summary>
public static class CardDemoDbSeeder
{
    public static async Task SeedAsync(CardDemoDbContext context)
    {
        // Check if database already has data
        if (context.Users.Any())
        {
            return; // Database has been seeded
        }

        // Seed Users
        var users = new List<User>
        {
            new User
            {
                UserId = "ADMIN001",
                FirstName = "Admin",
                LastName = "User",
                Password = "PASSWORD",
                UserType = UserType.Admin
            },
            new User
            {
                UserId = "USER0001",
                FirstName = "John",
                LastName = "Doe",
                Password = "PASSWORD",
                UserType = UserType.Regular
            }
        };

        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        // Seed Customers
        var customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                MiddleName = "A",
                LastName = "Doe",
                AddressLine1 = "123 Main Street",
                AddressLine2 = "Apt 4B",
                AddressLine3 = "",
                StateCode = "NY",
                CountryCode = "USA",
                ZipCode = "10001",
                PhoneNumber1 = "2125551234",
                PhoneNumber2 = "",
                SSN = 123456789,
                GovernmentIssuedId = "DL12345678",
                DateOfBirth = new DateTime(1980, 5, 15),
                EFTAccountId = "1234567890",
                PrimaryCardHolderIndicator = true,
                FicoCreditScore = 750
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Jane",
                MiddleName = "B",
                LastName = "Smith",
                AddressLine1 = "456 Oak Avenue",
                AddressLine2 = "",
                AddressLine3 = "",
                StateCode = "CA",
                CountryCode = "USA",
                ZipCode = "90210",
                PhoneNumber1 = "3105555678",
                PhoneNumber2 = "",
                SSN = 987654321,
                GovernmentIssuedId = "DL87654321",
                DateOfBirth = new DateTime(1985, 8, 22),
                EFTAccountId = "0987654321",
                PrimaryCardHolderIndicator = true,
                FicoCreditScore = 720
            }
        };

        context.Customers.AddRange(customers);
        await context.SaveChangesAsync();

        // Seed Accounts
        var accounts = new List<Account>
        {
            new Account
            {
                AccountId = 10000000001,
                CustomerId = 1,
                ActiveStatus = true,
                CurrentBalance = 1500.00m,
                CreditLimit = 10000.00m,
                CashCreditLimit = 2000.00m,
                OpenDate = new DateTime(2020, 1, 15),
                ExpirationDate = new DateTime(2025, 1, 15),
                ReissueDate = null,
                CurrentCycleCredit = 500.00m,
                CurrentCycleDebit = 2000.00m,
                AddressZip = "10001",
                GroupId = "GROUP001"
            },
            new Account
            {
                AccountId = 10000000002,
                CustomerId = 2,
                ActiveStatus = true,
                CurrentBalance = 3200.00m,
                CreditLimit = 15000.00m,
                CashCreditLimit = 3000.00m,
                OpenDate = new DateTime(2019, 6, 20),
                ExpirationDate = new DateTime(2024, 6, 20),
                ReissueDate = null,
                CurrentCycleCredit = 800.00m,
                CurrentCycleDebit = 4000.00m,
                AddressZip = "90210",
                GroupId = "GROUP002"
            }
        };

        context.Accounts.AddRange(accounts);
        await context.SaveChangesAsync();

        // Seed Cards
        var cards = new List<Card>
        {
            new Card
            {
                CardNumber = "1234567890123456",
                AccountId = 10000000001,
                CVVCode = 123,
                EmbossedName = "JOHN A DOE",
                ExpirationDate = new DateTime(2025, 12, 31),
                ActiveStatus = true
            },
            new Card
            {
                CardNumber = "2345678901234567",
                AccountId = 10000000002,
                CVVCode = 456,
                EmbossedName = "JANE B SMITH",
                ExpirationDate = new DateTime(2024, 11, 30),
                ActiveStatus = true
            }
        };

        context.Cards.AddRange(cards);
        await context.SaveChangesAsync();

        // Seed Card Account Cross References
        var xrefs = new List<CardAccountCrossReference>
        {
            new CardAccountCrossReference
            {
                CardNumber = "1234567890123456",
                CustomerId = 1,
                AccountId = 10000000001
            },
            new CardAccountCrossReference
            {
                CardNumber = "2345678901234567",
                CustomerId = 2,
                AccountId = 10000000002
            }
        };

        context.CardAccountCrossReferences.AddRange(xrefs);
        await context.SaveChangesAsync();

        // Seed Transactions
        var transactions = new List<Transaction>
        {
            new Transaction
            {
                TransactionId = 1,
                AccountId = 10000000001,
                CardNumber = "1234567890123456",
                TransactionDate = DateTime.Now.AddDays(-5),
                TransactionType = "PU",
                TransactionCategory = "GROC",
                TransactionAmount = 125.50m,
                MerchantName = "Whole Foods Market",
                MerchantCity = "New York",
                MerchantState = "NY",
                PostedIndicator = true,
                PostingDate = DateTime.Now.AddDays(-4)
            },
            new Transaction
            {
                TransactionId = 2,
                AccountId = 10000000001,
                CardNumber = "1234567890123456",
                TransactionDate = DateTime.Now.AddDays(-3),
                TransactionType = "PU",
                TransactionCategory = "GAS",
                TransactionAmount = 45.00m,
                MerchantName = "Shell Gas Station",
                MerchantCity = "New York",
                MerchantState = "NY",
                PostedIndicator = true,
                PostingDate = DateTime.Now.AddDays(-2)
            },
            new Transaction
            {
                TransactionId = 3,
                AccountId = 10000000002,
                CardNumber = "2345678901234567",
                TransactionDate = DateTime.Now.AddDays(-2),
                TransactionType = "PU",
                TransactionCategory = "DINN",
                TransactionAmount = 85.75m,
                MerchantName = "The Cheesecake Factory",
                MerchantCity = "Los Angeles",
                MerchantState = "CA",
                PostedIndicator = false,
                PostingDate = null
            }
        };

        context.Transactions.AddRange(transactions);
        await context.SaveChangesAsync();
    }
}
