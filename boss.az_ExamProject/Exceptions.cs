class WrongInputException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tYour input is not supported by SYSTEM !\n";
}

class UsernameOrPasswordException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tUSERNAME or PASSWORD has been entered INCORRECTLY !\n";
}

class IDException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tID is not FOUND !\n";
}

class VacancyIDException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tID of Vacancy is not FOUND !\n";
}

class SystemException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tSYSTEM EXCEPTION !\nSTART AGAIN...\n";
}

class CVIDException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tID of CV is not FOUND !\n";
}

class ApplierIDException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tID of Applier is not FOUND !\n";
}

class CreateObjectException : ApplicationException
{
	public override string Message => $"\n\n\t\t\t\tAll The First, CREATE ANY CV !\n";
}