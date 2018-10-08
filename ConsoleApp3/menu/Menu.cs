using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Menu
    {
        private List<Menu_component> components = new List<Menu_component>();

        public Menu(List<string> options)
        {
            foreach (var option in options)
            {
                components.Add(new Menu_component
                {
                    content = option
                });
            }
            components[0].selected = true;
        }

        public void printMenu()
        {
            foreach (var component in components)
            {
                if (component.selected == true)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(component.content);
                Console.ResetColor();
            }
        }
        public void moveDown()
        {
            int index = 0;
            foreach (var component in components)
            {

                if (component.selected == true)
                {

                    if (index + 1 < components.Count)
                    {
                        component.selected = false;
                        components[index + 1].selected = true;
                    }

                    break;
                }

                index++;
            }
        }
        public void moveUp()
        {
            int index = 0;
            foreach (var component in components)
            {

                if (component.selected == true)
                {
                    if (index - 1 >= 0)
                    {
                        components[index - 1].selected = true;
                        component.selected = false;
                    }
                    break;
                }

                index++;
            }
        }
        public int getSelectedIndex()
        {
            int index = 0;
            foreach (var component in components)
            {
                if (component.selected == true)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }
    }
}
