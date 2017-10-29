using System;
using System.Runtime.Serialization;

namespace ApiServer.Repository
{
	[Serializable]
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(Type type) : base($"{type.Name} not found that matches the criteria.")
		{
		}

		public EntityNotFoundException(string message) : base(message)
		{
		}

		public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}