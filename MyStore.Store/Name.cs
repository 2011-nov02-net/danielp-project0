using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyStore.Store
{
    public struct Name : IComparer<Name>, ISerializable
    {

        /// <summary>
        /// Public propertis on the Name struct
        /// </summary>
        public string First { get; }
        public char? MiddleInitial { get; }
        public string Last { get; }

        /// <summary>
        /// Constructor with two parameters to create Name struct
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        public Name(string first, string last)
        {
            First = first;
            Last = last;
            MiddleInitial = null;
        }

        /// <summary>
        /// Constructor with three parameters to create Name struct
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="middle"></param>
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
        /// Method to get the data of a serialized object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First", First);
            if(MiddleInitial != null)
            {
                info.AddValue("Middle", MiddleInitial);
            }
            info.AddValue("Last", Last);
        }

        /// <summary>
        /// Create a string that shows some of the current state of Name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{First,20} {MiddleInitial?.ToString() ?? " "} {Last, 20}";
        }

        /// <summary>
        /// Method to check if name is equal to another name
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
