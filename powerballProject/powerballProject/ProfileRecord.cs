using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerballProject
{
	 public class ProfileRecord
	 {
		  public string AccountNumber
		  {
				get;
				set;
		  }
		  public string FirstName
		  {
				get;
				set;
		  }
		  public string LastName
		  {
				get;
				set;
		  }
		  public string BirthDate
		  {
				get;
				set;
		  }
		  public string PowerballNumbers
		  {
				get;
				set;
		  }

		  public ProfileRecord()
		  { /* Default constructor */
		  }

		  public ProfileRecord(string data)
		  {
				this.LoadData(data);
		  }

		  public void LoadData(string data)
		  {
				// Parse the data string
		  }

		  public string GetStringRecord()
		  {
				return this.AccountNumber + "-" + this.FirstName + "-" + this.LastName + "-" +
					 this.BirthDate + "-" + this.PowerballNumbers;
		  }
	 }
}
