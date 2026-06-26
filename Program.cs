using ConsoleApp2;

var context = new AppDbContext();

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
		Name = "Vaishnavi Gajjar",
		EmailAddress = "vishu@email.com",
		PhoneNumber = "123-235-4444"
	};
	context.Users.Add(newUser);
	context.SaveChanges();
	Console.WriteLine("User added!");
}

void UpdateUser()
{
	Console.WriteLine("\n--- Updating User ---");
	var user = context.Users.FirstOrDefault(u => u.Name == "Vaishnavi Gajjar");
	if (user != null)
	{
		user.PhoneNumber = "555-999-1234";
		context.SaveChanges();
		Console.WriteLine("User updated!");
	}
}

void DeleteUser()
{
	Console.WriteLine("\n--- Deleting User ---");
	var user = context.Users.FirstOrDefault(u => u.Name == "Vaishnavi Gajjar");
	if (user != null)
	{
		context.Users.Remove(user);
		context.SaveChanges();
		Console.WriteLine("User deleted!");
	}
}