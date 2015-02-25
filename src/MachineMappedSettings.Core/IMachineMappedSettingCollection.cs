using System.Collections.Generic;

namespace MachineMappedSettings
{
	/// <summary>
	/// Implemented by classes that represent a list-based collection of machine-mapped settings.
	/// </summary>
	public interface IMachineMappedSettingCollection
		: IList<IMachineMappedSetting>
	{
	}
}