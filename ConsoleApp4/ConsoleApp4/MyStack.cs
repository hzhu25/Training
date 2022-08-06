namespace ConsoleApp4;

public class MyStack <T>
{
    Stack<T> stack = new Stack<T>();

        public int Count()
        {
            return stack.Count;
        }

        public T Pop()
        {
            return stack.Pop();
        }

        public void Push(T value)
        {
            stack.Push(value);
        }
}