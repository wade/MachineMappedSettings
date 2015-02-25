using System;
using MachineMappedSettings.NetConfigFile;

namespace MachineMappedSettings.TestConsoleApp
{
	internal class Program
	{
		private const string ConnectionStringNameSettingKey = "ConnectionStringName";
		private const string MyAppConnectionStringKey = "MyApp";
		private const string YourAppConnectionStringKey = "YourApp";
		private readonly IMachineMappedSettingConfiguration _machineMappedSettings;
		private readonly IMachineMappedSettingConfiguration _machineMappedConnectionStrings;

		private Program()
		{
			// Create an instance that uses the default config section
			_machineMappedSettings = new ConfigFileMachineMappedSettingConfiguration();

			// Create an instance that uses a custom config section
			_machineMappedConnectionStrings = new ConfigFileMachineMappedSettingConfiguration("machineMappedConnectionStrings");
		}

		private static void Main()
		{
			try
			{
				new Program().Run();
			}
			catch (Exception ex)
			{
				Console.WriteLine("An exception occurred:");
				Console.WriteLine("Exception Type ......: {0}", ex.GetType().FullName);
				Console.WriteLine("Exception Message ...: {0}", ex.Message);
				Console.WriteLine("Exception Details ...:\n{0}\n", ex.Message);
			}
			finally
			{
#if DEBUG
				Console.WriteLine("The program has ended. Press any key to exit.");
				Console.ReadKey();
#endif
			}
		}

		private void Run()
		{
			var connectionStringName = _machineMappedSettings.GetValue(ConnectionStringNameSettingKey);
			Console.WriteLine("machineMappedSettings.ConnectionStringName ...: {0}", connectionStringName);

			var myAppConnectionString = _machineMappedConnectionStrings.GetValue(MyAppConnectionStringKey);
			Console.WriteLine("machineMappedConnectionStrings.MyApp .........: {0}", myAppConnectionString);

			var yourAppConnectionString = _machineMappedConnectionStrings.GetValue(YourAppConnectionStringKey);
			Console.WriteLine("machineMappedConnectionStrings.YourApp .......: {0}", yourAppConnectionString);
		}
	}
}
