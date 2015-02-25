namespace MachineMappedSettings.NetConfigFile
{
	/// <summary>
	/// Settings for the .NET config file-based machine-mapped settings implementation.
	/// </summary>
	public static class NetConfigFileSettings
	{
		/// <summary>
		/// Initializes the <see cref="NetConfigFileSettings"/> class.
		/// </summary>
		static NetConfigFileSettings()
		{
			DefaultConfigurationSectionName = "machineMappedSettings";
			Factory = new DefaultConfigFileMachineMappedSettingConfigurationSectionFactory();
		}

		/// <summary>
		/// Gets or sets the default name of the configuration section.
		/// </summary>
		/// <value>
		/// The default name of the configuration section.
		/// </value>
		public static string DefaultConfigurationSectionName { get; private set; }

		/// <summary>
		/// Gets or sets the factory used to create a MachineMappedSettingConfigurationSection instance.
		/// </summary>
		/// <value>
		/// The factory used to create a MachineMappedSettingConfigurationSection instance.
		/// </value>
		public static IMachineMappedSettingConfigurationSectionFactory Factory { get; set; }
	}
}