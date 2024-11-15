using discrete_graph_c_;
using System;

namespace Program
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            UI program = new UI();
            List<Person> randomPerson = new List<Person>();
            List<String> list = new List<String>(); 
            bool state = true;
            Person p1 = new Person();
            Person p2 = new Person();
            while (state) {
                switch (UI.selectUI())
                {
                    case 1: // add random person
                        p1 = UI.addPersonUI();
                        randomPerson.Add(p1);
                        break;
                    case 2: // add connection
                        Console.WriteLine("====================");
                        if (randomPerson.Count == 0) {
                            Console.WriteLine("No Person in list yet!\n");
                            break; 
                        }
                        Console.WriteLine("select Person 1:\n");
                        p1 = UI.selectPersonUI(randomPerson);
                        Console.WriteLine("select Person 2:\n");
                        p2 = UI.selectPersonUI(randomPerson);
                        if (p1 == null || p2 == null) break; 
                        p1.addPersonConnection(p2);
                        p2.addPersonConnection(p1);
                        break;
                    case 3: // add child
                        if (randomPerson.Count == 0)
                        {
                            Console.WriteLine("No Person in list yet!\n");
                            break;
                        }
                        int mode;
                        do
                        {
                            Console.WriteLine("Choose Person/ Add Person/ Exit (1/2/0): ");
                            mode = Convert.ToInt32(Console.ReadLine());
                            if (mode == 0) 
                            { 
                                Console.WriteLine("exit\n");
                                break;
                            }
                            if (mode == 1)
                            {
                                if (UI.confirmationUser("Add User")) p1 = UI.selectPersonUI(randomPerson);
                                else
                                {
                                    mode = 0;
                                    Console.WriteLine("Return to mode chosing!\n");
                                }
                            }
                            else if (mode == 2)
                            {
                                if (UI.confirmationUser("Add User"))
                                {
                                    p1 = UI.addPersonUI();
                                    randomPerson.Add(p1);
                                }
                                else
                                {
                                    mode = 0;
                                    Console.WriteLine("Return to mode chosing!\n");
                                }
                            }
                        } while (1 > mode || mode > 2);
                        mode = 0;
                        do
                        {
                            Console.WriteLine("PARENT\n");
                            p2 = UI.selectPersonUI(randomPerson);
                            if (p2 == p1)
                            {
                                Console.WriteLine("Can not be the same Person!\n");
                                mode = 1;
                            }else if (p2.partner == p1)
                            {
                                Console.WriteLine("Can not be both role!\n");
                                mode = 1;
                            }
                        }while (mode == 1);

                        p2.addChild(p1);

                        break;
                    case 4: // print tree
                        p1 = UI.selectPersonUI(randomPerson);
                        do
                        {
                            Console.Write("Select dfs or bfs:");
                            string typeTraverse = Console.ReadLine();
                            typeTraverse = typeTraverse.Trim().ToLower();
                            if (typeTraverse == "dfs") 
                            {
                                Functions.dfsTraverse(p1);
                                break;
                            }
                            else if (typeTraverse == "bfs")
                            {
                                Functions.bfsTraverse(p1);
                                break;
                            }
                        } while (true);
                        break;
                    case 5: //read file
                        list = Functions.readFile();
                        randomPerson = Functions.fromStringCreateInfo(list);
                        foreach(Person person in randomPerson)
                        {
                            Console.WriteLine(person.name + " " + person.bDay.ToString("dd/MM/yyyy") + " " + person.step + " " + person.partner.name);
                        }
                        break;
                    case 6: //test
                        randomPerson = Functions.CreateTreeFromList(randomPerson);
                        Console.WriteLine("complete!");
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