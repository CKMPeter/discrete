using discrete_graph_c_;
using Google.Protobuf.Compiler;
using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Program
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            string str = "G:\\DATA BAO 2023 - 2024\\DIGR 2023 - 2024\\discrete\\tree.txt";
            UI program = new UI();
            List<Person> randomPerson = new List<Person>();
            List<String> list = new List<String>(); 
            bool state = true;
            Person p1 = new Person();
            Person p2 = new Person();
            while (state) {
                switch (UI.selectUI())
                {
                    case 1: // add a person
                        Functions.printList(randomPerson);
                        int mode_;
                        p1 = UI.addPersonUI();
                        if (randomPerson.Count == 0)
                        {
                            Console.WriteLine("Add Completed!\n");
                            break;
                        }
                        Console.WriteLine("====================================" +
                            "\nWhat is the role of this person?\n");
                        string role = "";
                        do
                        {
                            role = Console.ReadLine();
                            role = role.Trim().ToLower();
                            if (UI.confirmationUser(role))
                            {
                                if (role == "partner") // add connection
                                {
                                    Console.WriteLine("select This Person Partner:\n");
                                    p2 = UI.selectPersonUI(randomPerson);
                                    if (p1 == null || p2 == null) break;
                                    p1.addPersonConnection(p2);
                                    p2.addPersonConnection(p1);
                                    break;
                                }
                                else if (role == "child") // add child
                                {
                                    mode_ = 0;
                                    do
                                    {
                                        Console.WriteLine("PARENT\n");
                                        p2 = UI.selectPersonUI(randomPerson);
                                        if (p2 == p1)
                                        {
                                            Console.WriteLine("Can not be the same Person!\n");
                                            mode_ = 1;
                                        }
                                        else if (p2.partner == p1)
                                        {
                                            Console.WriteLine("Can not be both role!\n");
                                            mode_ = 1;
                                        }
                                    } while (mode_ == 1);

                                    p2.addChild(p1);
                                }
                            }
                        } while (role != "child" || role != "partner");
                        randomPerson.Add(p1);
                        break;
                    case 2: // update a Person
                        Console.WriteLine("/Update Person Information/");
                        Functions.printList(randomPerson);
                        p1 = UI.selectPersonUI(randomPerson);
                        Console.WriteLine("Choose The Part you want to upadte: ");
                        if (UI.partSelection() == "name") {
                            string newName = Console.ReadLine();
                            p1.name = newName.Trim(); 
                        }else if (UI.partSelection() == "dob")
                        {
                            string newDob = Console.ReadLine();
                            DateTime birthDay = DateTime.Parse(newDob, new CultureInfo("en-GB"));
                            p1.bDay = birthDay;
                        }
                        break;
                    case 3: // remove a person
                        Functions.printList(randomPerson);
                        p1 = UI.removePersonUI();
                        if (randomPerson.Count == 0)
                        {
                            Console.WriteLine("Remove Completed!\n");
                            break;
                        }
                        Console.WriteLine("====================================" +
                            "\nWhat is the role of this person?\n");
                        role = " ";
                        do
                        {
                            role = Console.ReadLine();
                            role = role.Trim().ToLower();
                            if (UI.confirmationUser(role))
                            {
                                if (role == "partner") // remove connection
                                {
                                    Console.WriteLine("select This Person Partner:\n");
                                    p2 = UI.selectPersonUI(randomPerson);
                                    if (p1 == null || p2 == null) break;
                                    p1.removePersonConnection(p2);
                                    p2.removePersonConnection(p1);
                                    break;
                                }
                                else if (role == "child") // add child
                                {
                                    mode_ = 0;
                                    do
                                    {
                                        Console.WriteLine("PARENT\n");
                                        p2 = UI.selectPersonUI(randomPerson);
                                        if (p2 == p1)
                                        {
                                            Console.WriteLine("Can not be the same Person!\n");
                                            mode_ = 1;
                                        }
                                        else if (p2.partner == p1)
                                        {
                                            Console.WriteLine("Can not be both role!\n");
                                            mode_ = 1;
                                        }
                                    } while (mode_ == 1);

                                    p2.removeChild(p1);
                                }
                            }
                        } while (role != "child" || role != "partner");
                        randomPerson.Remove(p1);
                        break;
                    case 4: // print tree
                        if (randomPerson.Count == 0)
                        {
                            Console.WriteLine("No Person in list yet!\n");
                            Console.ReadKey();
                            break;
                        }
                        p1 = UI.selectPersonUI(randomPerson);
                        do
                        {
                            Console.Write("Select dfs or bfs:");
                            string typeTraverse = Console.ReadLine();
                            typeTraverse = typeTraverse.Trim().ToLower();
                            if (typeTraverse == "dfs")
                            {
                                Functions.dfsTraverse(p1);
                                Console.ReadKey();
                                break;
                            }
                            else if (typeTraverse == "bfs")
                            {
                                Functions.bfsTraverse(p1);
                                Console.ReadKey();
                                break;
                            }
                        } while (true);
                        break;
                    case 5: // print file
                        Functions.printToFile(randomPerson, "G:\\DATA BAO 2023 - 2024\\DIGR 2023 - 2024\\discrete\\tree.txt");
                        break;
                    case 6: //read file
                        list = Functions.readFile(str);
                        randomPerson = Functions.fromStringCreateInfo(list);
                        foreach(Person person in randomPerson)
                        {
                            Console.WriteLine(person.name + " " + person.bDay.ToString("dd/MM/yyyy") + " " + person.step + " " + person.partner.name);
                        }
                        Console.ReadKey();
                        break;
                    case 7: //create tree
                        randomPerson = Functions.CreateTreeFromList(randomPerson);
                        Console.WriteLine("complete!");
                        Console.ReadKey();
                        break;
                    case 8: //check relationshop
                        Functions.printList(randomPerson);
                        p1 = UI.selectPersonUI(randomPerson);
                        p2 = UI.selectPersonUI(randomPerson);
                        if(p1 == p2)
                        {
                            Console.WriteLine("Is the same Person");
                            Console.ReadKey();
                            break;
                        }
                        Functions.DetermineRelationship(p1, p2);
                        Console.ReadKey ();
                        break;
                    case 0:
                        state = false;
                        break;
                    default:
                        Console.WriteLine("please enter a mode!\n");
                        continue;
                        break;
                }
            }
            return;
        }
    }
}