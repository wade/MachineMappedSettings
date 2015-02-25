using System;
using System.Configuration;
using System.Linq;

namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// .NET config file-based implementation of <see cref="IMachineMappedSettingConfiguration"/>.
	/// </summary>
	public class ConfigFileMachineMappedSettingConfiguration : IMachineMappedSettingConfiguration
	{
		private readonly string _configSectionName;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigFileMachineMappedSettingConfiguration"/> class.
		/// </summary>
		/// <param name="configSectionName">Name of the configuration section.</param>
		public ConfigFileMachineMappedSettingConfiguration(string configSectionName = null)
		{
			_configSectionName =
				(string.IsNullOrWhiteSpace(configSectionName))
					? NetConfigFileSettings.DefaultConfigurationSectionName
					: configSectionName;
		}

		/// <summary>
		/// Gets the setting.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// An instance of <see cref="IMachineMappedSetting" /> or null if the setting was not found.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">key</exception>
		public IMachineMappedSetting GetSetting(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException("key");

			var configurationSection = GetConfigurationSection();

			if (null == configurationSection)
				return null;

			var machineName = Environment.MachineName;

			var setting = configurationSection.MachineMappedSettings.FirstOrDefault(
				item =>
					string.Compare(key, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0 &&
					string.Compare(machineName, item.MachineName, StringComparison.InvariantCultureIgnoreCase) == 0)

						// If the query above returns null,
						// check for a setting with a default value (matching key, no machine name):
						?? configurationSection.MachineMappedSettings.FirstOrDefault(
							item =>
								string.Compare(key, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0 &&
								string.IsNullOrEmpty(item.MachineName));
			return setting;
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// A string that represents the resolved setting's value or null if the setting was not found.
		/// </returns>
		public string GetValue(string key)
		{
			var setting = GetSetting(key);
			return
				(null != setting)
					? setting.Value ?? string.Empty
					: null;
		}

		/// <summary>
		/// Gets the configuration section.
		/// </summary>
		/// <returns>
		/// An <see cref="MachineMappedSettingConfigurationSection"/> instance.
		/// </returns>
		/// <exception cref="InvalidOperationException">
		/// The NetConfigFileSettings type's Factory property value is null, which is not allowed. It must be set to a valid factory instance.
		/// </exception>
		/// <exception cref="ConfigurationErrorsException">
		/// An unexpected error occurred while attempting to get the MachineMappedSettingConfigurationSection instance. See the iner exception for details.
		/// </exception>
		private MachineMappedSettingConfigurationSection GetConfigurationSection()
		{
			try
			{
				var factory = NetConfigFileSettings.Factory;

				if (null == factory)
					throw new InvalidOperationException(
						string.Format("The {0} type's Factory property value is null, which is not allowed. It must be set to a valid '{1}' instance.",
						typeof(NetConfigFileSettings).FullName,
						typeof(IMachineMappedSettingConfigurationSectionFactory).FullName));

				return factory.Create(_configSectionName);
			}
			catch (Exception unexpectedException)
			{
				throw new ConfigurationErrorsException(
					string.Format(
						"An unexpected error occurred while attempting to get the '{0}' instance. See the iner exception for details.",
						typeof(MachineMappedSettingConfigurationSection).FullName),
					unexpectedException);
			}
		}
	}
}