using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project41.HomeWork1
{
    public enum Speed { Regular, Turbo, SuperTurbo };

    public class Tournament : IComparable<Tournament>
    {
        private double buy_in;
        private double fee;

        public int Id { get; set; }

        public double Buy_in
        {
            get
            {
                return Math.Round(buy_in, 2);
            }
            set
            {
                buy_in = value;
            }
        }

        public double Fee
        {
            get
            {
                return Math.Round(fee, 2);
            }
            set
            {
                fee = value;
            }
        }

        public int Place { get; set; }

        public int Players { get; set; }

        public double Earnings { get; set; }

        public DateTime Started { get; set; }

        public DateTime? Finished { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return Finished == null 
                    ? DateTime.Now - Started
                    : (DateTime)Finished - Started;
            }
        }

        public Speed Speed { get; set; }

        public string Type
        {
            get
            {
                return string.Format("Players: {0}, Speed: {1}, Buy-in: ${2:F2} + ${3:F2}",
                    Players, Speed, Buy_in, Fee);
            }
        }

        public bool SnG { get; set; }

        public List<Game> Games { get; set; }

        public Tournament()
        {
            Games = new List<Game>();
        }


        public string ToLongString()
        {
            string started = Started.ToString("dd'.'MM'.'yyyy HH':'mm");
            string duration = Duration.ToString("h':'mm");

            string tournament = String.Format(
                  "Started: {0}\nDuration: {1}\nType: {2}\n"
                + "Buy-in: ${3:F2}\nPlace: {4}\nEarnings: ${5:F2}",
                started, duration,
                Type, Buy_in, Place, Earnings);

            return tournament;
        }

        public int CompareTo(Tournament other)
        {
            return Started.CompareTo(other.Started);
        }

        public static Tournament FromPokerTracker4File(FileInfo summary)
        {
            Tournament tournament = new Tournament();
            using (StreamReader reader = new StreamReader(summary.FullName, Encoding.Default))
            {
                string[] rows = reader.ReadToEnd().Split('\n', '\r');

                ///
                /// Id
                /// 

                // "Tournament #: 105970676"
                string line = FindRow(rows, "Tournament #: ");
                tournament.Id = Convert.ToInt32(line.Substring("Tournament #: ".Length));

                ///
                /// Buy-in
                ///

                // "Buyin: $0.85"
                line = FindRow(rows, "Buyin: ");

                // . => ,
                tournament.Buy_in = Convert.ToDouble(line.Substring("Buyin: $".Length).Replace('.', ','));

                ///
                /// Fee
                ///

                // "Fee: $0.15"
                line = FindRow(rows, "Fee: ");

                // . => ,
                tournament.Fee = Convert.ToDouble(line.Substring("Fee: $".Length).Replace('.', ','));

                ///
                /// Place, Earnings
                /// 

                // Place: 6, Player: vov4uk33, Won: $0.00,"
                string playerName = "vov4uk33";

                line = FindRow(rows, ", Player: " + playerName + ", Won: $");

                line = line.Substring("Place: ".Length, line.IndexOf(',') - "Place: ".Length);
                tournament.Place = Convert.ToInt32(line);

                line = FindRow(rows, ", Player: " + playerName + ", Won: $");
                line = line.Substring(line.IndexOf('$') + 1);
                // . => ,
                tournament.Earnings = Convert.ToDouble(line.Substring(0, line.IndexOf(',')).Replace('.', ','));

                ///
                /// Players
                /// 

                // "Players: 6"
                line = FindRow(rows, "Players: ");
                tournament.Players = Convert.ToInt32(line.Substring("Players: ".Length));


                ///
                /// Started
                /// 

                line = FindRow(rows, "Started: ");

                string[] started = line.Substring("Started: ".Length).Split('/', ' ', ':');
                tournament.Started = new DateTime(
                    Convert.ToInt32(started[0]),  // year
                    Convert.ToInt32(started[1]),  // month
                    Convert.ToInt32(started[2]),  // day
                    Convert.ToInt32(started[3]),  // hours
                    Convert.ToInt32(started[4]),  // minutes
                    Convert.ToInt32(started[5])); // seconds

                ///
                /// Finished
                /// 

                line = FindRow(rows, "Finished: ");
                string[] endStr = line.Substring("Finished: ".Length).Split('/', ' ', ':');
                tournament.Finished = new DateTime(
                    Convert.ToInt32(endStr[0]),  // year
                    Convert.ToInt32(endStr[1]),  // month
                    Convert.ToInt32(endStr[2]),  // day
                    Convert.ToInt32(endStr[3]),  // hours
                    Convert.ToInt32(endStr[4]),  // minutes
                    Convert.ToInt32(endStr[5])); // seconds

                ///
                /// Speed
                /// 

                line = FindRow(rows, "Table Type: ");

                if (line.Contains("Super-Turbo"))
                {
                    tournament.Speed = Speed.SuperTurbo;
                }
                else if (line.Contains("Turbo"))
                {
                    tournament.Speed = Speed.Turbo;
                }
                else
                {
                    tournament.Speed = Speed.Regular;
                }

                ///
                /// SnG
                /// 

                tournament.SnG = line.Contains("SNG");
            }

            return tournament;
        }

        public static Tournament FromPokerTracker4Files(FileInfo games, FileInfo summary)
        {
            return null;
        }

        public static Tournament From888PokerFiles(FileInfo games, FileInfo summary,
            bool handHistory = false)
        {
            if (!handHistory)
            {
                Tournament tournament = new Tournament();

                using (StreamReader summaryReader = new StreamReader(summary.FullName, Encoding.Default))
                {
                    string[] rows = summaryReader.ReadToEnd().Split('\n', '\r');

                    ///
                    /// Id
                    ///

                    // "Tournament ID: 105970676"
                    string id = FindRow(rows, "Tournament ID: ").Substring("Tournament ID: ".Length);
                    tournament.Id = Convert.ToInt32(id);

                    ///
                    /// Buy-in, Fee
                    ///

                    // "Buy-In: $0.85 + $0.15"
                    string line = FindRow(rows, "Buy-In: ").Substring("Buy-In: ".Length);
                    if (line == "Free")
                    {
                        tournament.Buy_in = 0.00;
                        tournament.Fee = 0.00;
                    }
                    else
                    {
                        string[] buyin = line.Split(' ', '+', '$');
                        tournament.Buy_in = Convert.ToDouble(buyin[1].Replace('.', ','));
                        tournament.Fee = Convert.ToDouble(buyin[5].Replace('.', ','));
                    }
                    ///
                    /// Place, Players, Earnings
                    ///

                    // "vov4uk33 finished 2/6 and won $1.62"
                    // "vov4uk33 finished 6/6"
                    string playerName = "vov4uk33";
                    line = FindRow(rows, playerName + " finished ");
                    line = line.Substring((playerName + " finished ").Length);

                    // "2/6 and won $1.62"
                    // "6/6"
                    string[] temp = line.Split(' ');
                    string[] posAndPlayers = temp[0].Split('/');
                    tournament.Place = Convert.ToInt32(posAndPlayers[0]);
                    tournament.Players = Convert.ToInt32(posAndPlayers[1]);

                    if (temp.Length == 4)
                    {
                        tournament.Earnings = Convert.ToDouble(
                            temp[3].Substring(1).Replace('.', ','));
                    }
                    else
                    {
                        tournament.Earnings = 0.00;
                    }
                }


                using (StreamReader gamesReader = new StreamReader(games.FullName, Encoding.Default))
                {
                    string[] rows = gamesReader.ReadToEnd().Split('\n', '\r');

                    ///
                    /// Started
                    ///

                    // First game
                    // "$10/$20 Blinds No Limit Holdem - *** 04 07 2017 19:40:49"
                    string row = FindRow(rows, " Blinds No Limit Holdem - *** ");
                    row = row.Substring(row.IndexOf("***") + "*** ".Length);

                    // "04 07 2017 19:40:49"
                    string[] started = row.Split(' ', ':');
                    tournament.Started = new DateTime(
                        Convert.ToInt32(started[2]),  // year
                        Convert.ToInt32(started[1]),  // month
                        Convert.ToInt32(started[0]),  // day
                        Convert.ToInt32(started[3]),  // hours
                        Convert.ToInt32(started[4]),  // minutes
                        Convert.ToInt32(started[5])); // seconds

                    ///
                    /// Finished
                    ///

                    // Last game
                    // "$50/$100 Blinds No Limit Holdem - *** 04 07 2017 20:06:30"
                    row = FindRow(rows.Reverse().ToArray(), " Blinds No Limit Holdem - *** ");
                    row = row.Substring(row.IndexOf("***") + "*** ".Length);

                    // "04 07 2017 20:06:30"
                    string[] finished = row.Split(' ', ':');
                    tournament.Finished = new DateTime(
                        Convert.ToInt32(finished[2]),  // year
                        Convert.ToInt32(finished[1]),  // month
                        Convert.ToInt32(finished[0]),  // day
                        Convert.ToInt32(finished[3]),  // hours
                        Convert.ToInt32(finished[4]),  // minutes
                        Convert.ToInt32(finished[5])); // seconds

                    ///
                    /// Speed
                    ///

                    if (summary.Name.Contains("Super Turbo"))
                    {
                        tournament.Speed = Speed.SuperTurbo;
                    }
                    else if (summary.Name.Contains("Turbo"))
                    {
                        tournament.Speed = Speed.Turbo;
                    }
                    else
                    {
                        tournament.Speed = Speed.Regular;
                    }

                }

                ///
                /// SnG
                /// 

                tournament.SnG = summary.Name.Contains("Sit & Go");

                return tournament;
            }
            else
            {
                return null;
            }
        }

        public static List<Game> GamesFrom888PokerFile(FileInfo games)
        {
            List<Game> listOfGames = new List<Game>();
            using (StreamReader reader = new StreamReader(games.FullName, Encoding.Default))
            {
                string[] Games = reader.ReadToEnd().Replace("\n\r\n\r\n\r", "%").Split('%');

                foreach (string game in Games)
                {
                    Game newGame = new Game();
                    if (game.Contains("Game No : "))
                    {
                        string[] rows = game.Split('\n', '\r');

                        ///
                        /// Id
                        ///

                        string gameNo = FindRow(rows, "Game No : ");
                        gameNo = gameNo.Substring("Game No : ".Length);

                        newGame.Id = Convert.ToInt32(gameNo);

                        ///
                        /// SmallBlind, Started
                        ///

                        // "$105/$210 Blinds No Limit Holdem - *** 14 07 2017 20:00:24"
                        string row = FindRow(rows, "Blinds No Limit Holdem");

                        // "$105/$210"
                        string blinds = row.Split(' ')[0].Replace(",", "");

                        // "105"
                        blinds = blinds.Substring(1, blinds.IndexOf('/') - 1);

                        newGame.SmallBlind = Convert.ToInt64(blinds);

                        // "14 07 2017 20:00:24"
                        string started = row.Substring(row.IndexOf("*** ") + "*** ".Length);
                        string[] start = started.Split(' ', ':');

                        newGame.Started = new DateTime(
                            Convert.ToInt32(start[2]),  // year
                            Convert.ToInt32(start[1]),  // month
                            Convert.ToInt32(start[0]),  // day
                            Convert.ToInt32(start[3]),  // hours
                            Convert.ToInt32(start[4]),  // minutes
                            Convert.ToInt32(start[5])); // seconds

                        ///
                        /// TotalNumberOfPlayers
                        /// 
                        
                        string players = FindRow(rows, "Total number of players : ");
                        players = players.Substring("Total number of players : ".Length);
                        newGame.TotalNumberOfPlayers = Convert.ToInt32(players);

                        ///
                        /// Players
                        ///

                        for (int i = 1; i < 11; i++)
                        {
                            string player = FindRow(rows, "Seat " + i.ToString() + ":");
                            if (player != null)
                            {
                                // "Seat 1: igrok2play ( $1,655 )"
                                // "Seat 4: vov4uk33 ( $1,345 )"

                                // "igrok2play ( $1,655 )"
                                // "vov4uk33 ( $1,345 )"
                                player = player.Substring(("Seat " + i.ToString() + ": ").Length);


                                // 0: "igrok2play"
                                // 1: "("
                                // 2: ""
                                // 3: "1,345"
                                // ...
                                string[] playerInfo = null;

                                playerInfo = player.Split(' ', '$');

                                Player newPlayer = new Player();

                                ///
                                /// Name
                                ///

                                newPlayer.Name = playerInfo[0];

                                ///
                                /// Chips
                                ///

                                string chips = playerInfo[3].Replace(",", "");
                                newPlayer.Chips = Convert.ToInt64(chips);

                                ///
                                /// Seat
                                /// 

                                newPlayer.Seat = i;

                                newGame.Players.Add(newPlayer);
                            }
                        }
                        ///
                        /// Ante
                        /// 

                        // "igrok2play posts ante [$15]"
                        row = FindRow(rows, " posts ante ");

                        if (row == null)
                        {
                            newGame.Ante = 0;
                        }
                        else
                        {
                            // "[$15]"
                            row = row.Substring(row.IndexOf('['));

                            // "15"
                            row = row.Replace("$", "").Replace("[", "").Replace("]", "").Replace(",", "");

                            newGame.Ante = Convert.ToInt64(row);
                        }

                        listOfGames.Add(newGame);
                    }
                }

            }
            return listOfGames;
        }


        public static Tournament From888PokerFile(FileInfo games)
        {
            Tournament tournament = new Tournament();

            string fName = games.Name;

            ///
            /// Id
            ///

            // "888poker20170714 Sit & Go $0.35 + $0.05 6 Handed Super Turbo (106374206) No Limit Holdem.txt"
            string id = fName.Substring(fName.IndexOf('(') + 1);

            // "106374206) No Limit Holdem.txt"
            id = id.Substring(0, id.IndexOf(')'));
            tournament.Id = Convert.ToInt32(id);

            ///
            /// Buy-in, Fee
            ///

            if (fName.Contains("Free"))
            {
                tournament.Buy_in = 0.00;
                tournament.Fee = 0.00;
            }
            else
            {
                // "888poker20170714 Sit & Go $0.35 + $0.05 6 Handed Super Turbo (106374206) No Limit Holdem.txt"
                // "888poker20170624 Tournament Free $4,000 Tutankhamun Tournament (105430041) No Limit Holdem.txt"
                // "888poker20170711 Tournament $0.90 + $0.10 Step 3 to WSOP & Major Tournaments (106258137) No Limit Holdem.txt"
                string buyin = fName.Substring(fName.IndexOf('$') + 1);

                // "0.35 + $0.05 6 Handed Super Turbo (106374206) No Limit Holdem.txt"
                string[] buy_in = buyin.Split(' ', '$');
                // 0: "0.35"
                // 1: "+"
                // 2: ""
                // 3: "0.05"
                // ...

                tournament.Buy_in = Convert.ToDouble(buy_in[0].Replace('.', ','));
                tournament.Fee = Convert.ToDouble(buy_in[3].Replace('.', ','));
            }

            ///
            /// SnG
            /// 

            tournament.SnG = fName.Contains("Sit & Go");

            ///
            /// Earnings
            ///

            tournament.Earnings = 0.00;

            ///
            /// Place
            ///

            tournament.Place = 0;

            ///
            /// Games
            ///

            tournament.Games = GamesFrom888PokerFile(games);


            ///
            /// Players
            /// 

            if (tournament.SnG)
            {
                tournament.Players = tournament.Games.OrderBy(g => g.Started).First().TotalNumberOfPlayers;
            }
            else
            {
                tournament.Players = 0;
            }

            ///
            /// Started
            ///

            tournament.Started = tournament.Games.OrderBy(g => g.Started).First().Started;

            ///
            /// Finished
            ///

            tournament.Finished = null;

            ///
            /// Speed
            ///

            if (games.Name.Contains("Super Turbo"))
            {
                tournament.Speed = Speed.SuperTurbo;
            }
            else if (games.Name.Contains("Turbo"))
            {
                tournament.Speed = Speed.Turbo;
            }
            else
            {
                tournament.Speed = Speed.Regular;
            }

            return tournament;
        }

        private static string FindRow(string[] arr, string subString)
        {
            foreach (string str in arr)
            {
                if (str.Contains(subString))
                {
                    return str;
                }
            }

            return null;
        }
    }

    public class Game
    {
        public int Id { get; set; }
        public DateTime Started { get; set; }
        public int TournamentId { get; set; }
        public int TotalNumberOfPlayers { get; set; }
        public long SmallBlind { get; set; }
        public long Ante { get; set; }

        public List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public long Chips { get; set; }
        public int Seat { get; set; }
    }
}

