To update the database go to "View"/"Other Windows"/"Package Manager Console",
make sure your Default project is "ForumSystem.Data" and type the line below:
Update-Database

If the console throw an exception with message: 
"The type initializer for 'ForumSystem.Data.Configurations.ConnectionConfig' threw an exception."
you have to go to ForumSystem/Data/Configurations/ConnectionConfig.cs and change the AlternativeServerName value with your server name.
Type the command "Update-Database" in Package Manager Console again!

Enjoy!