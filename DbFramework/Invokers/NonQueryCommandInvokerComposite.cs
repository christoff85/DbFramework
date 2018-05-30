using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DbFramework.Factories;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class NonQueryCommandInvokerComposite : INonQueryCommandInvokerComposite
	{
        private IList<INonQueryCommandInvoker> Batch { get; }

		public int Count => Batch.Count;

		private NonQueryCommandInvokerComposite() 
		    => Batch = new List<INonQueryCommandInvoker>();

		public static INonQueryCommandInvokerComposite Create() 
			=> new NonQueryCommandInvokerComposite();

		public int Invoke(IDbServiceManager dbServiceManager) 
			=> Batch.Sum(dbStoredProcedure => dbStoredProcedure.Invoke(dbServiceManager));

		public INonQueryCommandInvokerComposite Add(INonQueryCommand nonQueryCommand)
        {
            if (nonQueryCommand == null) throw new ArgumentNullException(nameof(nonQueryCommand));

	        var invoker = DbServiceComponentInvokerFactory.Create(nonQueryCommand);
	        return Add(invoker);
        }

		public INonQueryCommandInvokerComposite Add(INonQueryCommandInvoker nonQueryInvoker)
		{
			if (nonQueryInvoker == null) throw new ArgumentNullException(nameof(nonQueryInvoker));

			if (!Batch.Contains(nonQueryInvoker))
				Batch.Add(nonQueryInvoker);

			return this;
		}

		public INonQueryCommandInvokerComposite Remove(INonQueryCommand nonQueryCommand)
        {
            if (nonQueryCommand == null) throw new ArgumentNullException(nameof(nonQueryCommand));

	        var invoker = DbServiceComponentInvokerFactory.Create(nonQueryCommand);
	        return Remove(invoker);
        }

		public INonQueryCommandInvokerComposite Remove(INonQueryCommandInvoker nonQueryCommandInvoker)
		{
			if (nonQueryCommandInvoker == null) throw new ArgumentNullException(nameof(nonQueryCommandInvoker));

			Batch.Remove(nonQueryCommandInvoker);
			return this;
		}

		#region IEquatable implementation
		public bool Equals(IDbServiceCommandInvoker<int> other) 
			=> throw new NotImplementedException();

		protected bool Equals(NonQueryCommandInvokerComposite other) 
			=> Equals(Batch, other.Batch);

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;

			return Equals((NonQueryCommandInvokerComposite) obj);
		}

		public override int GetHashCode() 
			=> Batch != null ? Batch.GetHashCode() : 0;
		#endregion

		#region IEnumerable
		public IEnumerator<INonQueryCommandInvoker> GetEnumerator() 
			=> Batch.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> GetEnumerator();
		#endregion
	}
}
