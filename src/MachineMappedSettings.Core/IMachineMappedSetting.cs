namespace MachineMappedSettings
{
	/// <summary>
	/// Implemented by classes that represent a machine-mapped setting configuration item.
	/// </summary>
	public interface IMachineMappedSetting
	{
		/// <summary>
		/// Gets the comment.
		/// </summary>
		/// <value>
		/// The comment.
		/// </value>
		/// <remarks>
		/// The comment is an optional piece of information and may be null.
		/// </remarks>
		string Comment { get; }

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		/// <remarks>
		/// The key is used to lookup the machine-mapped setting and is required.
		/// </remarks>
		string Key { get; }

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>
		/// The owner.
		/// </value>
		/// <remarks>
		/// The owner is an optional piece of information that specifies the name of the owner of the machine-mapped setting.
		/// Although the owner is optional and may be null, it is highly advised to always supply an owner name.
		/// </remarks>
		string Owner { get; }

		/// <summary>
		/// Gets the name of the machine to which the setting is mapped.
		/// </summary>
		/// <value>
		/// The name of the machine to which the setting is mapped.
		/// </value>
		/// <remarks>
		/// The machine name is required.
		/// </remarks>
		string MachineName { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		/// <remarks>
		/// The value is not required and mau be null.
		/// There is not much value in a null value, but it may be useful at times to remove the value.
		/// </remarks>
		string Value { get; }
	}
}