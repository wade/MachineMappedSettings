using System;
using System.Collections.Concurrent;

namespace MachineMappedSettings
{
	/// <summary>
	/// A static, in-memory caching decorator implementation of <see cref="IMachineMappedSettingConfiguration"/>.
	/// </summary>
	/// <remarks>
	/// This class' constructor requires an underlying <see cref="IMachineMappedSettingConfiguration"/> instance to provide the actual values.
	/// The settings are cached once each in an in-memory dictionary for the lifetime of the application.
	/// If a setting is not found, null is cached.
	/// </remarks>
	public class InMemoryStaticCachingMachineMappedSettingConfigurationDecorator : IMachineMappedSettingConfiguration
	{
		private static readonly ConcurrentDictionary<string, IMachineMappedSetting> _concurrentDictionary = new ConcurrentDictionary<string, IMachineMappedSetting>();
		private readonly IMachineMappedSettingConfiguration _configuration;
		private static readonly string _machineName = Environment.MachineName;

		/// <summary>
		/// Initializes a new instance of the <see cref="InMemoryStaticCachingMachineMappedSettingConfigurationDecorator"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		/// <exception cref="System.ArgumentNullException">configuration</exception>
		public InMemoryStaticCachingMachineMappedSettingConfigurationDecorator(IMachineMappedSettingConfiguration configuration)
		{
			if (null == configuration)
				throw new ArgumentNullException("configuration");

			_configuration = configuration;
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

			var cacheKey = GetCacheKey(key);
			return _concurrentDictionary.GetOrAdd(cacheKey, k => _configuration.GetSetting(k));
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
		/// Gets the cache key.
		/// </summary>
		/// <param name="key">The macine-mapped setting key.</param>
		/// <returns></returns>
		private static string GetCacheKey(string key)
		{
			return string.Format("{0}|{1}", _machineName, key);
		}
	}
}