using CustomerFeedback.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var serviceProvider = new ServiceCollection()
	.AddDbContext<CustomerFeedbackDBContext>(options => options.UseSqlServer("CustomerFeedback"))
	.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<CustomerFeedbackDBContext>();

Console.Write("Masukkan nama Anda: ");
string name = Console.ReadLine();

Console.Write("Masukkan email Anda: ");
string email = Console.ReadLine();

Console.Write("Masukkan feedback Anda: ");
string feedbackText = Console.ReadLine();

using (var context = serviceProvider.GetService<CustomerFeedbackDBContext>())
{
	var customer = context.Customers.SingleOrDefault(c => c.Email == email);
	if (customer == null)
	{
		customer = new Customer
		{
			Name = name,
			Email = email
		};
		context.Customers.Add(customer);
		context.SaveChanges();
	}

	var feedback = new Feedback
	{
		CustomerId = customer.CustomerId,
		FeedbackText = feedbackText,
		Status = "Pending"
	};
	context.Feedbacks.Add(feedback);
	context.SaveChanges();
}

Console.WriteLine("Terima kasih atas feedback Anda!");