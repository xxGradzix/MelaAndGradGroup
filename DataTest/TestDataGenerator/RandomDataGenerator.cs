using Data.API;
using Data.dataContextImpl;
using Data.Users;

namespace DataTest.TestDataGenerator
{
    internal class RandomDataGenerator : IDataGenerator
    {
        private readonly IData _data;
        private readonly Random _random = new();

        public RandomDataGenerator()
        {
            _data = new DataContext();
            GenerateProducts();
            GenerateUsers();
        }

        public IData GetData() => _data;

        private void GenerateProducts()
        {
            string[] names = { "Crocodilo", "Bombombini", "Tung tung", "Chimpanzini" };
            double[] prices = { 123.5, 321, 666, 999 };
            int[] quantity = { 10, 200, 3000, 4000 };
            string[] descriptions = { "Um fotuto aligatore volante", "desc2", "desc 3", " desc 4" };

            for (int i = 1; i <= 10; i++)
            {
                // IProduct product = new Product(
                //     name: names[_random.Next(names.Length)],
                //     price: prices[_random.Next(prices.Length)],
                //     quantity: quantity[_random.Next(quantity.Length)],
                //     description: descriptions[_random.Next(descriptions.Length)]
                // );
    
                
                _data.AddCatalog(i, names[_random.Next(names.Length)], prices[_random.Next(prices.Length)], descriptions[_random.Next(descriptions.Length)]);
            }
        }

        private void GenerateUsers()
        {
            string[] names = { "name1", "name2", "name3", "name4", "name5" };
            string[] passwords = { "password1", "password1com", "password12org", "password3", "password34" };
            string[] mails = { "name1@example.org", "name2@gmail.com", "name3@example.org", "name4@example.org", "name5@gmail.com" };
            string[] phones = { "123456789", "987654321", "000000000", "666666666" };

            for (int i = 1; i <= 5; i++)
            {
                string name = names[_random.Next(names.Length)];
                string password = passwords[_random.Next(passwords.Length)];
                string email = mails[_random.Next(mails.Length)];
                string phone = phones[_random.Next(phones.Length)];
                
                // User reader = new Customer(name, email, password, phone);
                _data.AddUser(i, name, password, email, phone);
            }
        }

    }
}
