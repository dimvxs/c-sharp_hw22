// See https://aka.ms/new-console-template for more information
using hw;


CreditCard card = new CreditCard();

    card.Evnt += (msg) => 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Событие: " + msg);
                Console.ResetColor();
            };

  


card.Print();
card.Put(100);
card.Withdraw(100);

