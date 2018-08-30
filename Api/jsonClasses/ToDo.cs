using System;

namespace Api.jsonClasses
{
	public class ToDo
	{
		public int userId { get; set; }
		public int id { get; set; }
		public string title { get; set; }
		public bool completed { get; set; }

		public override bool Equals(Object obj)
		{
			if (!(obj is ToDo other)) return false;
			return Equals(other);
		}

		public bool Equals(ToDo other)
		{
			if (other == null) return false;
			if (ReferenceEquals(this, other)) return true;
			if (userId != other.userId) return false;
			if (id != other.id) return false;
			if (title != other.title) return false;
			if (completed != other.completed) return false;
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
