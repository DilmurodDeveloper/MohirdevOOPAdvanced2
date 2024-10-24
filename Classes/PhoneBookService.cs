using System;
using System.Collections.Generic;

namespace MohirdevOOPAdvanced
{
    public class PhoneBookService
    {
        private List<string> contacts;
        private FileBroker fileBroker;        
        private LoggingBroker loggingBroker;

        public PhoneBookService(FileBroker fileBroker, LoggingBroker loggingBroker)
        {
            this.fileBroker = fileBroker;
            this.loggingBroker = loggingBroker;
            this.contacts = fileBroker.ReadAllContacts();
        }

        public void AddContact(string contact)
        {
            try
            {
                contacts.Add(contact);
                fileBroker.WriteAllContacts(contacts);
                loggingBroker.LogInfo($"Kontakt qo'shildi: {contact}");
            }
            catch (Exception ex)
            {
                loggingBroker.LogException(ex);
            }
        }

        public void DeleteContact(string contact)
        {
            try
            {
                if (contacts.Remove(contact))
                {
                    fileBroker.WriteAllContacts(contacts);
                    loggingBroker.LogInfo($"Kontakt o'chirildi: {contact}");
                }
                else
                {
                    loggingBroker.LogError($"Kontakt topilmadi: {contact}");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogException(ex);
            }
        }

        public void EditContact(string oldContact, string newContact)
        {
            try
            {
                int index = contacts.IndexOf(oldContact);
                if (index >= 0)
                {
                    contacts[index] = newContact;
                    fileBroker.WriteAllContacts(contacts);
                    loggingBroker.LogInfo($"Kontakt yangilandi: {oldContact} dan {newContact} ga o'zgardi.");
                }
                else
                {
                    loggingBroker.LogError($"Kontakt topilmadi: {oldContact}");
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogException(ex);
            }
        }

        public void ViewAllContacts()
        {
            try
            {
                Console.WriteLine("Kontaktlar:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogException(ex);
            }
        }

        public void ViewContactByName(string name)
        {
            try
            {
                foreach (var contact in contacts)
                {
                    if (contact.Contains(name))
                    {
                        Console.WriteLine(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                loggingBroker.LogException(ex);
            }
        }
    }
}
