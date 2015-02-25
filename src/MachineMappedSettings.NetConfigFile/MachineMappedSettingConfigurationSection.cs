using System.Configuration;

namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// The machine-mapped settings config section used in .NET config files.
	/// </summary>
	public class MachineMappedSettingConfigurationSection : ConfigurationSection
	{
		private const string MachineMappedSettingsPropertyName = ""; // Empty string is intentional.

		/// <summary>
		/// Gets the machine-mapped settings.
		/// </summary>
		/// <value>
		/// The machine-mapped settings.
		/// </value>
		[ConfigurationProperty(MachineMappedSettingsPropertyName, IsRequired = false, IsDefaultCollection = true)]
		[ConfigurationCollection(typeof(MachineMappedSettingElement))]
		public MachineMappedSettingElementCollection MachineMappedSettings
		{
			get { return this[MachineMappedSettingsPropertyName] as MachineMappedSettingElementCollection; }
		}
	}
}