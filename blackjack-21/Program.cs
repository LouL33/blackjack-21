using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_21
{
    class Program
    {   /*
        static int HitOrStand (string message)
        {
            var input = message;
            int number = 0;
            bool wasFormatCorrect = int.TryParse(input, out number);
            while (!wasFormatCorrect)
            {
                Console.WriteLine("enter 1 or 2 fool, not a word");
                input = Console.ReadLine();
                wasFormatCorrect = int.TryParse(input, out number);
            }
            return number;
        }
        */
        static int GetHandTotal(List<Card> hand)
        {
            var total = 0;
            foreach (var card in hand)
            {
                total += card.GetCardValue();
               
            }
            return total;
        }

        static void Displayhand(List<Card> hand)
        {
            foreach (var card in hand)
            {
                Console.WriteLine(card);
            }
        }

        static void Main(string[] args)
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }
            //sort the deck. NOTICE that the variable 'deck' is unchanged, but 'randomDeck' is the actual sorted deck.
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            // greeding message
            var hitOrStand = 0;

            // making both hands
            //dislay the total
            // ask the user if they want to hit or stay
            // while the user wants to hit:
            // deal user a card
            // dealers turn
            var playerHand = new List<Card>();


            var tempcard = randomDeck[0];
            playerHand.Add(tempcard);
            randomDeck.RemoveAt(0);

            tempcard = randomDeck[0];
            playerHand.Add(tempcard);
            randomDeck.RemoveAt(0);

            Displayhand(playerHand);

            
            var dealerHand = new List<Card>();

            tempcard = randomDeck[0];
            dealerHand.Add(tempcard);
            randomDeck.RemoveAt(0);

            tempcard = randomDeck[0];
            dealerHand.Add(tempcard);
            randomDeck.RemoveAt(0);

            Displayhand(dealerHand);


           // Console.WriteLine("would you like to stay or hit? enter 1 for hit or 2 for stay");
            //hitOrStand = HitOrStand(Console.ReadLine());

            bool startgame = false;
            string hit;
            string stay;
            int playershandzzzz;

            //Console.WriteLine("would you like to stay or hit? (type hit/stay)");
            //hit = Console.ReadLine();

            playerHand[0].GetCardValue();
            playerHand[1].GetCardValue();



        }
    }
}
