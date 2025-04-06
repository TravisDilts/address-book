using aa_interview.Services;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<AddressBookService>(); 

/* If you are reading this part and are horrified that I've opened
* all origins, methods, and headers for CORS, do not be concerned.
*
* I am aware this is generally bad practice and am just doing this
* as a quick solution to allow communication between FE and BE on
* my local machine so localhost:4200 and localhost:5124 can connect.
*/
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .SetIsOriginAllowed((host) => true);
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(MyAllowSpecificOrigins);
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

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

