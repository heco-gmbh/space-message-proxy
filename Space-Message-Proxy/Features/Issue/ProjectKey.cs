namespace Space_Message_Proxy;

public class ProjectKey
{
    public string Key { get; private set; }
    public ProjectKey(ProjectKeyDto dto)
    {
        Key = dto.key;
    }

}