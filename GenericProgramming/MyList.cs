using System;
using System.IO.Pipes;
using System.Runtime.Serialization;

namespace WWW
{
    public class MyList<T>
    {
        public Node<T> head;
        public Node<T> tail;

        /// <summary>
        /// Sets head and tail to null
        /// </summary>
        public MyList()
        {
            head = null;
            tail = null;
        }

        /// <summary>
        /// Returns the node at the given index
        /// </summary>
        /// <param name="index"> Index of the node to return</param>
        public Node<T> get_node(int index)
        {
            int cpt = 0;
            Node<T> current = head;
            while (cpt < index && current != tail)
            {
                current = current.next;
                cpt++;
            }

            if (current == tail && cpt < index) 
                return null; 
            return current;
        }

        /// <summary>
        /// Returns the value at the given index
        /// </summary>
        /// <param name="index"> Index of the value to return</param>
        public T get(int index)
        {
            Node<T> current = this.get_node(index);
            if (current == null)
            {
                throw new ArgumentException();
            }

            return current.get_value();
        }

        /// <summary>
        /// Adds an element at the end of the list
        /// </summary>
        /// <param name="value"> Element to add</param>
        public void append(T value)
        {
            Node<T> tmp = new Node<T>(value);
            if (head == null && tail == null)
            {
                head = tmp;
                tail = tmp;
                return;
            }
            tail.next = tmp;
            tmp.prev = tail;
            tail = tmp;
        }

        /// <summary>
        /// Prints the list on the console.
        /// </summary>
        public void print()
        {
            Node<T> current = head;
            string new_string = "";
            while (current != null)
            {
                new_string += current.get_value().ToString();
                if(current.next!=null)
                {
                    new_string += " ";
                }
                current = current.next;
            }

            Console.WriteLine(new_string);
        }

        /// <summary>
        /// Adds an element at the beginning of the list
        /// </summary>
        /// <param name="value"> Element to add</param>
        public void prepend(T value)
        {
            Node<T> tmp = new Node<T>(value);
            if (head == null && tail == null)
            {
                head = tmp;
                tail = tmp;
                return;
            }
            head.prev = tmp;
            tmp.next = head;
            head = tmp;

        }

        /// <summary>
        /// Adds an element in the list at the given index
        /// </summary>
        /// <param name="value"> Element to add</param>
        /// <param name="index"> Index of the element to add</param>
        public void insert(T value, int index)
        {
            Node<T> current = this.get_node(index);
            if (current == null)
            {
                throw new ArgumentException();
            }

            if (current.next == null)
            {
                append(value);
                return;
            }

            Node<T> tmp = new Node<T>(value);
            tmp.next = current.next;
            current.next.prev = tmp;
            current.next = tmp;
            tmp.prev = current;




        }

        /// <summary>
        /// Removes an element at the beginning of the list
        /// </summary>
        public T prepop()
        {
            if (head == null)
            {
                throw new Exception();
            }

            T value = head.get_value();
            if (head == tail)
            {
                head = null;
                tail = null;
                
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            return value;
        }

        /// <summary>
        /// Removes an element at the end of the list
        /// </summary>
        public T pop()
        {
            if (tail == null)
            {
                throw new Exception();
            }

            T value = tail.get_value();
            if (head == tail)
            {
                head = null;
                tail = null;
                
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            return value;
        }

        /// <summary>
        /// Removes an element of the list at the given index
        /// </summary>
        /// <param name="index"> Index of the element to remove</param>
        public T remove_at(int index)
        {
            Node<T> current = this.get_node(index);
            if (current == null)
            {
                throw new ArgumentException();
            }
            T value = current.get_value();
            if (current.next == null)
            {
                this.pop();
            }
            else if(current.prev==null)
            {
                 this.prepop();
            }
            else
            {
                current.next.prev = current.prev;
                current.prev.next = current.next;
            }
            

            return value;
            
        }
    }
}
