using System.Runtime.CompilerServices;
using System.Media;
using System.Numerics;


PlayMusic("song.wav");

//Variables & Tableau
char feuille = '*';
char boule = '0';
string tronc = "|||";
char flocon = '¤';
ConsoleColor[] colors = new ConsoleColor[5]
{
    ConsoleColor.Red,
    ConsoleColor.Green,
    ConsoleColor.DarkYellow,
    ConsoleColor.White,
    ConsoleColor.DarkRed
};

// Boucle menu
while (true)
{

    // Taille du sapin, saisie 
    Console.ForegroundColor = colors[0];
    Console.WriteLine("(Veuillez mettre votre console en PLEINE ECRAN, pour éxperimenter la meilleure éxperience possible.)");
    Console.ResetColor();

    Console.Write("Choisiez la taille du sapin : ");
int tailleSapin;
bool successSapin = int.TryParse(Console.ReadLine(), out tailleSapin);
if (!successSapin || tailleSapin <= 1 || tailleSapin > 30)
    {
        Console.Clear();
        Console.ForegroundColor = colors[4];
        Console.WriteLine("Veuillez entrer une saisie correcte (entre 1 et 30)\n");
        continue;

}
else
{
        // Boucle sapin
      while (true)
        {
            GenererNeige();
            DessinerFeuilles(tailleSapin);
            DessinerTronc(tailleSapin);
            Thread.Sleep(400);
            Console.Clear();

            // SI l'appui sur une touche est disponible et que je presse "C" , je sors de ma boucle sapin
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.C)
            {
                break;
            }

        }
    


    }

}

// Mes fonctions
void DessinerTronc(int tailleSapin) // 
{
    int consoleWidth = Console.WindowWidth; // Je déclare la largeur de la console
    int troncWidth = tronc.Length; 
    int centerPosition = (consoleWidth - troncWidth) / 2; 

    for (int i = 1; i <= tailleSapin / 3; i++) // Tant que index est inférieur ou égal au 1/3 a la saisie tailleSapin, j'incrémente
    {
        Console.ForegroundColor = colors[2];
        Console.SetCursorPosition(centerPosition, Console.CursorTop);
        Console.WriteLine(tronc); // J'affiche des troncs en boucle
    }
    Console.ResetColor();

}

void DessinerFeuilles(int tailleSapin)
{
    int consoleWidth = Console.WindowWidth;  // Je déclare un int de la largeur de la console
    int consoleHeight = Console.WindowHeight;

    Random random = new Random();


    for (int i = 1; i <= tailleSapin; i++) // Tant que index est inférieur a la saisie tailleSapin, 
    {
        int brancheTaille = (i * 2 - 1);
        int centerPositionWidth = (consoleWidth  - brancheTaille) / 2;
        int centerPositionHeight = (consoleHeight - tailleSapin) / 2;
        Console.SetCursorPosition(centerPositionWidth, centerPositionHeight + i - 1);



        for (int j = 0;  j < (i * 2 - 1); j++) // Formule pour calculer suite de nombe impair (askip)
        {
        
        if (random.NextDouble() < 0.1) 
        {
                Console.ForegroundColor = colors[0];
                Console.Write(boule);
            }
            else 
        {
                Console.ForegroundColor = colors[1];
                Console.Write(feuille);
            }
        }
        Console.WriteLine();
    }
    Console.ResetColor();
}

void GenererNeige()
{
    // Je déclare deux variables avec la méthode Window
    int consoleWidth = Console.WindowWidth; 
    int consoleHeight = Console.WindowHeight;
    Random random = new Random();

    // Tant que la taille de ma console est inférieure a mon index
    for (int i = 0; i < consoleHeight; i++)
    {
        // Alors je génere des positions randoms dans ma console
        int positionX = random.Next(0, consoleWidth); 
        int positionY = random.Next(0, consoleHeight);

        Console.SetCursorPosition(positionX, positionY);
        Console.ForegroundColor = colors[3];
        Console.Write(flocon);
    }
    Console.ResetColor();
}

static void PlayMusic(string fichier)
{
    SoundPlayer musicPlayer = new SoundPlayer(fichier);
    musicPlayer.Play();
}