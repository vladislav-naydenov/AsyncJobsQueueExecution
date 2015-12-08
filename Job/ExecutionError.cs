namespace Job
{
	using System;
	using System.Diagnostics;
	using System.Text;
	using Enums;

	public class ExecutionError
	{
		public ErrorCode Code { get; private set; }
		private Exception Cause { get; set; }
		private string DetailedMessage { get; set; }

		public static ExecutionError Of(ErrorCode? code, Exception cause)
		{
			if (code == null)
			{
				throw new ArgumentNullException($"{nameof(code)} must be set!");
			}

			return new ExecutionError
			{
				Code = code.Value,
				Cause = cause,
				DetailedMessage = ""
			};
		}

		private static string BuildDetailedMessage(Exception cause)
		{
			if (cause == null)
			{
				return null;
			}

			var stringBuilder = new StringBuilder(2048);
			var newLine = Environment.NewLine;
			var stackTrace = new StackTrace(cause);

			stringBuilder.Append(cause.ToString()).Append(newLine);

			while (stringBuilder.Length < 2048)
			{
				var stackFrames = stackTrace?.GetFrames();
				if (stackFrames != null)
				{
					foreach (var stackFrame in stackFrames)
					{
						stringBuilder.Append(stackFrame.GetFileName())
							.Append(stackFrame.GetMethod())
							.Append(":")
							.Append(stackFrame.GetFileLineNumber())
							.Append(newLine);

						if (stringBuilder.Length > 2047)
						{
							break;
						}
					}
				}

				if (cause.InnerException == null)
				{
					break;
				}
				else if(cause != cause.InnerException)
				{
					cause = cause.InnerException;
					stringBuilder.Append("^").Append(cause).Append(newLine);
				}
			}

			return stringBuilder.ToString();
		}
	}
}
