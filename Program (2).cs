using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public decimal GetValue()
    {
        return Quantity * Price;
    }
}

class Program
{
    static void Main()
    {
        List<Product> produkty = new List<Product>();
        bool uruchomiony = true;

        while (uruchomiony)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Zaktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");

            Console.Write("Opcja: ");
            int opcja = int.Parse((Console.ReadLine()));

            switch (opcja)
            {
                case 1:
                    Console.Write("Podaj nazwę produktu do dodania: ");
                    string nowyProdukt = Console.ReadLine();
                    Console.Write("Podaj ilość produktu: ");
                    int ilosc = int.Parse(Console.ReadLine());
                    Console.Write("Podaj cenę produktu: ");
                    decimal cena = decimal.Parse(Console.ReadLine());

                    produkty.Add(new Product(nowyProdukt, ilosc, cena));
                    Console.WriteLine($"Dodano produkt: {nowyProdukt}");
                    break;

                case 2:
                    Console.Write("Podaj nazwę produktu do usunięcia: ");
                    string produktDoUsuniecia = Console.ReadLine();
                    var produktUsuniety = produkty.Find(p => p.Name.Equals(produktDoUsuniecia, StringComparison.OrdinalIgnoreCase));
                    if (produktUsuniety != null)
                    {
                        produkty.Remove(produktUsuniety);
                        Console.WriteLine($"Usunięto produkt: {produktDoUsuniecia}");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono produktu.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Lista produktów:");
                    foreach (var produkt in produkty)
                    {
                        Console.WriteLine($"- {produkt.Name}, Ilość: {produkt.Quantity}, Cena: {produkt.Price} zł, Wartość: {produkt.GetValue()} zł");
                    }
                    break;

                case 4:
                    Console.Write("Podaj nazwę produktu do aktualizacji: ");
                    string produktDoAktualizacji = Console.ReadLine();
                    var produktDoZaktualizowania = produkty.Find(p => p.Name.Equals(produktDoAktualizacji, StringComparison.OrdinalIgnoreCase));

                    if (produktDoZaktualizowania != null)
                    {
                        Console.Write("Podaj nową nazwę produktu: ");
                        string nowyNazwa = Console.ReadLine();
                        Console.Write("Podaj nową ilość produktu: ");
                        int nowaIlosc = int.Parse(Console.ReadLine());
                        Console.Write("Podaj nową cenę produktu: ");
                        decimal nowaCena = decimal.Parse(Console.ReadLine());

                        produktDoZaktualizowania.Name = nowyNazwa;
                        produktDoZaktualizowania.Quantity = nowaIlosc;
                        produktDoZaktualizowania.Price = nowaCena;

                        Console.WriteLine($"Zaktualizowano produkt: {produktDoAktualizacji} -> {nowyNazwa}");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono produktu.");
                    }
                    break;

                case 5:
                    decimal wartoscMagazynu = 0;
                    foreach (var produkt in produkty)
                    {
                        wartoscMagazynu += produkt.GetValue();
                    }
                    Console.WriteLine($"Wartość magazynu: {wartoscMagazynu} zł");
                    break;

                case 6:
                    uruchomiony = false;
                    Console.WriteLine("Zamknięcie programu...");
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
