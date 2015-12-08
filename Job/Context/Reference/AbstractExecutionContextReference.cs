namespace Job.Context.Reference
{
	using System;

	public abstract class AbstractExecutionContextReference<T> : IExecutionContextReference<T> where T : class
    {
		private T @object;
		private bool loaded;
		private string reference;
		private string type;

		public AbstractExecutionContextReference(T @object, string type)
		{
			this.@object = @object;
			this.type = type;
			this.loaded = true;
			this.reference = this.ToReference(@object);
		}

		public AbstractExecutionContextReference(string reference)
		{
			this.reference = reference;
			this.loaded = false;
		}

		protected abstract string ToReference(T obj);

		protected T Load() { return null; }

		public bool IsLoadable()
		{
			return false;
		}

	    public bool IsLoaded()
	    {
		    return this.loaded;
	    }

	    public T Get()
	    {
		    if (!loaded && !IsLoadable())
		    {
			    throw new InvalidOperationException("Cannot load " + nameof(@object));
		    }

		    return @object;
	    }

	    public string Type()
	    {
		    return this.type;
	    }

		public override string ToString()
		{
			return this.reference;
		}
    }
}
