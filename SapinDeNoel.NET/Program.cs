using System.Runtime.CompilerServices;

char feuille = '*';
char boule = '0';
string tronc = "|||";
string[] colors = new string[2]
{
    "Yellow",
    "Green",
};

// Taille du sapin, saisie 
Console.Write("Choisiez la taille du sapin : ");
int tailleSapin;
bool successSapin = int.TryParse(Console.ReadLine(), out tailleSapin);
if (!successSapin || tailleSapin <= 1 || tailleSapin > 30)
{
    Console.WriteLine("Veuillez entrer une saisie correcte (entre 1 et 30)");
}
else
{
    DessinerFeuilles(tailleSapin);
    DessinerTronc(tailleSapin);
}


// Fonction DessinerTronc
void DessinerTronc(int tailleSapin) // 
{
    int consoleWidth = Console.WindowWidth; // Je déclare la largeur de la console
    int troncWidth = tronc.Length; 
    int centerPosition = (consoleWidth - troncWidth) / 2; // Solution temporaire pour placer un element horizontalement

    for (int i = 1; i <= tailleSapin / 3; i++) // Tant que index est inférieur ou égal au 1/3 a la saisie tailleSapin, j'incrémente
    {
        Console.SetCursorPosition(centerPosition, Console.CursorTop);
        Console.WriteLine(tronc); // J'affiche des troncs en boucle
    }

}

// Fonction DessinerFeuilles
void DessinerFeuilles(int tailleSapin)
{
    int consoleWidth = Console.WindowWidth;  // Je déclare un int de la largeur de la console
    Random random = new Random();


    for (int i = 1; i <= tailleSapin; i++) // Tant que index est inférieur a la saisie tailleSapin, 
    {
        string branche = " ";

        for (int j = 1;  j < (i * 2 - 1); j++) // Formule pour calculer suite de nombe impair (askip)
        {
        
        if (random.NextDouble() < 0.1) 
        {
                branche += boule;
        }
        else 
        {
                branche += feuille;
                Console.ResetColor();
            }
        }
        int centerPosition = (consoleWidth - branche.Length) / 2;
        Console.SetCursorPosition(centerPosition, Console.CursorTop);
        Console.WriteLine(branche);

    }


}
