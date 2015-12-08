namespace Job.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter)]
	public class JobBuilderAttribute : Attribute
	{
		private string value;

		public JobBuilderAttribute(string value)
		{
			this.value = value;
		}
	}
}
