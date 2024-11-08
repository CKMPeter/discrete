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
                            Console.WriteLine("Choose or Add a Person (1 or 2): ");
                            mode = Convert.ToInt32(Console.ReadLine());
                            if (mode == 1)
                            {
                                p1 = UI.selectPersonUI(randomPerson);
                            }
                            else if (mode == 2)
                            {
                                p1 = UI.addPersonUI();
                                randomPerson.Add(p1);
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
                        p2.partner.addChild(p1);
                        Person[] list = [p1, p2];
                        p1.parent = list;

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