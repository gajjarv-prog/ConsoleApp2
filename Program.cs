using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
	internal class Program
	{
		// ── Simple User ──────────────────────
		class User
		{
			public int Id;
			public string Name;
			public string Email;
		}

		// ── "Database" ────────────────────────
		static List<User> users = new List<User>();
		static int nextId = 1;

		// ── 1. LIST ───────────────────────────
		static void ListUsers()
		{
			Console.WriteLine("\n--- Current Users ---");

			if (users.Count == 0)
			{
				Console.WriteLine("No users found.");
				return;
			}

			for (var i = 0; i < users.Count; i++)
				Console.WriteLine($"ID: {users[i].Id}  Name: {users[i].Name}  Email: {users[i].Email}");
		}

		// ── 2. ADD ────────────────────────────
		static void AddUser(string name, string email)
		{
			var user = new User { Id = nextId++, Name = name, Email = email };
			users.Add(user);
			Console.WriteLine($"Added: {name}");
		}

		// ── 3. UPDATE ─────────────────────────
		static void UpdateUser(int id, string newName, string newEmail)
		{
			for (var i = 0; i < users.Count; i++)
			{
				if (users[i].Id == id)
				{
					users[i].Name = newName;
					users[i].Email = newEmail;
					Console.WriteLine($"Updated ID {id} to {newName}");
					return;
				}
			}
			Console.WriteLine($"User ID {id} not found.");
		}

		// ── 4. DELETE ─────────────────────────
		static void DeleteUser(int id)
		{
			for (var i = 0; i < users.Count; i++)
			{
				if (users[i].Id == id)
				{
					users.RemoveAt(i);
					Console.WriteLine($"Deleted ID {id}");
					return;
				}
			}
			Console.WriteLine($"User ID {id} not found.");
		}

		// ── 5. TEST DATABASE ──────────────────
		static void TestDatabase()
		{
			Console.WriteLine("=== TestDatabase Start ===");

			ListUsers();                            // empty

			AddUser("Varun", "varun@example.com");
			AddUser("Vasim", "vasim@example.com");
			AddUser("Precious", "precious@example.com");
			AddUser("Hardi", "hardi@example.com");
			ListUsers();                            // after add

			UpdateUser(2, "Vasim Khan", "vasimkhan@example.com");
			ListUsers();                            // after update

			DeleteUser(1);
			ListUsers();                            // after delete

			Console.WriteLine("\n=== TestDatabase Complete ===");
		}

		// ── Main ──────────────────────────────
		static void Main(string[] args)
		{
			TestDatabase();
		}
	}
}