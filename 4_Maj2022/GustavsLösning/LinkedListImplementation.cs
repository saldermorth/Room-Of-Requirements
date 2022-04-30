LinkedList minList = new LinkedList();

minList.AddNodeToFront(1);
minList.AddNodeToFront(2);
minList.AddNodeToFront(3);
minList.AddNodeToFront(4);
minList.AddNodeToFront(5);
minList.AddNodeToFront(6);
minList.AddNodeToFront(7);
minList.AddNodeToFront(8);
minList.AddNodeToFront(9);
minList.AddNodeToFront(10);

minList.PrintList();
Console.ReadLine();


//Reverse










class LinkedList
{
    int counter;
    LinkedListNode head;

    public LinkedList()
    {
        this.head = null;
        counter = 0;
    }
    public void ReverseList()
    {

    }


    public void AddNodeToFront(int data)
    {
        LinkedListNode node = new LinkedListNode(data);
        node.next = head;
        head = node;
        counter++;
    }

    public void PrintList()
    {
        LinkedListNode runner = head;
        while (runner != null)
        {
            Console.WriteLine(runner.Data);
            runner = runner.next;
        }
    }
}

public class LinkedListNode
{
    public int Data { get; set; }
    public LinkedListNode next { get; set; }

    public LinkedListNode(int data)
    {
        Data = data;
        this.next = null!;
    }

    



}