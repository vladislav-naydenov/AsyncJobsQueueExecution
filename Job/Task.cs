namespace Job
{
	using System;

	public class Task
    {
	    public string Name { get; private set; }

	    public string Group { get; private set; }

	    public string NextTaskName { get; private set; }

	    public string TaskletName { get; private set; }

	    public static Task Of(string name, string group, string nextTaskName, string taskletName)
	    {
		    name = name?.Trim();
		    if (string.IsNullOrEmpty(name))
		    {
			    throw new UnauthorizedAccessException("Task name must be specified!");
		    }

			group = group?.Trim();
			if (string.IsNullOrEmpty(group))
			{
				throw new UnauthorizedAccessException("Task group must be specified!");
			}

			nextTaskName = nextTaskName?.Trim();
			if (string.IsNullOrEmpty(nextTaskName))
			{
				throw new UnauthorizedAccessException("Task nextTaskName must be specified!");
			}

			taskletName = taskletName?.Trim();
			if (string.IsNullOrEmpty(taskletName))
			{
				throw new UnauthorizedAccessException("Task taskletName must be specified!");
			}

			return new Task
			{
				Name = name,
				Group = group,
				NextTaskName = nextTaskName,
				TaskletName = taskletName
			};
		}
    }
}
