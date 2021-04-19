using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleList = new List<Person>
            {
                new()
                {
                    Id = 1,
                    FirstName = "",
                    MiddleName = "",
                    LastName = "",
                    EyeColor = EyeColor.Green,
                    HairColor = HairColor.Black
                },
                new()
                {   
                    Id = 2,
                    FirstName = "",
                    MiddleName = "",
                    LastName = "",
                    EyeColor = EyeColor.Green,
                    HairColor = HairColor.Black
                }
            };

            SqlOperations.SavePerson(peopleList);
            SqlOperations.Update(peopleList.FirstOrDefault());
            SqlOperations.Delete(peopleList.FirstOrDefault().Id);
            List<Person> currentPeople = SqlOperations.Read();
        }
    }
}
