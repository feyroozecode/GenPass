using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenPass.App
{
    internal class App
    {
        private bool continueOp = false;

        public void Generate() {
            Console.WriteLine("Bienvenue sur le generateur de mot de passe N° 1");
          


            mainLoop();
          
        }

        void mainLoop()
        {
            continueOp= true;
            //int passLenght = getPassLength();
            Console.WriteLine("Entrer un mot de passe simple à chifré");
            string passInput = Console.ReadLine()!;

            Console.WriteLine("Chiffrmeent du mot de passe ....");

            while (continueOp)
            {
                if (passInput != null)
                {
                    string gen = generatePass(passInput, getPassLength());
                    Console.Write(gen);
                }

                continueOp = choiceLoop();
            }
        }

        bool choiceLoop() {
            Console.WriteLine("Vous voulez regenerer un autre mot de passe(o/n) :");
            String choice = Console.ReadLine()!;
            
            if(choice != null)
            {
                if(choice == "o")
                {   
                    return true;
                }
            }
            Console.WriteLine("Au revoir");
        return false;
        }

        // get pass length
        // alphabet
        // caracteres aleatoire
        int getPassLength()
        {
            System.Console.WriteLine("Veillez entrer la longuere de votre Mot de passe : ");
            string input = Console.ReadLine()!;

            int passLength = input.ToString().Count();

           if(passLength <= 32 )
            {
                return input.ToString().Length;
            }

            if (passLength < 8 && passLength > 32)
            {
                Console.WriteLine("La longueure du mot dot de passe :");
            }
            return 0;
        }

        // generer un mot de passe 
        String generatePass(string pass, int maxLength)
        {
            char[] alphabets = pass.ToCharArray();

            Random random= new Random();
            string passLeft = "";
            string passMid = "";
            string passRight = "";

            string result = "";

            
            int minInt = alphabets.Length <= maxLength ? alphabets.Length : 8;
            int maxInt = alphabets.Length <= 4 ? alphabets.Length : 4;

            int r1 = random.Next( alphabets.Length - 1 );

            for (int i = 0; i < alphabets.Length; i++)
            {
                int r2 = random.Next(i) / 2; 
                int r3 = r2 + i / 3;

                //Console.WriteLine(alphabets[i]);
                passLeft += alphabets[r2].ToString();
                passMid += alphabets[r1].ToString();
                passRight += alphabets[r2].ToString();

            }

            result = passMid + passRight + passLeft;
              

            Console.WriteLine("Generated  = "+ result);
            return result;
        }
    }

}
