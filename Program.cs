using ConsoleApp2;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();
// Ensure database schema is up-to-date with the migrations
context.Database.Migrate();

TestDatabase();

void TestDatabase()
{
	// List all users first
	ListAllUsers();

	// Add a new user
	AddUser();
	ListAllUsers();

	// Update a user
	UpdateUser();
	ListAllUsers();

	// Delete a user
	DeleteUser();
	ListAllUsers();
}

void ListAllUsers()
{
	Console.WriteLine("\n--- All Users ---");
	var users = context.Users.ToList();
	foreach (var user in users)
	{
		Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.EmailAddress}, Phone: {user.PhoneNumber}");
	}
}

void AddUser()
{
	Console.WriteLine("\n--- Adding New User ---");
	var newUser = new User
	{
		Name = "David Brown",
		EmailAddress = "david@email.com",
		PhoneNumber = "555-4444"
	};
	context.Users.Add(newUser);
	context.SaveChanges();
	Console.WriteLine("User added!");
}

void UpdateUser()
{
	Console.WriteLine("\n--- Updating User ---");
	var user = context.Users.FirstOrDefault(u => u.Name == "David Brown");
	if (user != null)
	{
		user.PhoneNumber = "555-9999";
		context.SaveChanges();
		Console.WriteLine("User updated!");
	}
}

void DeleteUser()
{
	Console.WriteLine("\n--- Deleting User ---");
	var user = context.Users.FirstOrDefault(u => u.Name == "David Brown");
	if (user != null)
	{
		context.Users.Remove(user);
		context.SaveChanges();
		Console.WriteLine("User deleted!");
	}
}