//ZADANIE_1
// int age;
//
// while (true)
// {
//     Console.Write("Podaj swój wiek ");
//     String input = Console.ReadLine();
//     bool success = int.TryParse(input, out age);
//     if (age > 18)
//     {
//         Console.Write("mozesz robic zakupy ");
//         break;
//     }
//     else if (age >= 14)
//     {
//         Console.Write("mozesz robic zakupy, ale karty sim nie kupisz ");
//         break;
//     }
//     else
//     {
//         Console.Write("nie mozesz robic zakupow " +'\n');
//     }
// }


//ZADANIE_2

String poprawneHaslo = "admin123";

while (true)
{
    Console.Write("Podaj haslo ");
    String twojeHaslo = Console.ReadLine();

    if (twojeHaslo == poprawneHaslo)
    {
        Console.Write("brawo podales dobre haslo");
        break;
    }
    Console.Write("niepoprawne haslo. sprobuj jeszcze raz");
}