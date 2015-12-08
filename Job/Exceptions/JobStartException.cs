namespace Job.Exceptions
{
	using System;

	public class JobStartException : Exception
    {
		public JobStartException(string message) 
			: base(message)
		{
		}
    }
}
