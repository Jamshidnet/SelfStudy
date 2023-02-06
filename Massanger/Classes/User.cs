using SelfStudy.Massanger.Interfaces;
using SelfStudy.Massanger.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SelfStudy.Massanger.Classes
{
    internal class User : IPerson
    {

        
    public delegate void SMS( string str);

        public event  SMS MessageSent;
       public   List<User> users= new List<User>();
       public  Dictionary<User,List<string>> Chatting= new Dictionary<User,List<string>>();

        public User(string name, long  number)
        {
            Name = name;
            Number = number;
        }

        public int ID { get ; set ; }
        public string Name { get; set; }
        public long  Number { get; set; }
        public int Age { get ; set ; }
        public Gender gender { get ; set ; }

        public void AddUser(User user)
        {
            if(!this.users.Any(x => x.Number==user.Number))
            {
                this.users.Add(user);
                this.Chatting.Add(user, new List<string>());
                this.MessageSent += user.PullMessage;
               // user.MessageSent += this.PullMessage;
                Console.WriteLine("User succesfull be added. ");
            }
            else Console.WriteLine("You have already a contact with this number!");
        }

        public void RemoveUser(User user)
        {
            if (this.users.Any(x => x.Number == user.Number))
            {
                this.users.Remove(user);
            }
            else Console.WriteLine("this user is not existed in your contacts list!");
        }
        public void SendMessage(string message)
        {
            this.MessageSent(message); 
        }
        public void PullMessage( string message)
        {
            
                Chatting[this].Add(message);
            
         }
        public void PrintMessages(User user)
        {
            Console.WriteLine("\n");
            foreach (var item in this.Chatting[user])
            {
                Console.WriteLine("   "+item+"\n");
            }
            if (Chatting.ContainsKey(this))
            foreach (var item in user.Chatting[this])
            {
                Console.WriteLine(item);
            }

        }


    }
}
