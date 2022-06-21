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

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Id = 1,
                        DisplayName = "Bob",
                    },
                    new User
                    {
                        Id = 2,
                        DisplayName = "Jane",
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.BowlingGames.Any())
            {
                var games = new List<BowlingGame>
                {
                    new BowlingGame
                    {
                        Score = 70,
                        Frames = new List<Frame>{
                            new Frame{UserId=1, FrameNumber = 1, FirstRoll = 1, SecondRoll=4},
                            new Frame{UserId=1, FrameNumber = 2, FirstRoll = 1, SecondRoll=5},
                            new Frame{UserId=1, FrameNumber = 3, FirstRoll = 1, SecondRoll=6},
                            new Frame{UserId=1, FrameNumber = 4, FirstRoll = 1, SecondRoll=7},
                            new Frame{UserId=1, FrameNumber = 5, FirstRoll = 1, SecondRoll=8},
                            new Frame{UserId=1, FrameNumber = 6, FirstRoll = 2, SecondRoll=7},
                            new Frame{UserId=1, FrameNumber = 7, FirstRoll = 2, SecondRoll=6},
                            new Frame{UserId=1, FrameNumber = 8, FirstRoll = 2, SecondRoll=5},
                            new Frame{UserId=1, FrameNumber = 9, FirstRoll = 2, SecondRoll=4},
                            new Frame{UserId=1, FrameNumber = 10, FirstRoll = 2, SecondRoll=3},
                        },
                    },
                    new BowlingGame
                    {
                        Score = 90,
                        Frames = new List<Frame>{
                            new Frame{UserId=2, FrameNumber = 1, FirstRoll = 5, SecondRoll=4},
                            new Frame{UserId=2, FrameNumber = 2, FirstRoll = 4, SecondRoll=5},
                            new Frame{UserId=2, FrameNumber = 3, FirstRoll = 3, SecondRoll=6},
                            new Frame{UserId=2, FrameNumber = 4, FirstRoll = 2, SecondRoll=7},
                            new Frame{UserId=2, FrameNumber = 5, FirstRoll = 1, SecondRoll=8},
                            new Frame{UserId=2, FrameNumber = 6, FirstRoll = 2, SecondRoll=7},
                            new Frame{UserId=2, FrameNumber = 7, FirstRoll = 3, SecondRoll=6},
                            new Frame{UserId=2, FrameNumber = 8, FirstRoll = 4, SecondRoll=5},
                            new Frame{UserId=2, FrameNumber = 9, FirstRoll = 5, SecondRoll=4},
                            new Frame{UserId=2, FrameNumber = 10, FirstRoll = 6, SecondRoll=3},
                        },
                    },
                };

                context.BowlingGames.AddRange(games);
                context.SaveChanges();
            }
        }
    }
}