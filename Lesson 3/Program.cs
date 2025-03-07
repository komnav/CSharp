
var (name1, name2) = ("Name1", "Name2");

Permission firstAccessPermission = Permission.None;

Permission secondAccessPermission = Permission.Create | Permission.Modify;

Permission thirdAccessPermission = Permission.Update;

Permission fourthAccessPermission = Permission.Delete;

Permission fifsAccessPermission = Permission.Modify;


if ((firstAccessPermission & Permission.None) is Permission.None)
{
    Console.WriteLine("Has none permission");
}

if ((secondAccessPermission & Permission.Create) is Permission.Create)
{
    Console.WriteLine("Has create permission");
}

if ((thirdAccessPermission & Permission.Update) is Permission.Update)
{
    Console.WriteLine("Has update permission");
}

if ((fourthAccessPermission & Permission.Delete) is Permission.Delete)
{
    Console.WriteLine("Has delete permission");
}

if ((fifsAccessPermission & Permission.Modify) is Permission.Modify)
{
    Console.WriteLine("Has modify permission");
}


[Flags]
enum Permission
{
    None = 0,
    Create = 1,
    Update = 2,
    Delete = 4,
    Modify = 8
}

