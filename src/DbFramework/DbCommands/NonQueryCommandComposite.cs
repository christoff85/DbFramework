using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DbFramework.DbCommands
{
    public class NonQueryCommandComposite : INonQueryCommandComposite
	{
        private readonly IList<INonQueryCommand> _batch  = new List<INonQueryCommand>();

		public int Count => _batch.Count;

		internal NonQueryCommandComposite()
		{
		}

		public static INonQueryCommandComposite Create()
			=> new NonQueryCommandComposite();

		public INonQueryCommandComposite Add(INonQueryCommand nonQueryCommand)
		{
			if (nonQueryCommand == null) throw new ArgumentNullException(nameof(nonQueryCommand));

			if (!_batch.Contains(nonQueryCommand))
				_batch.Add(nonQueryCommand);

			return this;
		}

		public INonQueryCommandComposite Remove(INonQueryCommand nonQueryCommand)
		{
			if (nonQueryCommand == null) throw new ArgumentNullException(nameof(nonQueryCommand));

			_batch.Remove(nonQueryCommand);
			return this;
		}

		#region IEnumerable
		[ExcludeFromCodeCoverage]
		public IEnumerator<INonQueryCommand> GetEnumerator() 
			=> _batch.GetEnumerator();

		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
		#endregion
	}
}
