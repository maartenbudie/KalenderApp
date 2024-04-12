namespace KalenderApp.DAL;

public class UserDTO
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }

    public UserDTO(int id, string name, string email)
    {
        this.id = id;
        this.name = name;
        this.email = email;
    }
}