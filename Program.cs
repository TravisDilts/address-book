using aa_interview.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<AddressBookService>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

//Test populate the address book with some entries
var addressBookService = app.Services.GetService<AddressBookService>();
var entry1 = new aa_interview.Models.AddressBookEntry
{
    Name = "John Doe",
    Email = "johndoe@example.com",
    PhoneNumber = "123-456-7890"
};

var entry2 = new aa_interview.Models.AddressBookEntry
{
    Name = "Jane Smith",
    Email = "janesmith@example.com",
    PhoneNumber = "987-654-3210"
};

addressBookService.AddEntry(entry1);
addressBookService.AddEntry(entry2);


app.Run();

