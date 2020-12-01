using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyStore.Store
{
    /// <summary>
    /// A class to hold a customers name.
    /// </summary>
    public struct Name : IComparer<Name>
    {

        /// <summary>
        /// Public propertis on the Name struct
        /// </summary>
        public string First { get; }
        /// <summary>
        /// Middile Initial
        /// </summary>
        public char? MiddleInitial { get; }
        /// <summary>
        /// Last name of the customer
        /// </summary>
        public string Last { get; }

        /// <summary>
        /// Constructor for a name of someone w/o a middle name
        /// </summary>
        /// <param name="first">First Name of the customer</param>
        /// <param name="last">Last name of the customer</param>
        public Name(string first, string last)
        {
            First = first;
            Last = last;
            MiddleInitial = null;
        }

        /// <summary>
        /// Constructor for someone with a middle initial
        /// </summary>
        /// <param name="first">The first name</param>
        /// <param name="last">The last name</param>
        /// <param name="middle">The middle initial</param>
        public Name(string first, string last, char? middle = null)
        {
            First = first;
            Last = last;
            MiddleInitial = middle;
        }

        /// <summary>
        /// Method to compare two names: first, middle, last
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Name x, Name y)
        {
            if(x.First == y.First)
            {
                //both missing middle initial
                if (x.MiddleInitial is null && y.MiddleInitial is null)
                {           
                } else
                {
                    //one missing middle initial
                    if (x.MiddleInitial is null || y.MiddleInitial is null)
                    {
                        if(x.MiddleInitial is null)
                        {
                            return 1;
                        } else
                        {
                            return -1;
                        }
                    } else
                    {
                        //both have middle initial
                        if(x.MiddleInitial != y.MiddleInitial)
                        {
                            if( x.MiddleInitial < y.MiddleInitial)
                            {
                                return 1;
                            } else
                            {
                                return -1;
                            }
                        }
                    }
                }
                return x.Last.CompareTo(y.Last);
            } else
            {
                return x.First.CompareTo(y.First);
            }
        }

        /// <summary>
        /// Create a string that shows some of the current state of Name
        /// </summary>
        /// <returns>The string version of the name</returns>
        public override string ToString()
        {
            return $"{First,20} {MiddleInitial?.ToString() ?? " "} {Last, 20}";
        }

        /// <summary>
        /// Method to check if name is equal to another name
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if(obj is Name)
            {
                Name other = (Name) obj;

                return First == other.First && Last == other.Last && MiddleInitial == other.MiddleInitial;
            } else
            {
                return base.Equals(obj);
            }          
        }
    };
}
