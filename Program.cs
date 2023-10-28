using System.CommandLine;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

if (File.Exists("./.env"))
{
    Console.Write("Give Master password:");
    var pass = Console.ReadLine() ?? "";
    var key = await File.ReadAllTextAsync("./.env");

    var decrypted = await Coders.DecryptBytes(key, pass);
    if (decrypted == null)
    {
        System.Console.Error.WriteLine("Could not encrypt key");
        return -1;
    }
    if (!decrypted.StartsWith("key:"))
    {

    }
}
else
{
    Console.Write("Set Up Master password:");
    var pass = Console.ReadLine() ?? "";
    var encrypted = await Coders.EncodeStringAsync($"key:{DateTime.UtcNow}", pass);
    if (encrypted == null)
    {
        System.Console.Error.WriteLine("Could not encrypt key");
    }
    await File.WriteAllTextAsync("./.env", encrypted);
}
var root = new RootCommand("Password Storing Tool");
var adder = new Command("Add", "Add new password and assosiative domain");

return await root.InvokeAsync(args);

