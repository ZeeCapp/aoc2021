using System.IO;
using System;
using System.Collections.Generic;

namespace _4_1
{
    public class CardPoint
    {
        public int Value { get; set; } = 0;
        public bool Marked { get; set; } = false;
    }

    public class Card
    {
        public CardPoint[][] Points { get; set; }
    }

    public class Bingo
    {
        public int[] PuzzleNumbers { get; set; }
        public List<Card> Cards { get; set; }

        public async void InitiateBingo(string initDataUrl)
        {
            string[] fileRows = (await File.ReadAllTextAsync(initDataUrl)).Split("\n");

            this.PuzzleNumbers = Array.ConvertAll(fileRows[0].Split(","), s => int.Parse(s));

            for(int i = 2; i < fileRows.Length; i+=6)
            {
                string[] cardRows = fileRows.AsSpan(i, 5).ToArray();
                int[][] convertedCardRows = {};

                for(int row = 0; row < cardRows.Length; row++)
                {
                    convertedCardRows[row] = Array.ConvertAll(cardRows[row].Split(" "), s => int.Parse(s));
                }


                CardPoint[][] points = new CardPoint[][]{};
                for(int y = 0; y < convertedCardRows.Length; y++)
                {
                    for(int x = 0; x < convertedCardRows[y].Length; x++)
                    {
                        points[x][y] = new CardPoint{ Marked = false, Value = convertedCardRows[x][y]};
                    }
                }

                this.Cards.Add(new Card{Points = points});
            }
        }
    }
}