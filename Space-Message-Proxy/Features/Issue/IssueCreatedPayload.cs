﻿namespace Space_Message_Proxy;

public class IssueCreatedPayload
{

    public Issue Issue { get; set; }

    public IssueCreatedPayload(IssueCreatedPayloadDto dto)
    {
        Issue = new Issue(dto.Issue);
    }
}