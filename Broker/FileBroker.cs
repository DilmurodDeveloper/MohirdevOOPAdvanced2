public class FileBroker
{
    private string filePath;
    public FileBroker(string path)
    {
        filePath = path;
    }

    public List<string> ReadAllContacts()
    {
        if(!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        return new List<string>(File.ReadAllLines(filePath));
    }

    public void WriteAllContacts(List<string> contacts)
    {
        File.WriteAllLines(filePath, contacts);
    }
}