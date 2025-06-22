namespace MindLedger.Domain;

public abstract class NoteBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set;} = DateTime.Now;

    public List<Tag> Tags { get; set; } = new();

    public Guid CampaignId { get; set; }
    public Campaign? Campaign { get; set; }
}
