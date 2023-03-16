
using Ubee.Data.IRepositories;
using Ubee.Data.Repositories;
using Ubee.Service.Services;

IUserRepository dbContext = new UserRepository();



var users = dbContext.SelectAllUsers();

foreach(var user in users)
{
    Console.WriteLine(user.Firstname);
}