public class ItemDto
{
    public string name { get; set; }
    public string description { get; set; }
    public DateTime updated_at { get; set; }
    public string clone_url { get; set; }
    public string language { get; set; }
    public OwnerDto owner { get; set; }
}

public class OwnerDto
{
    public string login { get; set; }
}

public class RootDto
{
    public int total_count { get; set; }
    public bool incomplete_results { get; set; }
    public List<ItemDto> items { get; set; }
}

