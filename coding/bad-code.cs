using System;
using System.Collections.Generic;

class Program
{
    static List<string> inventory = new List<string> { "Laptop", "Smartphone", "Tablet", "Kopfhörer", "Smartwatch" };
    static List<string> cart = new List<string>();
    static List<string> orders = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Artikel suchen");
            Console.WriteLine("2. Warenkorb anzeigen");
            Console.WriteLine("3. Bestellung aufgeben");
            Console.WriteLine("4. Bestellstatus prüfen");
            Console.WriteLine("5. Beenden");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Verfügbare Artikel:");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i]}");
                }
                Console.Write("Artikelnummer zum Hinzufügen zum Warenkorb (oder 0 zum Abbrechen): ");
                int itemChoice = int.Parse(Console.ReadLine()) - 1;
                if (itemChoice >= 0 && itemChoice < inventory.Count)
                {
                    cart.Add(inventory[itemChoice]);
                    Console.WriteLine("Artikel zum Warenkorb hinzugefügt!");
                }
            }
            else if (choice == "2")
            {
                if (cart.Count == 0)
                {
                    Console.WriteLine("Der Warenkorb ist leer.");
                }
                else
                {
                    Console.WriteLine("Warenkorb:");
                    for (int i = 0; i < cart.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {cart[i]}");
                    }
                }
            }
            else if (choice == "3")
            {
                if (cart.Count == 0)
                {
                    Console.WriteLine("Der Warenkorb ist leer. Keine Bestellung möglich.");
                }
                else
                {
                    string order = string.Join(", ", cart);
                    orders.Add(order);
                    Console.WriteLine("Bestellung aufgegeben! Bestellnummer: " + orders.Count);
                    cart.Clear();
                }
            }
            else if (choice == "4")
            {
                Console.Write("Bestellnummer eingeben: ");
                int orderNumber = int.Parse(Console.ReadLine());
                if (orderNumber > 0 && orderNumber <= orders.Count)
                {
                    Console.WriteLine($"Bestellstatus für Bestellung {orderNumber}: Versandt");
                    Console.WriteLine($"Bestellte Artikel: {orders[orderNumber - 1]}");
                }
                else
                {
                    Console.WriteLine("Ungültige Bestellnummer.");
                }
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
            }
        }
    }
}