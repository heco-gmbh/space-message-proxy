namespace Space_Message_Proxy;

public class ProjectKey
{
    public string Key { get; set; }
    public ProjectKey(ProjectKeyDto dto)
    {
        Key = dto.key;
    }

}