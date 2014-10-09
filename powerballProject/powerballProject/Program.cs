using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerballProject
{
	 class Program
	 {
		  /*
		   * Ben Kohler
		   * Date start: 9/23/2014
		   * Date complete:
		   * C# Class
		   */

		  /* Unfinished areas.
		   * :221:
		   * :236:
		   * 
		   */

		  /* Required add in's
		   * profile pool
		   *		 create list of people involved.
		   *		 add up users.
		   *		 get money used.
		   *		 if won split money.
		   * 
		   * 
		   */


		  //Public variables
		  static bool resetProfile = false,//Determines if the profile system will be reset
					 annonProfile = false;//Allows the user to use an annonymous profile.
		  public static Profiler profileSys = new Profiler();

		  static void Main(string[] args)
		  {
				//Display revision
				Console.WriteLine("V: 0.1\nRevision Date: 9/23/2014\nAuthor: Benjamin Kohler");

				//pre-checks
				profileSys.checker(); //Preforms checks to see if the profileData.dat file is pre-made.
				profileSys.countProfileNum();
				//lol
				profileUpdate();

		  }
		  static void profileUpdate()
		  {
				char answer;//For single character inputs.




				if(profileSys.ProfileChecker)
				{
					 bool noBreakLoop = true;

					 while(noBreakLoop)
					 {
						  Console.WriteLine("Would you like to open your old profile system? (y/n)");
						  answer = Convert.ToChar(Console.ReadKey().KeyChar);
						  answer = Char.ToLower(answer);
						  Console.Clear();

						  if(answer.Equals('n'))
						  {
								noBreakLoop = resetOrAnnon(noBreakLoop);
						  } else if(answer.Equals('y'))
						  {
								Console.WriteLine("Would you like to....\n1. Use an old account\n2. Create a new account.");
								answer = Convert.ToChar(Console.ReadKey().KeyChar);
								answer = Char.ToLower(answer);
								Console.Clear();
								if(answer.Equals('1'))
								{
									 bool tempWhileBool = true;//Temporary while boolean for repeated questions.
									 while(tempWhileBool)
									 {

										  //Get account number
										  Console.WriteLine("Do you know your account number? (y/n)");
										  answer = Convert.ToChar(Console.ReadKey().KeyChar);
										  answer = Char.ToLower(answer);
										  Console.Clear();

										  if(answer.Equals('y'))
										  {
												searchAccNum();

										  } else if(answer.Equals('n'))
										  {
												searchNonAccNum();
										  }

									 }//End while(tempWhileBool)
								} else if(answer.Equals('2'))
								{
									 addProfile();
								}


								Console.WriteLine("Entering profile...");
								noBreakLoop = false;
						  }//End full if(answer.Equals('n'))

					 }//End While


				} else
				{
					 Console.WriteLine("No profile data found. Will attempt to create one...");
					 profileSys.profileDataCreate(resetProfile);
					 Console.WriteLine("An account is required for a profile setup. Would you like to set up an account?");
					 answer = Convert.ToChar(Console.ReadKey().KeyChar);
					 answer = Char.ToLower(answer);

					 if(answer.Equals('y'))
					 {
						  addProfile();

					 } else if(answer.Equals('n'))
					 {
						  Console.WriteLine("Currently unfinished :221:");
					 }

				}


				if(annonProfile)
				{
					 Console.WriteLine("Annonymous profile is active, but not implemented. :236:");
				}
		  }

		  static void addProfile()
		  {

				string fName = "anon", lName = "emouse", bDay = "12/34/5678";

				Console.WriteLine("Enter your first name");
				fName = Console.ReadLine();

				Console.WriteLine("Enter your last name");
				lName = Console.ReadLine();

				Console.WriteLine("Enter your birthday (in mm/dd/yyyy format)");
				bDay = Console.ReadLine();

				profileSys.addProfile(fName, lName, bDay);
		  }

		  static void searchNonAccNum()
		  {
				string fName = "anon", lName = "emouse", bDay = "12/34/5678";
				bool tempWhileBool = true;
				while(tempWhileBool)//For account information lookup without account number
				{

					 Console.WriteLine("Please enter your first name");
					 fName = Console.ReadLine();
					 Console.Clear();
					 Console.WriteLine("Please enter your last name");
					 lName = Console.ReadLine();
					 Console.Clear();

					 while(tempWhileBool)
					 {
						  Console.WriteLine("Enter your birthday (in mm/dd/yy format, 0's required");
						  bDay = Console.ReadLine();
						  int bDayTest = 0;
						  string[] bDayTemp, seperator = { "/" };
						  if(bDay.Length != 8)
						  {
								Console.WriteLine("Error in the birthday format. Please try again.");
						  } else
						  {
								bDayTemp = bDay.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
								bDayTest = bDayTemp[0].Length;
								if(bDayTest == 2)
								{
									 bDayTest = bDayTemp[1].Length;
									 if(bDayTest == 2)
									 {
										  bDayTest = bDayTemp[2].Length;
										  if(bDayTest == 2)
										  {
												Console.WriteLine("Birthday accepted.");
												tempWhileBool = false;
										  } else
										  {
												Console.WriteLine("Error within your birthday format.");
										  }//End final if-else
									 } else
									 {
										  Console.WriteLine("Error within your birthday format.");
									 }//End semi-final if-else
								} else
								{
									 Console.WriteLine("Error within your birthday format.");
								}//End quarter-final if-else
						  }//End if-else block.

					 }//End tempWhileBool (for birthday input)


				}//End tempWhileBool (for non-account number lookup information)
		  }

		  static void searchAccNum()
		  {
				bool tempWhileBool = true;
				string accNum = "000";
				while(tempWhileBool)//For account information lookup with account number
				{

					 try
					 {
						  Console.WriteLine("Please enter your account number (remember, it is 3 digits long), then press enter.");
						  accNum = Console.ReadLine();
						  Console.Clear();
						  if(accNum.Length != 3)
						  {
								Console.WriteLine("Error. Please make sure you have exactly 3 numbers");
								Console.ReadKey();
								Console.Clear();
						  } else
						  {
								Console.WriteLine("Account number set is accepted. Searching for account.");
								Console.ReadKey();
								Console.Clear();
								tempWhileBool = false;
						  }
					 }//End Try
					 catch(FormatException ex)
					 {
						  Console.WriteLine("Error. The format is incorrect. (press any key to continue)\n{0}", ex.Message);
						  Console.ReadKey();
						  Console.Clear();
					 }//End Catch
				}//End tempWhileBool


		  }

		  static bool resetOrAnnon(bool noBreakLoop)
		  {
				char answer = ' ';
				bool temporaryLoop = true;//Scope should end after next line's while block.
				while(temporaryLoop)
				{

					 Console.WriteLine("Would you like to...\n1. Setup a new profile system.(will delete old profile data)\n2. Use an annonymous profile");
					 answer = Convert.ToChar(Console.ReadKey().KeyChar);
					 Console.Clear();
					 if(answer.Equals('1'))
					 {

						  while(noBreakLoop)
						  {

								Console.WriteLine("Are you absolutely positive you wish to setup the new profile system?\n There is no going back... The previous system will be deleted.(y/n)");
								answer = Convert.ToChar(Console.ReadKey().KeyChar);
								answer = Char.ToLower(answer);
								Console.Clear();
								if(answer.Equals('y'))
								{

									 resetProfile = true;
									 noBreakLoop = false;
									 temporaryLoop = false;

								} else if(answer.Equals('n'))
								{

									 noBreakLoop = false;
									 temporaryLoop = false;

								}

						  }//End While

					 } else if(answer.Equals('2'))
					 {
						  annonProfile = true;
					 } else
						  Console.WriteLine("There was an error within your input. Please try again.");

				}//End temporaryLoop (temporaryLoop should release resources)
				return noBreakLoop;
		  }


	 }
}
