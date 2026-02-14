using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
    public int userId;
    public string userName;
    public string password;
    public string firstName;
    public string lastName;
    public DateTime birthday;
    public string city;
    public string country;
    public bool admin;
    public User()
    {
        userId = -1;
        userName = "";
        password = "";
        firstName = "";
        lastName = "";
        birthday = DateTime.Today;
        city = "";
        country = "";
        admin = false;

    }
}