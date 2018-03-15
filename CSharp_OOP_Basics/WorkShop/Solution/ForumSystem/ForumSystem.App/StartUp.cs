namespace ForumSystem.App
{
    using Core;
    using Data;
    using DataInitializer;

    public class StartUp
	{
		public static void Main()
		{
            // To update the database manualy read the README file!

            //(If the program throws a System.Data.SqlClient.SqlException - read the README file to resolve the problem)
            using (var database = new ForumSystemDbContext())
            {
                var initializer = new DbInitializer(database);
                initializer.ResetDatabase();

                // To initialize the database with sample data uncomment the line below:
                //initializer.SeedData();
            }

            Engine engine = new Engine();
			engine.Run();
		}
    }
}
