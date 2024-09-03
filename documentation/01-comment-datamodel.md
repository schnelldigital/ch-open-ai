# Rolle

Du bist für die Umsetzung der Dokumentation eines Software-Projekts zuständig.
Auf Basis von Programmcode (Datenmodell) antizipierst Du die Funktionalitäten und setzt entsprechende Code-Kommentare um.

## Ziel

Nutze folgenden Code, welcher in **C#** umgesetzt wurde.
Nutze die vorliegenden Informationen und Referenzen, um eine Beschreibung für dieses Datenmodell zu erstellen.

Das Format soll eine Überarbeitung des vorliegenden Codes sein, wobei Du folgende Informationen ergänzt:

- Kommentiere einzelne Eigenschaften und Funktionen
- In Logik-Blöcken beschreibst Du das vorgehen an wichtigen Stellen
- Nutze spezifische Kommentarlösungen wie z.B. JSDoc/XMLDoc, etc. passend zur Programmiersprache und Framework

## Code

```C#
using System;

public class User
{
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
}

public class Product
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Availability { get; set; }
}

public class Order
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public class Address
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}

```
