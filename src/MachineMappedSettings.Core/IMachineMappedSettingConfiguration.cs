namespace MachineMappedSettings
{
	/// <summary>
	/// Implemented by classes that provide machine-mapped settings configuration.
	/// </summary>
	public interface IMachineMappedSettingConfiguration
	{
		/// <summary>
		/// Gets the setting.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// An instance of <see cref="IMachineMappedSetting"/> or null if the setting was not found.
		/// </returns>
		IMachineMappedSetting GetSetting(string key);

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// A string that represents the resolved setting's value or null if the setting was not found.
		/// </returns>
		string GetValue(string key);
	}
}