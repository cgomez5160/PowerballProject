using System;
using System.IO;

namespace powerballProject
{
	 public class Profiler
	 {
		  private const string directoryCheck = @"data";
		  private const string logPath = @"data\\log.log";
		  private const string profilePath = @"data\\profileData.dat";

		  private bool profileChecker;
		  private bool logChecker;

		  private int accNumInt = 0;
		  private string newAccNumLiteral = "000";
		  private DateTime time = DateTime.Now;

		  private ProfileRecord[] record;

		  //return items
		  public bool ProfileChecker
		  {
				get
				{
					 return profileChecker;
				}
		  }
		  public bool LogChecker
		  {
				get
				{
					 return logChecker;
				}
		  }

		  //for writing to profileData.dat
		  public void profileDataCreate(bool resetProfile)
		  {
				try
				{
					 if(!Directory.Exists(directoryCheck))
					 {
						  DirectoryInfo di = Directory.CreateDirectory(directoryCheck);
					 }
					 if(logChecker.Equals(false))
					 {
						  File.Create(logPath).Dispose();
					 }
					 //Start log stream
					 try
					 {
						  StreamWriter log = File.AppendText(logPath);

						  if(resetProfile)
						  {
								time = DateTime.Now;// gets current time
								log.WriteLine("{0}: resetProfile engaged. Attempting deletion and creation...", time);//Writes to log.

								File.Delete(profilePath);
								File.Create(profilePath).Dispose();//Removes File.Create from access of file after creation
								time = DateTime.Now;
								log.WriteLine("{0}: File creation complete.", time);

						  } else if(profileChecker.Equals(false))
						  {
								time = DateTime.Now;
								log.WriteLine("{0}: Profile does exist. Attempting creation...", time);
								File.Create(profilePath).Dispose();
								time = DateTime.Now;
								log.WriteLine("{0}: Profile creation complete", time);
						  }

						  log.Close();
					 } catch(Exception ex)
					 {
						  Console.WriteLine("Error.\n{0}", ex.Message);
						  throw;
					 }
				} catch(Exception ex)
				{
					 Console.WriteLine("Unhandled Exception.\n{0}", ex.Message);
					 Console.ReadKey();
				}

		  }

		  public void addProfile(string fName, string lName, string bDay)
		  {
				//Create objects
				DateTime time = DateTime.Now;
				StreamWriter log = new StreamWriter(logPath);
				StreamWriter profile = new StreamWriter(profilePath);

				profile.WriteLine("{0}-{1}-{2}-{3}-", newAccNumLiteral, fName, lName, bDay);

				//End objects.

				log.Close();
				profile.Close();
		  }

		  public void countProfileNum()
		  {
				try
				{
					 using(StreamWriter log = new StreamWriter(logPath))
						  log.WriteLine("{0}: Counting profiles...", time);

					 using(StreamReader profileRead = new StreamReader(profilePath))
					 {
						  accNumInt = 0;
						  while(profileRead.ReadLine() != null)
						  {
								accNumInt++;
						  }
					 }
					 record = new ProfileRecord[accNumInt];

				} catch(Exception ex)
				{
					 time = DateTime.Now;
					 using(StreamWriter logCatch = new StreamWriter(logPath))
						  logCatch.WriteLine("{0}Error in countProfileNum: {1}", time, ex.Message);
				}
		  }



		  //Checks
		  //Check profile
		  public void checkProfile()
		  {
				try
				{
					 if(!File.Exists(profilePath))
						  profileChecker = false;
					 else
						  profileChecker = true;
				} catch(Exception ex)
				{
					 Console.WriteLine("Error on checkProfile. Please report the error to the author. \nError code:{0}", ex.Message);
				}
		  }

		  //Check log
		  public void checkLog()
		  {

				try
				{
					 if(!File.Exists(logPath))
						  logChecker = false;
					 else
						  logChecker = true;
				} catch(Exception ex)
				{
					 Console.WriteLine("Error on checkLog. Please report the error to the author.\nError code:{0}", ex.Message);
				}

		  }

		  //Run checks
		  public void checker()
		  {

				checkProfile();
				checkLog();
				profileDataCreate(false);

		  }
		  //End of checks
	 }
}