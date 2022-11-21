using System;

public class MessageModel
{
    public int MessageId { get; set; }
    public int UserIdFrom { get; set; }
    public int UserIdTo { get; set; }
    public string Content { get; set; }
    public DateTime Sent { get; set; }
    public DateTime Read { get; set; }
}
