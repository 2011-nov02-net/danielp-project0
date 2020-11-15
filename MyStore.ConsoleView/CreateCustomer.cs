﻿using System;
using MyStore.Store;

namespace MyStore.ConsoleView
{
    internal class CreateCustomer : IMenu
    {
        public IMenu DisplayMenu()
        {
            Customer Current = null;
            bool gotValidName = false;
            Name customerName;


            do
            {
                customerName = GetName();
                try
                {
                    Current = Customers.Instance.RegisterCustomer(Current);
                    gotValidName = true;

                }
                catch (CustomerAlreadyExistsException e)
                {
                    gotValidName = false;
                    Current = null;
                    Console.WriteLine("Names must be unique, that one isn't. Try again please.");
                }

            } while (!gotValidName);

            return new LoggedInMenu(Current);
        }

        //TODO: implement function
        private Name GetName()
        {

            //get first name

            //ask if want to include middle initial
            //get middle initial

            //get last name


            throw new NotImplementedException();
        }
    }
}