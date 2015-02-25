# MachineMappedSettings.NetConfigFile #

MachineMappedSettings.NetConfigFile is a .NET library that provides a simple config section similar to the `appSettings` config section in a .NET config file that maps settings by key and machine name which allows multiple instances of the same key to be configured with different values and machine names. When a key is resolved, the value is returned for the specific instance that matches the key and also the local machine name on which the code is executing. This allows for machine-specific values to be returned which is especially useful for test projects executed across multiple environments. This is a simple alternative to using XML configuration transforms.

This is most commonly used to configure database connection string and service URLs for different environments, including different developer workstations in test projects.

I would not recommend using this approach in production applications. It does work well in test projects.

## NuGet Package ##

This library is available from the NuGet Gallery as the **MachineMappedSettings.NetConfigFile** package.

To install **MachineMappedSettings.NetConfigFile**, run the following command in the Package Manager Console

    Install-Package MachineMappedSettings.NetConfigFile 

The package currently provides a version built against the Microsoft .NET Framework 4.5.


## Example Usage ##

    var settings = new ConfigFileMachineMappedSettingConfiguration();
    var connectionStringName = settings.GetValue("ConnectionStringName");


## Default Config Section ##
The default config section is named `machineMappedSettings`. It is configured in the .NET config file as follows:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    	<configSections>
    		<section name="machineMappedSettings" type="MachineMappedSettings.NetConfigFile.MachineMappedSettingConfigurationSection, MachineMappedSettings.NetConfigFile" />
    	</configSections>
    	<machineMappedSettings>
    		<add key="ConnectionStringName" value="DefaultConnection"   machineName=""  owner="System"   comment="The is the default value." />
    		<add key="ConnectionStringName" value="MyLocalConnection01" machineName="DevTest01" owner="Tester01" comment="" />
    		<add key="ConnectionStringName" value="MyLocalConnection02" machineName="DevTest02" owner="Tester02" comment="" />
    	</machineMappedSettings>
    </configuration>


## Multiple Config Sections Support ##
The implementation allows multiple instances of the MachineMappedSettingConfigurationSection class to be created with different config section names. A single .NET config file (e.g. app.config or web.config) can define multiple config sections instead of placing a large number of different settings in a single config section.

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    	<configSections>
    		<section name="machineMappedConnectionStrings" type="MachineMappedSettings.NetConfigFile.MachineMappedSettingConfigurationSection, MachineMappedSettings.NetConfigFile" />
    		<section name="machineMappedSettings" type="MachineMappedSettings.NetConfigFile.MachineMappedSettingConfigurationSection, MachineMappedSettings.NetConfigFile" />
    	</configSections>
    
    	<machineMappedConnectionStrings>
    		<add key="MyApp" machineName=""  owner="System"   comment="The is the default value." value="Server=QASqlServer;Database=MyApp;Trusted_Connection=True;" />
    		<add key="MyApp" machineName="DevTest01" owner="Tester01" comment="" value="Server=(local);Database=MyApp;Trusted_Connection=True;" />
    		<add key="MyApp" machineName="DevTest02" owner="Tester02" comment="" value="Server=(local);Database=MyApp_Alt_Env;Trusted_Connection=True;" />
    
    		<add key="YourApp" machineName=""  owner="System"   comment="The is the default value." value="Server=QASqlServer;Database=YourApp;Trusted_Connection=True;" />
    		<add key="YourApp" machineName="DevTest01" owner="Tester01" comment="" value="Server=(local);Database=YourApp;Trusted_Connection=True;" />
    		<add key="YourApp" machineName="DevTest02" owner="Tester02" comment="" value="Server=(local);Database=YourApp_Alt_Env;Trusted_Connection=True;" />
    	</machineMappedConnectionStrings>
    
    	<machineMappedSettings>
    		<add key="ConnectionStringName" value="DefaultConnection"   machineName=""  owner="System"   comment="The is the default value." />
    		<add key="ConnectionStringName" value="MyLocalConnection01" machineName="DevTest01" owner="Tester01" comment="" />
    		<add key="ConnectionStringName" value="MyLocalConnection02" machineName="DevTest02" owner="Tester02" comment="" />
    	</machineMappedSettings>
    </configuration>


## Test App ##

The source code contains a simple console application project used to test the functionality of the machine-mapped settings.

