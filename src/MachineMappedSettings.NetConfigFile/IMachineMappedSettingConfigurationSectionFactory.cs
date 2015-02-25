namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// Implemented by classes that create new <see cref="MachineMappedSettingConfigurationSection"/> instances.
	/// </summary>
	public interface IMachineMappedSettingConfigurationSectionFactory
	{
		/// <summary>
		/// Creates a new <see cref="MachineMappedSettingConfigurationSection"/> instance.
		/// </summary>
		/// <returns>
		/// A new instance of <see cref="MachineMappedSettingConfigurationSection"/>.
		/// </returns>
		MachineMappedSettingConfigurationSection Create(string configSectionName);
	}
}