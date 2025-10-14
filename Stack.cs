using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2_stack
{
	public class Stack<T>
	{	
		public int Size { get; set; }
		public Node<T> Head { get; set; }
		public Stack() => Clear();

		public bool IsEmpty() => Size == 0;
		public void Clear() => (Size, Head) = (0, null);
		
		public void Push(T element) 
		{
			Node<T> newHead = new Node<T>(element,Head);
			Head = newHead;
			Size++;
		}

		public T Top()
		{
			if (IsEmpty())
				throw new ApplicationException();
		
			return Head.Element;
		}

		public T Pop()
		{
			T element = Top();
			Head = Head.Next;
			Size--;
			return element;
		}


	}
}
