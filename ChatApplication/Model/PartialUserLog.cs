using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApplication.Model;

namespace ChatApplication.Model
{
	public partial class UserLog
	{
		public string GetPhoto
		{
			get
			{
				return Environment.CurrentDirectory + "\\" + Photo;
			}
			set
			{
				Photo = value;
			}
		}

	}
}
