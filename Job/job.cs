namespace Job
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public class Job
    {
	    public string Name { get; private set; }

	    public IDictionary<string, object> DefaultParameters { get; private set; }

		public IDictionary<string, Task> Tasks { get; private set; }

		public Task StartTask { get; set; }

		public string JobCompletionListener { get; set; }

		public Task GetTask(string taskName)
		{
			return this.Tasks.ContainsKey(taskName) ? this.Tasks[taskName] : null;
		}

		public static Job Of(string name, IDictionary<string, object> defaultParameters, IDictionary<string, Task> tasks, string startTaskName, string jobCompletionListener)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Job name must be specified");
			}

			if (defaultParameters != null && !defaultParameters.Any())
			{
				throw new ArgumentException("There must be at least one task defined");
			}

			if (string.IsNullOrEmpty(startTaskName) || !tasks.ContainsKey(startTaskName))
			{
				throw new ArgumentException($"Startup task '{startTaskName}' cannot be found!");
			}

			return new Job
			{
				Name = name,
				DefaultParameters = defaultParameters == null ? 
					new ReadOnlyDictionary<string, object>(new Dictionary<string, object>()) : 
					new ReadOnlyDictionary<string, object>(new Dictionary<string, object>(defaultParameters)),
			};
		}
    }
}
