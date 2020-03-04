﻿namespace TestingCSharp
{
	public class ConstructorChaining
	{
		class Student
		{
			string _studentType = "";
			string _id = "";
			string _fName = "";
			string _lName = "";

			public Student(string id)
				: this(id, "", "")
			{

			}

			public Student(string id, string fName)
				: this(id, fName, "")
			{

			}

			public Student(string id, string fName, string lName)
			{
				//Validate logic.....
				_studentType = "<student_type>";

				_id = id;
				_fName = fName;
				_lName = lName;
			}
		}
	}
}
