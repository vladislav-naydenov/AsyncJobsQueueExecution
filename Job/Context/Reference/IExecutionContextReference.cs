namespace Job.Context.Reference
{
    public interface IExecutionContextReference<out T> where T : class 
    {
		/// <summary>
		/// 
		/// </summary>
		/// <returns>if referenced object can be loaded.</returns>
		bool IsLoadable();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>true if the referenced object is available</returns>
		bool IsLoaded();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>referenced object, if object is not available it tries to load it.</returns>
		/// <exception cref="System.InvalidOperationException"> if the reference is not loadable and reference object is not loaded. </exception>
		T Get();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>string reference of the object (up to 256 symbols)</returns>
		string ToString();

		/// <summary>
		/// 
		/// </summary>
		/// <returns>reference type (up to 32 symbols)</returns>
		string Type();
	}
}
