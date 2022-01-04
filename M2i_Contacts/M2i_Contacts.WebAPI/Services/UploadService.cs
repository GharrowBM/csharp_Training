namespace M2i_Contacts.WebAPI.Services;

public class UploadService
{
    private void MakeFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public string Upload(IFormFile file)
    {
        string fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
        string path = Path.Combine(Environment.CurrentDirectory, "contacts", fileName);
        MakeFolder(Path.Combine(Environment.CurrentDirectory, "contacts"));
        Stream stream = System.IO.File.Create(path);
        file.CopyTo(stream);
        stream.Close();
        return "contacts/" + fileName;
    }
}