using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_21
{
    class Program
    {   
        static List<Card> RandomDeck = new List<Card>();

        static List<Card> AddCardsTo(List<Card> hand)
        {
            hand.Add(RandomDeck[0]);
            RandomDeck.RemoveAt(0);
            return hand;
        }

        static void DisplayHand(List<Card> hand)
        {
            foreach (var card in hand)
            {
                Console.WriteLine(card);
            }
        }

        static void DisplayHandTotal(List<Card> hand)
        {
            var total = 0;
            foreach (var card in hand)
            {
                total += card.GetCardValue();
            }
            Console.WriteLine($"Your total is : {total}");
        }

        static int GetHandTotal(List<Card> hand)
        {
            var total = 0;
            foreach (var card in hand)
            {
                total += card.GetCardValue();
            }
            return total;
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
            RandomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            var playerHand = new List<Card>();
            var dealerHand = new List<Card>();

            playerHand = AddCardsTo(playerHand);
            playerHand = AddCardsTo(playerHand);
            dealerHand = AddCardsTo(dealerHand);
            dealerHand = AddCardsTo(dealerHand);

            //DisplayHand( new Card[9]);***************************
            // DisplayHand(dealerHand.Take(1));


            //DisplayHand(playerHand);
            Console.WriteLine("Dealers hand:");
            Console.WriteLine(dealerHand[0]);

            var stilPlaying = true;

            while (stilPlaying && GetHandTotal(playerHand) < 21)
            {
                Console.WriteLine("your hand");
                DisplayHand(playerHand);
                DisplayHandTotal(playerHand);
                Console.WriteLine();
                Console.WriteLine("[H]it or [S]tay");
                var input = Console.ReadLine();

                if (input.ToLower() == "h")
                {
                    playerHand = AddCardsTo(playerHand);
                }
                else if (input.ToLower() == "s")
                {
                    stilPlaying = false;
                }


            }
            Console.WriteLine($"you are done play with a {GetHandTotal(playerHand)}");



            Console.WriteLine("Dealer turn");
            DisplayHand(dealerHand);
            DisplayHandTotal(dealerHand);
            while (GetHandTotal(dealerHand) <= 16)
            {
                dealerHand = AddCardsTo(dealerHand);
                Console.WriteLine("Dealers New Hand");
                DisplayHand(dealerHand);
            }
            Console.WriteLine();

            Console.WriteLine($"Dealer has {GetHandTotal(dealerHand)}");

            Console.WriteLine($"player has {GetHandTotal(playerHand)}");





        }
    }
}
