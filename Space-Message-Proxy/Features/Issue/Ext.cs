﻿namespace Space_Message_Proxy;

public class Ext
{
    public ProjectKey ProjectKey { get; private set; }
    public Ext(ExtDto dto)
    {
        ProjectKey = new ProjectKey(dto.projectKey);
    }
}