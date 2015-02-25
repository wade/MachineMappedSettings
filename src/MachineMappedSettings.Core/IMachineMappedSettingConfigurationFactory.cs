namespace MachineMappedSettings
{
	/// <summary>
	/// Implemented by classes that are used to create <see cref="IMachineMappedSettingConfiguration"/> instances.
	/// </summary>
	public interface IMachineMappedSettingConfigurationFactory
	{
		/// <summary>
		/// Creates a new <see cref="IMachineMappedSettingConfiguration"/> instance.
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IMachineMappedSettingConfiguration"/>.
		/// </returns>
		IMachineMappedSettingConfiguration Create();
	}
}