using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// The element in the .NET config file that represents a group of machine-mapped setting elements.
	/// </summary>
	public class MachineMappedSettingElementCollection : ConfigurationElementCollection, IMachineMappedSettingCollection
	{
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public MachineMappedSettingElement this[int index]
		{
			get { return BaseGet(index) as MachineMappedSettingElement; }
		}

		/// <summary>
		/// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
		/// </summary>
		/// <returns>
		/// A new <see cref="T:System.Configuration.ConfigurationElement" />.
		/// </returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new MachineMappedSettingElement();
		}

		/// <summary>
		/// Gets the element key for a specified configuration element when overridden in a derived class.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		/// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. </param>
		protected override object GetElementKey(ConfigurationElement element)
		{
			var e = (MachineMappedSettingElement) element;
			return
				string.IsNullOrEmpty(e.MachineName)
					? e.Key
					: string.Format("{0}|{1}", e.Key, e.MachineName);
		}

		/// <summary>
		/// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
		/// </summary>
		/// <returns>
		/// The index of <paramref name="item"/> if found in the list; otherwise, -1.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
		int IList<IMachineMappedSetting>.IndexOf(IMachineMappedSetting item)
		{
			var element = item as MachineMappedSettingElement;
			if (null != element)
				return BaseIndexOf(element);

			throw new InvalidOperationException(string.Format("The item must be an instance of the {0} type.", typeof(MachineMappedSettingElement).FullName));
		}

		/// <summary>
		/// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
		void IList<IMachineMappedSetting>.Insert(int index, IMachineMappedSetting item)
		{
			// This member is intentionally not implemented.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
		void IList<IMachineMappedSetting>.RemoveAt(int index)
		{
			// This member is intentionally not implemented.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <returns>
		/// The element at the specified index.
		/// </returns>
		/// <param name="index">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
		IMachineMappedSetting IList<IMachineMappedSetting>.this[int index]
		{
			get { return BaseGet(index) as MachineMappedSettingElement; }
			set
			{
				// This member is intentionally not implemented.
				throw new NotImplementedException();
			}
		}

		#region Implementation of IEnumerable<out MachineMappedSettingElement>

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		IEnumerator<IMachineMappedSetting> IEnumerable<IMachineMappedSetting>.GetEnumerator()
		{
			return new MachineMappedSettingElementEnumerator(GetEnumerator());
		}

		#endregion

		#region Implementation of ICollection<MachineMappedSettingElement>

		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		void ICollection<IMachineMappedSetting>.Add(IMachineMappedSetting item)
		{
			var element = item as MachineMappedSettingElement;
			if (null != element)
				BaseAdd(element);
			else
				throw new InvalidOperationException(string.Format("The item must be an instance of the {0} type.", typeof(MachineMappedSettingElement).FullName));
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
		void ICollection<IMachineMappedSetting>.Clear()
		{
			BaseClear();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		bool ICollection<IMachineMappedSetting>.Contains(IMachineMappedSetting item)
		{
			var element = item as MachineMappedSettingElement;
			if (null != element)
				return (BaseIndexOf(element) > -1);

			throw new InvalidOperationException(string.Format("The item must be an instance of the {0} type.", typeof(MachineMappedSettingElement).FullName));
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
		void ICollection<IMachineMappedSetting>.CopyTo(IMachineMappedSetting[] array, int arrayIndex)
		{
			// This member is intentionally not implemented.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		bool ICollection<IMachineMappedSetting>.Remove(IMachineMappedSetting item)
		{
			// This member is intentionally not implemented.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
		/// </returns>
		bool ICollection<IMachineMappedSetting>.IsReadOnly
		{
			get { return true; }
		}

		#endregion

		/// <summary>
		/// Enumerator adapter.
		/// </summary>
		public class MachineMappedSettingElementEnumerator : IEnumerator<IMachineMappedSetting>
		{
			private readonly IEnumerator _enumerator;

			/// <summary>
			/// Initializes a new instance of the <see cref="MachineMappedSettingElementEnumerator"/> class.
			/// </summary>
			/// <param name="enumerator">The enumerator.</param>
			public MachineMappedSettingElementEnumerator(IEnumerator enumerator)
			{
				_enumerator = enumerator;
			}

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			/// <filterpriority>2</filterpriority>
			public void Dispose()
			{
				var disposable = _enumerator as IDisposable;
				if (null != disposable)
					disposable.Dispose();
			}

			/// <summary>
			/// Advances the enumerator to the next element of the collection.
			/// </summary>
			/// <returns>
			/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
			public bool MoveNext()
			{
				return _enumerator.MoveNext();
			}

			/// <summary>
			/// Sets the enumerator to its initial position, which is before the first element in the collection.
			/// </summary>
			/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
			public void Reset()
			{
				_enumerator.Reset();
			}

			/// <summary>
			/// Gets the element in the collection at the current position of the enumerator.
			/// </summary>
			/// <returns>
			/// The element in the collection at the current position of the enumerator.
			/// </returns>
			public IMachineMappedSetting Current
			{
				get { return (IMachineMappedSetting)_enumerator.Current; }
			}

			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			/// <returns>
			/// The current element in the collection.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception><filterpriority>2</filterpriority>
			object IEnumerator.Current
			{
				get { return Current; }
			}
		}
	}
}