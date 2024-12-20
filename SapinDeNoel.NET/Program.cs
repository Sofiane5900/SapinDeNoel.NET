
string[] largeurTronc = new string[1] { "|||" };
List<string> listFeuilles = new List<string>();
char feuille = '*';

Console.Write("Choisiez la taille du sapin : ");
int tailleSapin;
bool successSapin = int.TryParse(Console.ReadLine(), out tailleSapin);
if(!successSapin || tailleSapin < 0 || tailleSapin > 30 )
{
    Console.WriteLine("Veuillez entrer une saisie correct");
} else
{
    
}


void DessinerFeuilles(string[] largeurTronc)
{
    for (int i = 0; i < largeurTronc.Length; i++)   
