using SelfStudy.Massanger.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SelfStudy.Massanger
{
    internal class MassangerClass
    {
        public static void Main1()
        {
            List<User> AllUsers = new();
            Console.WriteLine("\n \n \n \n \n \n \n \n \n \n \n                             Welcome to Jamshid's messenger!");
            Console.WriteLine("                          Worl's the fastest Messanger");
            Console.WriteLine("                             Press Enter To Continue");
            Console.ReadKey();
            Console.Clear();
            Console.Write("\n \n \n \n \n \n \n \n \n \n                                       Input your Number => ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("                                       Input your Name => ");
            string? name = Console.ReadLine();
            User activeUser = new User(name,number), newuser;
            AllUsers.Add(activeUser);
            Menyu:
            Console.Clear();
            int i = 1;
            if(activeUser.users.Count==0)
            {
                Console.WriteLine("\n\n                         You have no Contacts yet. ");
            }
            else
            {
                Console.WriteLine("\n\n                         Your contacts ");
                foreach (var item in activeUser.users)
                {
                    Console.WriteLine("      "+i+"=>"+item.Name);i++;
                }
            }
            Console.WriteLine("\n\n Additonal features");
            Console.WriteLine($" {i}=> Add contact");
            Console.WriteLine($" {i+1}=> Change default Account");
            Console.Write(" \n Input =>");
            int num = int.Parse(Console.ReadLine());
            Console.Clear();
            if(num==i)
            {
                Console.Write(" \n\n\n\n\n   Input the name of new Contact =>");
                name = Console.ReadLine();
                Console.Write("   Input the number of new Contact =>");
                num = int.Parse(Console.ReadLine());
                newuser = new User(name, num);
                AllUsers.Add(newuser);
                activeUser.AddUser(newuser);
                newuser.AddUser(activeUser);
                Console.ReadKey();
                goto Menyu;
            }
            if(num==i+1)
            {
                i = 1;
                Console.WriteLine("Choose any one");
                foreach (var item in AllUsers)
                {
                    Console.WriteLine($" {i} => {item.Name}");i++;
                }
                num = int.Parse(Console.ReadLine());
                num--;
                newuser = activeUser;
                activeUser = AllUsers[num];
                AllUsers[num] = newuser;
                Console.Clear();
                goto Menyu;
            }
            else
            {
                num--;
                if (activeUser.Chatting[activeUser.users[num]].Count == 0)
                    Console.WriteLine("  You have no messages with this user. ");
                else
                {
                    activeUser.PrintMessages(activeUser.users[num]);
                   // activeUser.users[num].PrintMessages(activeUser);


                }
                Console.Write(" \n\n\n     Message: ");
                string? message = Console.ReadLine();
                activeUser.SendMessage( message);
                activeUser.PullMessage(message);
                Console.ReadKey();
                goto Menyu;
            }

        }


    }
}
