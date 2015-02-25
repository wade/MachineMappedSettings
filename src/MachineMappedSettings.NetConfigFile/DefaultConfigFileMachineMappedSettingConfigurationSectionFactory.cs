using System.Configuration;

namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// Creates a new instance of <see cref="MachineMappedSettingConfigurationSection"/>
	/// from the application's default .NET config file.
	/// </summary>
	public class DefaultConfigFileMachineMappedSettingConfigurationSectionFactory : IMachineMappedSettingConfigurationSectionFactory
	{
		/// <summary>
		/// Creates a new <see cref="MachineMappedSettingConfigurationSection" /> instance.
		/// </summary>
		/// <param name="configSectionName"></param>
		/// <returns>
		/// A new instance of <see cref="MachineMappedSettingConfigurationSection" />.
		/// </returns>
		public MachineMappedSettingConfigurationSection Create(string configSectionName)
		{
			if (string.IsNullOrWhiteSpace(configSectionName))
				configSectionName = NetConfigFileSettings.DefaultConfigurationSectionName;

			return ConfigurationManager.GetSection(configSectionName) as MachineMappedSettingConfigurationSection;
		}
	}
}