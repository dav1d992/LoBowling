using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.BowlingGames.Any())
            {
                var frames = new List<Frame>
                {
                    new Frame{Id=1, FirstRoll = 1, SecondRoll=4},
                    new Frame{Id=2, FirstRoll = 1, SecondRoll=5},
                    new Frame{Id=3, FirstRoll = 1, SecondRoll=6},
                    new Frame{Id=4, FirstRoll = 1, SecondRoll=7},
                    new Frame{Id=5, FirstRoll = 1, SecondRoll=8},
                    new Frame{Id=6, FirstRoll = 2, SecondRoll=7},
                    new Frame{Id=7, FirstRoll = 2, SecondRoll=6},
                    new Frame{Id=8, FirstRoll = 2, SecondRoll=5},
                    new Frame{Id=9, FirstRoll = 2, SecondRoll=4},
                    new Frame{Id=10, FirstRoll = 2, SecondRoll=3},
                    new Frame{Id=11, FirstRoll = 5, SecondRoll=4},
                    new Frame{Id=12, FirstRoll = 4, SecondRoll=5},
                    new Frame{Id=13, FirstRoll = 3, SecondRoll=6},
                    new Frame{Id=14, FirstRoll = 2, SecondRoll=7},
                    new Frame{Id=15, FirstRoll = 1, SecondRoll=8},
                    new Frame{Id=16, FirstRoll = 2, SecondRoll=7},
                    new Frame{Id=17, FirstRoll = 3, SecondRoll=6},
                    new Frame{Id=18, FirstRoll = 4, SecondRoll=5},
                    new Frame{Id=19, FirstRoll = 5, SecondRoll=4},
                    new Frame{Id=20, FirstRoll = 6, SecondRoll=3},
                };

                var games = new List<BowlingGame>
                {
                    new BowlingGame
                    {
                        PlayerName = "Peter",
                        Score = 70,
                        Frames = new List<Frame>{
                            new Frame{Id=1, FirstRoll = 1, SecondRoll=4},
                            new Frame{Id=2, FirstRoll = 1, SecondRoll=5},
                            new Frame{Id=3, FirstRoll = 1, SecondRoll=6},
                            new Frame{Id=4, FirstRoll = 1, SecondRoll=7},
                            new Frame{Id=5, FirstRoll = 1, SecondRoll=8},
                            new Frame{Id=6, FirstRoll = 2, SecondRoll=7},
                            new Frame{Id=7, FirstRoll = 2, SecondRoll=6},
                            new Frame{Id=8, FirstRoll = 2, SecondRoll=5},
                            new Frame{Id=9, FirstRoll = 2, SecondRoll=4},
                            new Frame{Id=10, FirstRoll = 2, SecondRoll=3},
                        },
                    },
                    new BowlingGame
                    {
                        PlayerName = "Johnny",
                        Score = 90,
                        Frames = new List<Frame>{
                            new Frame{Id=11, FirstRoll = 5, SecondRoll=4},
                            new Frame{Id=12, FirstRoll = 4, SecondRoll=5},
                            new Frame{Id=13, FirstRoll = 3, SecondRoll=6},
                            new Frame{Id=14, FirstRoll = 2, SecondRoll=7},
                            new Frame{Id=15, FirstRoll = 1, SecondRoll=8},
                            new Frame{Id=16, FirstRoll = 2, SecondRoll=7},
                            new Frame{Id=17, FirstRoll = 3, SecondRoll=6},
                            new Frame{Id=18, FirstRoll = 4, SecondRoll=5},
                            new Frame{Id=19, FirstRoll = 5, SecondRoll=4},
                            new Frame{Id=20, FirstRoll = 6, SecondRoll=3},
                        },
                    },
                };
                context.BowlingGames.AddRange(games);
                context.SaveChanges();
            }
        }
    }
}