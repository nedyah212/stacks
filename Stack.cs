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
		public Stack() => (Head, Size) = (new Node<T>(), 1);
		
		public bool IsEmpty() => Head == null ? true : false;
		public void Clear() => (Size, Head) = (0, null);
	}
}
