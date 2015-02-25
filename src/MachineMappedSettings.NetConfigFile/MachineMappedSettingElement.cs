using System.Configuration;

namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// The element in the .NET config file that represents the machine-mapped setting.
	/// </summary>
	public class MachineMappedSettingElement : ConfigurationElement, IMachineMappedSetting
	{
		private const string CommentAttributeName = "comment";
		private const string KeyAttributeName = "key";
		private const string MachineNameAttributeName = "machineName";
		private const string OwnerAttributeName = "owner";
		private const string ValueAttributeName = "value";

		/// <summary>
		/// Gets the comment.
		/// </summary>
		/// <value>
		/// The comment.
		/// </value>
		/// <remarks>
		/// The comment is an optional piece of information and may be null.
		/// </remarks>
		[ConfigurationProperty(CommentAttributeName, IsRequired = false)]
		public string Comment
		{
			get { return this[CommentAttributeName] as string; }
		}

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		/// <remarks>
		/// The key is used to lookup the machine-mapped setting and is required.
		/// </remarks>
		[ConfigurationProperty(KeyAttributeName, IsRequired = true)]
		public string Key
		{
			get { return this[KeyAttributeName] as string; }
		}

		/// <summary>
		/// Gets the name of the machine to which the setting is mapped.
		/// </summary>
		/// <value>
		/// The name of the machine to which the setting is mapped.
		/// </value>
		/// <remarks>
		/// The machine name is required for all entries but one, which is the default value
		/// that is used when the machine cannot be mapped.
		/// </remarks>
		[ConfigurationProperty(MachineNameAttributeName, IsRequired = false)]
		public string MachineName
		{
			get { return this[MachineNameAttributeName] as string; }
		}

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
		[ConfigurationProperty(OwnerAttributeName, IsRequired = false)]
		public string Owner
		{
			get { return this[OwnerAttributeName] as string; }
		}

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
		[ConfigurationProperty(ValueAttributeName, IsRequired = false)]
		public string Value
		{
			get { return this[ValueAttributeName] as string; }
		}
	}
}