using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace goingToBoston {
	
	class Player { // Methods relating to the players
	
		public static int player1Score;
		public static int player2Score;
		
		public static void changeScore(int player, int score) // Changes the score
		{
			if (player == 1)
				player1Score = score;
			if (player == 2)
				player2Score = score;
		}
		public static int getScore(int player) // Gets the score
		{
			if (player == 1)
				return player1Score; // Returns score
			else if (player == 2)
				return player2Score;
			else
				return 0; // Returns 0 when input is invalid 
		}
	}
	
	class Dice { // Dice function
		public static int Roll(){
			int number = new Random().Next(1, 6); // Rolls a number between 1 and 6
			return(number); // Returns result
		}
	}

	
	class Game { // Methods relating specifically to the game
		
		static void Main(string[] args)
		{
			Console.WriteLine("Choose a gamemode: 1)Match Play or 2)Score Play ");
			Console.WriteLine("Match Play: Players win a point each round. The first to 5 wins the game.");
			Console.WriteLine("Score Play: Players add up their total after each round. The player with the highest score after 5 rounds wins the game.");
			int gamemode = Convert.ToInt32(Console.ReadLine()); // Converts input to integer
			if (gamemode == 1)
				matchPlay(); // Calls match play
			else if (gamemode == 2)
				scorePlay(); // Calls score play
			else
				Console.WriteLine("Enter a valid number");
			return;
		}
		
		static void matchPlay(){
			Console.Clear(); // Clears console
			Console.WriteLine("You've chosen Match Play");
			
			int roll; // temporary dice holder
			bool game = true; // controls the loop
			int player = 1; // controls player turn
			int turn = 3; // controls which turn
			int player1TempScore; // holds score temporarily
			int player2TempScore;
			
			Player.changeScore(1,0);
			Player.changeScore(2,0);
			
			while (game) // Loop
			{
				// player one
				Console.Clear(); // clears
				roll = 0; // sets roll to 0
				if (player == 3) // stops player overflowing
					player = 1;
				Console.WriteLine($"Player {player}'s turn \nscore {Player.getScore(player)}\n");
				Console.WriteLine("Hit the enter key to roll the dice!"); // Requests input to roll dice
				Console.ReadLine();
				
				if (turn <= 1) // roll one die
				{
					Console.WriteLine("Rolling one die");
					roll = Dice.Roll();
				}
				else
				{
					Console.WriteLine($"Rolling {turn} dice");
					for (int i = 1; i < turn; i++)
						roll = roll + Dice.Roll();
				}
				
				Console.WriteLine($"You rolled a {roll}");
				player1TempScore = roll;
				player++;
				System.Threading.Thread.Sleep(2000); // pauses
				
				// player two
				Console.Clear();
				roll = 0; // sets roll to 0
				Console.WriteLine($"Player {player}'s turn \nscore {Player.getScore(player)}\n");
				Console.WriteLine("Hit the enter key to roll the dice!"); // Requests input to roll dice
				Console.ReadLine();
				
				if (turn <= 1) // roll one die
				{
					Console.WriteLine("Rolling one die");
					roll = Dice.Roll();
				}
				else
				{
					Console.WriteLine($"Rolling {turn} dice");
					for (int i = 1; i < turn; i++)
						roll = roll + Dice.Roll();
				}
				
				Console.WriteLine($"You rolled a {roll}");
				player2TempScore = roll;
				player++;
				System.Threading.Thread.Sleep(2000); // pauses

				turn--;
				if (player1TempScore > player2TempScore)
				{
					Player.changeScore(1, Player.getScore(1) + 1);
					Console.WriteLine($"Player 1 wins the round \n({player1TempScore}/{player2TempScore})");
					Console.WriteLine($"Player 1 has {Player.getScore(1)} points\nplayer 2 has {Player.getScore(2)} points");
				}
				else if (player2TempScore > player1TempScore)
				{
					Player.changeScore(2, Player.getScore(1) + 1);
					Console.WriteLine($"Player 2 wins the round \n({player1TempScore}/{player2TempScore})");
					Console.WriteLine($"Player 1 has {Player.getScore(1)} points\nplayer 2 has {Player.getScore(2)} points");
				}
				else if (player1TempScore == player2TempScore)
				{
				Console.WriteLine($"It was a draw! \n({player1TempScore}/{player2TempScore})");
				Console.WriteLine($"Player 1 has {Player.getScore(1)} points\nPlayer 2 has {Player.getScore(2)} points");
				}
				System.Threading.Thread.Sleep(2000);
				
				// checks winner
				if (Player.getScore(1) == 5 && Player.getScore(2) == 5) // draw
				{
					Console.WriteLine("You drew!");
					Console.WriteLine($"You both got {Player.getScore(1)}");
					return;
				}
				else if (Player.getScore(1) == 5) // player 1 won 5
				{
					Console.WriteLine("Congratulations player 1, you have won!");
					Console.WriteLine($"Player 1 got {Player.getScore(1)}, Player 2 got {Player.getScore(2)}");
					return;
				}
				else if (Player.getScore(2) == 5) // player 2 won 5
				{
					Console.WriteLine("Congratulations player 2, you have won!");
					Console.WriteLine($"Player 1 got {Player.getScore(1)}, Player 2 got {Player.getScore(2)}");
					return;
				}
				Console.WriteLine("Hit enter to continue");
				Console.ReadLine();
			}
		}
					
		static void scorePlay(){
			Console.Clear(); // Clears console
			Console.WriteLine("You've chosen Score Play");
			
			int dice = 0; // Temporary dice value holder
			int roll = 0; // A temp value holder that holds sum
			bool game = true; // Controls the loop
			int player = 1; // Controls which player's turn
			int turn = 1; // Controls which turn
			int player1Dice = 3; // Dice counter
			int player2Dice = 3;
			
			Player.changeScore(1,0);
			Player.changeScore(2,0);
	
			while (game) // Loop
			{
				Console.Clear(); // Clears console
				if (player == 3) // Prevents player variable overflowing
					player = 1;
				Console.WriteLine($"Player {player}'s turn\nscore {Player.getScore(player)}\nturn {turn}");
				Console.WriteLine("Hit the enter key to roll the dice!"); // Requests input to roll the dice
				Console.ReadLine();
				if (player == 1) // Sets dice to player 1
					dice = player1Dice;
				if (player == 2) // Sets dice to player 2
					dice = player2Dice;
					
				if (dice <= 1) // Roll one dice
				{
					Console.WriteLine("Rolling 1 die");
					dice = Dice.Roll(); // Calls dice method
				}
				else
				{
					Console.WriteLine($"Rolling {dice} dice"); // Shows number of dice
					for (int i = 1; i < dice; i++) // Loops
						roll = roll + Dice.Roll();
				}
				Console.WriteLine($"You've rolled a {roll}"); // Shows roll
				Player.changeScore(player, (Player.getScore(player) + roll)); // sets score
				if (player == 1)
					player1Dice--;
				if (player == 2)
					player2Dice--;
				if (player == 2)
					turn++;
				player++;
				System.Threading.Thread.Sleep(2000); // pause
				
				if (turn == 6) // ends game
				{
					Console.Clear(); // clears
					if (Player.getScore(1) > Player.getScore(2)) // compares scores
					{	Console.WriteLine($"Congratulations Player 1, you won with {Player.getScore(1)} points");
					}
					else if (Player.getScore(2) > Player.getScore(1))
					{	Console.WriteLine($"Congratulations Player 2, you won with {Player.getScore(2)} points");
					}
					else
					{	Console.WriteLine("You drew!");
					}
					System.Threading.Thread.Sleep(2000); // pause
					return; // ends
				}
			}
				

			}
			
		}
	}

		
				
			
			
			
			
		
				
		
	
	

	

	

	
	
	
	
	
	
	
	
	
	
	

	

		

		