namespace Space_Message_Proxy;

public class Principal {
    public string Name { get; set; }

    public Principal(PrincipalDto dto)
    {
        Name = dto.Name;
    }
}