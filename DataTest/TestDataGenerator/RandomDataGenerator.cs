using Data.API;
using Data.API.Entities;
using Data.Catalog;
using Data.dataContextImpl.database;
using Data.Users;
using DataTest.TestDataGenerator;

namespace DataTest.TestDataGeneration
{
    internal class RandomDataGenerator : IDataGenerator
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new();

        public RandomDataGenerator(AppDbContext context)
        {
            _context = context;
        }

        public void Generate()
        {
            GenerateProducts();
            GenerateUsers();
            _context.SaveChanges();
        }

        private void GenerateProducts()
        {
            string[] names = { "Crocodilo", "Bombombini", "Tung tung", "Chimpanzini" };
            double[] prices = { 123.5, 321, 666, 999 };
            int[] quantity = { 10, 200, 3000, 4000 };
            string[] descriptions = { "Um fotuto aligatore volante", "desc2", "desc 3", " desc 4" };

            for (int i = 0; i < 10; i++)
            {
                var product = new Product(
                    name: names[_random.Next(names.Length)],
                    price: prices[_random.Next(prices.Length)],
                    quantity: quantity[_random.Next(quantity.Length)],
                    description: descriptions[_random.Next(descriptions.Length)]
                );
                _context.Products.Add(product);
            }
        }

        private void GenerateUsers()
        {
            string[] names = { "name1", "name2", "name3", "name4", "name5" };
            string[] passwords = { "password1", "password1com", "password12org", "password3", "password34" };
            string[] mails = { "name1@example.org", "name2@gmail.com", "name3@example.org", "name4@example.org", "name5@gmail.com" };
            string[] phones = { "123456789", "987654321", "000000000", "666666666" };

            for (int i = 0; i < 5; i++)
            {
                var user = new Customer(
                    names[_random.Next(names.Length)],
                    mails[_random.Next(mails.Length)],
                    passwords[_random.Next(passwords.Length)],
                    phones[_random.Next(phones.Length)]
                );
                _context.Users.Add(user);
            }
        }
    }
}
