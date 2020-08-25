using System;
using System.Threading;

/// <summary>
/// Victor Weilemann
/// IS 119 - 25.08.2020
/// </summary>

namespace TicTacToe
{
    class Program

        {

            // Erzeugung eines Arrays, welche die einzelnen Spielfelder beinhaltet

            static char[] spielfeld = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            static int spieler = 1;  

            static int feldauswahl;   



            // Die Variable ergebnis überprüft, ob jemand schon gewonnen hat: 1 = Gewinner, -1 = Unentschieden, 0 = Spiel geht weiter  

            static int ergebnis = 0;



            static void Main(string[] args)

            {

                do

                {

                    Console.Clear();// Bei Aktivierung des Loops wird die Konsole gelöscht

                    Console.WriteLine("Spieler 1:X und Spieler 2:O");

                    Console.WriteLine("\n");

                    if (spieler % 2 == 0)//Überprüfen, welcher Spieler am Zug ist  

                    {

                        Console.WriteLine("Spieler 2 ist am Zug.");

                    }

                    else

                    {

                        Console.WriteLine("Spieler 1 ist am Zug");

                    }

                    Console.WriteLine("\n");

                    spielbrett();// Aufrufen des Spielbretts  

                    feldauswahl = int.Parse(Console.ReadLine());//Spielereingabe  
                
                    



                    // Welches Symbol soll an die Stelle des Spielfelds

                    if (spielfeld[feldauswahl] != 'X' && spielfeld[feldauswahl] != 'O')

                    {

                        if (spieler % 2 == 0) //Wenn Spieler 2 dann 0 sonst X  

                        {

                            spielfeld[feldauswahl] = 'O';

                            spieler++;

                        }

                        else

                        {

                            spielfeld[feldauswahl] = 'X';

                            spieler++;

                        }

                    }

                    else //Wenn ein Spielfeld schon belegt ist 

                    {

                        Console.WriteLine("Die Zeile {0} wurde schon durch {1} ausgewählt!", feldauswahl, spielfeld[feldauswahl]);

                        Console.WriteLine("\n");

                        Console.WriteLine("Bitte warte einen Moment, bis das Board neugeladen ist");

                        Thread.Sleep(2000);

                    }

                    ergebnis = siegbedingung();// Kontrolle, ob jemand gewonnen hat  

                } while (ergebnis != 1 && ergebnis != -1); // Der Loop läuft solange bis alle Felder ausgefüllt sind, oder ein Spieler gewonnen hat



                Console.Clear(); 

                spielbrett();  



                if (ergebnis == 1)// Wenn ergebnis = 1 hat jemand gewonnen, Ausgabe des Gewinners, wie folgt:  

                {

                    Console.WriteLine("Spieler {0} hat gewonnen!", (spieler % 2) + 1);

                }

                else// Wenn das Ergebnis -1 ist, liegt ein Unentschieden vor 

                {

                    Console.WriteLine("Unentschieden");

                }

                Console.ReadLine();

            }

            // Boardmethode zur Erstellung eines Spielbrettes

            private static void spielbrett()

            {

                Console.WriteLine("     |     |      ");

                Console.WriteLine("  {0}  |  {1}  |  {2}", spielfeld[1], spielfeld[2], spielfeld[3]);

                Console.WriteLine("_____|_____|_____ ");

                Console.WriteLine("     |     |      ");

                Console.WriteLine("  {0}  |  {1}  |  {2}", spielfeld[4], spielfeld[5], spielfeld[6]);

                Console.WriteLine("_____|_____|_____ ");

                Console.WriteLine("     |     |      ");

                Console.WriteLine("  {0}  |  {1}  |  {2}", spielfeld[7], spielfeld[8], spielfeld[9]);

                Console.WriteLine("     |     |      ");

            }



            //Methode um zu kontrollieren, wer gewonnen hat 

            private static int siegbedingung()

            {

                #region Horizontal

                //Erste Zeile   

                if (spielfeld[1] == spielfeld[2] && spielfeld[2] == spielfeld[3])

                {

                    return 1;

                }

                //Zweite Zeile   

                else if (spielfeld[4] == spielfeld[5] && spielfeld[5] == spielfeld[6])

                {

                    return 1;

                }

                //Dritte Zeile  

                else if (spielfeld[6] == spielfeld[7] && spielfeld[7] == spielfeld[8])

                {

                    return 1;

                }

                #endregion



                #region Vertikal

                //Erste Reihe       

                else if (spielfeld[1] == spielfeld[4] && spielfeld[4] == spielfeld[7])

                {

                    return 1;

                }

                //Zweite Reihe  

                else if (spielfeld[2] == spielfeld[5] && spielfeld[5] == spielfeld[8])

                {

                    return 1;

                }

                //Dritte Reihe  

                else if (spielfeld[3] == spielfeld[6] && spielfeld[6] == spielfeld[9])

                {

                    return 1;

                }

                #endregion



                #region Diagonal

                else if (spielfeld[1] == spielfeld[5] && spielfeld[5] == spielfeld[9])

                {

                    return 1;

                }

                else if (spielfeld[3] == spielfeld[5] && spielfeld[5] == spielfeld[7])

                {

                    return 1;

                }

                #endregion



                #region Unentschieden

                
                else if (spielfeld[1] != '1' && spielfeld[2] != '2' && spielfeld[3] != '3' && spielfeld[4] != '4' && spielfeld[5] != '5' && spielfeld[6] != '6' && spielfeld[7] != '7' && spielfeld[8] != '8' && spielfeld[9] != '9')

                {

                    return -1;

                }

                #endregion



                else

                {

                    return 0;

                }

            }

        }

    }  