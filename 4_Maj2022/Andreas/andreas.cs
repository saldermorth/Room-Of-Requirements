
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

/*Problem lättare*/
string RearrangeName(string name) => String.Join(' ', name.Split(' ').Reverse());
//Console.WriteLine(RearrangeName(Console.ReadLine()));

/*Problem mellan*/

//Lösning 1
bool IsValidEmail(string email) => 
    email.Count(x => x == '@') == 1 && 
    email.Count(x => x == '.') > 0 && 
    email.Split('@')[0].Count() > 1 && 
    email.Split('.')[email.Split('.').Length-1].Count() > 1 && 
    email.Split('@')[1].Split('.')[0].Count() >2;

//Lösning 2
bool IsValidEmailRegEx(string email)
{
    email = email.Trim();
    try
    {
        return Regex.IsMatch(email,
            @"^([^@\s]{2,99})+@([^@\s]{3,99})+\.([^@\s]{2,99})+$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
    }
    catch (RegexMatchTimeoutException)
    {
        return false;
    }
}
//Console.WriteLine(IsValidEmail(Console.ReadLine()));
//Console.WriteLine(IsValidEmailRegEx(Console.ReadLine()));


//Problem svårare

LinkedList<string> list = new LinkedList<string>();
list.AddLast("ett");
list.AddLast("två");
list.AddLast("tre");
list.AddLast("fyra");
list.AddLast("fem");
list.AddLast("sex");
list.AddLast("sju");
list.AddLast("åtta");
list.AddLast("nio");
list.AddLast("tio"); 

for (int i = 0; i < list.Count; i++)
{   
    var item = list.Last();
    list.AddBefore(list.Find(list.ElementAt(i)),item);
    list.RemoveLast();
}
//foreach (var item in list)
//{
//    Console.WriteLine(item);
//}


Console.ReadKey();