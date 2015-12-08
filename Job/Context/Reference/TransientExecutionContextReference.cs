namespace Job.Context.Reference
{
	using System;

	public class TransientExecutionContextReference<T> : AbstractExecutionContextReference<T> where T : class
	{
		public TransientExecutionContextReference(T @object) 
			: base(@object, "transient")
		{
		}

		protected override string ToReference(T @object)
		{
			return "transient";
		}
	}
}
