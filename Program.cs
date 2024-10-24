using System;
using MohirdevOOPAdvanced;
class Program
{
    static void Main(string[] args)
    {
        string filePath = "contacts.txt";

        FileBroker fileBroker = new FileBroker(filePath);
        LoggingBroker loggingBroker = new LoggingBroker();
        PhoneBookService phoneBookService = new PhoneBookService(fileBroker, loggingBroker);

        while (true)
        {
            Console.WriteLine("\n-------Kontaktlarni boshqarish-------");
            Console.WriteLine("1. Kontakt qo'shish");
            Console.WriteLine("2. Kontaktni o'chirish");
            Console.WriteLine("3. Kontaktni tahrirlash");
            Console.WriteLine("4. Barcha kontaktni ko'rish");
            Console.WriteLine("5. Kontaktni ism bo'yicha qidirish");
            Console.WriteLine("6. Chiqish");
            Console.Write("Variantni tanlang: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Kontakt nomini kiriting:");
                    string contact = Console.ReadLine();
                    phoneBookService.AddContact(contact);
                    break;

                case "2":
                    Console.Write("O'chirish uchun kontakt nomini kiriting:");
                    string deleteContact = Console.ReadLine();
                    phoneBookService.DeleteContact(deleteContact);
                    break;

                case "3":
                    Console.Write("Eski kontakt nomini kiriting:");
                    string oldContact = Console.ReadLine();
                    Console.Write("Yangi kontakt nomini kiriting: ");
                    string newContact = Console.ReadLine();
                    phoneBookService.EditContact(oldContact, newContact);
                    break;

                case "4":
                    phoneBookService.ViewAllContacts();
                    break;

                case "5":
                    Console.Write("Qidirish uchun kontakt nomini kiriting: ");
                    string searchName = Console.ReadLine();
                    phoneBookService.ViewContactByName(searchName);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Xato variant. Iltimos, qayta urinib ko'ring.");
                    break;
            }
        }
    }
}
