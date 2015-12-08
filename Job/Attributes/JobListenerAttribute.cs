namespace Job.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter)]
	public class JobListenerAttribute : Attribute
    {
		private string value;

		public JobListenerAttribute(string value)
		{
			this.value = value;
		}
	}
}
