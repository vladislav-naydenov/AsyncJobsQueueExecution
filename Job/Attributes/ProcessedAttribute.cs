namespace Job.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter)]
	public class ProcessedAttribute : Attribute
    {
    }
}
