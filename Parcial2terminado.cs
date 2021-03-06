using System;
using System.Collections.Generic;

namespace CompositePattern
{using System;
	using System.Collections.Generic;

	namespace CompositePattern
	{
		class MainApp
		{
			static void Main()
			{
				var root = new TreeNode<Shape> { Node = new Shape("Picture") };
				root.Add(new Shape("Red Line"));
				root.Add(new Shape("Blue Circle"));
				root.Add(new Shape("Green Box"));
				var branch = root.Add(new Shape("Two Circles"));
				branch.Add(new Shape("Black Circle"));
				branch.Add(new Shape("White Circle"));
				var shape = new Shape("Yellow Line");
				root.Add(shape);
				root.Remove(shape);
				root.Add(shape);
				TreeNode<Shape>.Display(root, 1); 
				Console.ReadKey();
			}
		}

		class TreeNode<T> where T : IComparable<T>
		{
			List<TreeNode<T>> children = new List<TreeNode<T>>();

			public TreeNode<T> Add(T child)
			{

				var newShape = new TreeNode<T> {Node = child};
				children.Add (newShape);
				return newShape;

				}
			public void Remove(T child)
			{
				// 2. COMPLETAR
				//return this.children.Remove(child);
				foreach (var treeNode in children) {
					if (treeNode.Node.CompareTo (child) == 0) {
						children.Remove (treeNode);
						return;
					}
				}
			}

					public T Node { get; set; }

					public List<TreeNode<T>> Children
					{
						get { return children; }
					}

					public static void Display(TreeNode<T> node, int indentation)
					{
						// 3. COMPLETAR
						string dash = new String ('-', indentation);
						Console.WriteLine (dash + " " + node.Node);
						node.Children.ForEach (n => Display (n, indentation + 1));

					}
					}

					class Shape : IComparable<Shape>
					{
						string name;

						public Shape(string name)
						{
							this.name = name;
						}

						public override string ToString()
						{
							return name;
						}

						public int CompareTo(Shape other)
						{
							return (this == other) ? 0 : -1;
						}
					}
	       }
}